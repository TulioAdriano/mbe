using System;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Text;


namespace mbe
{
	public class CamOut
	{
        public enum CamOUtUnit
        {
            INCH = 0,
            METRIC
        }

        public static CamOUtUnit m_CamOutUnit = CamOUtUnit.METRIC;
        

		public const int CAMOUT_XOFFSET = 25400;	//2.54mm
		public const int CAMOUT_YOFFSET = 25400;	//2.54mm

        /// <summary>
        /// Remaps layer name to adequate Gerber extension
        /// </summary>
        Dictionary<string, string> GerberExtRemap = new Dictionary<string, string>()
        {
            ["PLC"] = "GTO", //PLC -> GTO
            ["STC"] = "GTS", //STC -> GTS
            ["CMP"] = "GTL", //CMP -> GTL
            ["L2"] =  "GL1", //L2  -> GL1
            ["L3"] =  "GL2", //L3  -> GL2
            ["SOL"] = "GBL", //SOL -> GBL
            ["STS"] = "GBS", //STS -> GBS
            ["PLS"] = "GBO", //PLS -> GBO
            ["DIM"] = "GML"  //DIM -> GML
        };               


		/// <summary>
		/// ガーバーファイルのヘッダー
		/// </summary>
		public string[] GerberHeaderStringArray_INCH ={
			"G70*",
			"%OFA0B0*%",
			"%FSLAX24Y24*%",
			"%IPPOS*%",
			"%LPD*%"
		};

        public string[] GerberHeaderStringArray_METRIC ={
			"G71*",
			"%OFA0B0*%",
			"%FSLAX44Y44*%",
			"%IPPOS*%",
			"%LPD*%"
		};

		/// <summary>
		/// ガーバーファイルのフッター
		/// </summary>
		public string[] GerberFooterStringArray ={
			"M02*"
		};


		public string[] ExcellonHeaderStringArray_INCH = {
			//"%",
			"M48",
			"INCH,TZ"
		};

        public string[] ExcellonHeaderStringArray_METRIC = {
			//"%",
			"M48",
			"METRIC,TZ"
		};

        
        public string[] ExcellonFooterStringArray = {
			"M30"
		};


		public MbeLayer.LayerValue[] OutLayerArray = {
			MbeLayer.LayerValue.MMC,
			MbeLayer.LayerValue.DIM,
			MbeLayer.LayerValue.PLC,
			MbeLayer.LayerValue.STC,
			MbeLayer.LayerValue.CMP,
			MbeLayer.LayerValue.L2,
			MbeLayer.LayerValue.L3,
			MbeLayer.LayerValue.SOL,
			MbeLayer.LayerValue.STS,
			MbeLayer.LayerValue.PLS,
   			MbeLayer.LayerValue.MMS,
            MbeLayer.LayerValue.DRL,
            MbeLayer.LayerValue.DOC
		};

		public CamOut()
		{
			baseDataList = new List<CamOutBaseData>();
		}

		public void Init()
		{
			baseDataList.Clear();
		}

		public void Add(CamOutBaseData baseData)
		{
			baseDataList.Add(baseData);
		}


        /// <summary>
        /// CAMデータをソートする。
        /// Shape→幅(ドリルの場合は直径)→高さの優先順位
        /// </summary>
        /// <param name="camd0"></param>
        /// <param name="camd1"></param>
        /// <returns></returns>
		private static int CompareBaseDataByAperture(CamOutBaseData camd0, CamOutBaseData camd1)
		{
			if (camd0.shape != camd1.shape) {
				return (int)camd0.shape - (int)camd1.shape;
			}
			if (camd0.width != camd1.width) {
				return camd0.width - camd1.width;
			}
			if (camd0.height != camd1.height) {
				return camd0.height - camd1.height;
			}
			return 0;
		}

		/// <summary>
		/// Tコード、Dコード文字列の設定
		/// </summary>
		protected CamOutResult SetCodeString()
		{
			CamOutResult result = new CamOutResult();
			result.code = CamOutResult.ResultCode.NOERROR;
			int n = baseDataList.Count;
			if(n<1)return result;
			baseDataList.Sort(CompareBaseDataByAperture);
			int tSuffix = 1;
			int dSuffix = 10;


            CamOutBaseData.Shape shape = CamOutBaseData.Shape.Err;
            int width = 0;
            int height = 0;



            //CamOutBaseData camd = baseDataList[0];
            //string strCode;
            //if (shape == CamOutBaseData.Shape.Drill || shape == CamOutBaseData.Shape.DrillPTH) {
            //    strCode = string.Format("T{0:00}", tSuffix);
            //    tSuffix++;
            //} else {
            //    strCode = string.Format("D{0}", dSuffix);
            //    dSuffix++;
            //}
            //camd.code = strCode;


            string strCode = "";
            for (int i = 0; i < n; i++) {
				CamOutBaseData camd = baseDataList[i];
				
				if (shape != camd.shape || width != camd.width || height != camd.height) {
					shape = camd.shape;
					width = camd.width;
					height = camd.height;
					if (shape == CamOutBaseData.Shape.Drill || shape == CamOutBaseData.Shape.DrillPTH) {
						if (tSuffix >= 100) {
							result.code = CamOutResult.ResultCode.TCODEOVER;
							return result;
						}
						strCode = string.Format("T{0:00}", tSuffix);
						tSuffix++;
					} else {
						if (dSuffix >= 1000) {
							result.code = CamOutResult.ResultCode.DCODEOVER;
							return result;
						}
						strCode = string.Format("D{0}", dSuffix);
						dSuffix++;
					}
				}
				camd.code = strCode;
			}
			return result;
		}

		public void Dump(string filename)
		{
			StreamWriter streamWriter = null;
			try {
				streamWriter = new StreamWriter(filename);

				foreach(CamOutBaseData camd in baseDataList){
					streamWriter.Write(camd.layer + ","+ camd.code+ ","+ camd.ctype+",");
					streamWriter.Write(camd.shape+","+camd.width+","+camd.height+",");
					streamWriter.WriteLine(camd.pt0.X+","+camd.pt0.Y+","+camd.pt1.X+","+camd.pt1.Y);
				}

				streamWriter.Flush();
			}
			catch (Exception) {
				return;
			}
			finally {
				if (streamWriter != null) {
					streamWriter.Close();
				}
			}
		}



		protected void OutAdCode(StreamWriter streamWriter, MbeLayer.LayerValue layer)
		{
			string dCode = "";
			double width;
			double height;
			string str;
			int n = baseDataList.Count;
			for (int i = 0; i < n; i++) {
				CamOutBaseData camd = baseDataList[i];
				if (camd.layer != layer) continue;
				if (dCode != camd.code) {
					dCode = camd.code;

					if (camd.shape == CamOutBaseData.Shape.Obround) {
						if (camd.width == camd.height) {
                            if (m_CamOutUnit == CamOUtUnit.INCH) {
                                width = (double)camd.width / 254000;
                            } else {
                                width = (double)camd.width / 10000;
                            }
							str = string.Format("%AD{0}C,{1:0.0000}*%", dCode, width);
						} else {
                            if (m_CamOutUnit == CamOUtUnit.INCH) {
                                width = (double)camd.width / 254000;
                                height = (double)camd.height / 254000;
                            } else {
                                width = (double)camd.width / 10000;
                                height = (double)camd.height / 10000;
                            }
							str = string.Format("%AD{0}O,{1:0.0000}X{2:0.0000}*%", dCode, width, height);
						}
					} else if (camd.shape == CamOutBaseData.Shape.Rect) {
                        if (m_CamOutUnit == CamOUtUnit.INCH) {
                            width = (double)camd.width / 254000;
                            height = (double)camd.height / 254000;
                        } else {
                            width = (double)camd.width / 10000;
                            height = (double)camd.height / 10000;
                        }
						str = string.Format("%AD{0}R,{1:0.0000}X{2:0.0000}*%", dCode, width, height);
					} else {
						continue;
					}
					streamWriter.WriteLine(str);
				}
			}
		}

		protected int convertToUnitINCH(int n)
		{
			double d=n;
            return (int)Math.Round(d / 254000 * 10000);
		}

		protected void OutPlotData(StreamWriter streamWriter, MbeLayer.LayerValue layer)
		{
			string dCode = "";
			int x1;
			int y1;
            int x2;
            int y2;
            string str;
			int n = baseDataList.Count;
			for (int i = 0; i < n; i++) {
				CamOutBaseData camd = baseDataList[i];
				if (camd.layer != layer) continue;
				if (dCode != camd.code) {
					dCode = camd.code;
					streamWriter.WriteLine(dCode + "*");
				}
				if (camd.ctype == CamOutBaseData.CamType.VECTOR) {
                    if (camd.pt0.X != camd.pt1.X || camd.pt0.Y != camd.pt1.Y) { //0.48.02(2009/04/24) もとの座標でゼロ長のベクトルは出力しないように変更
                        x1 = camd.pt0.X + CAMOUT_XOFFSET;
                        y1 = camd.pt0.Y + CAMOUT_YOFFSET;
                        x2 = camd.pt1.X + CAMOUT_XOFFSET;
                        y2 = camd.pt1.Y + CAMOUT_YOFFSET;

                        if (m_CamOutUnit == CamOUtUnit.INCH) {
                            x1 = convertToUnitINCH(x1);
                            y1 = convertToUnitINCH(y1);
                            x2 = convertToUnitINCH(x2);
                            y2 = convertToUnitINCH(y2);
                        }//METRICのときは変換を必要としない

                        //0.46.01(2008/12/31) ** この修正は 0.48.02 で変更した **
                        //ガーバーデータの座標に変換したあとに座標が一致した場合は、
                        //最小長線分(0.1μm)をパッドの代わりに使用している可能性もあるので、
                        //ガーバーデータ上でも最小長線分(2.54μm)とする。
                        //実際にはx2に1を足して、水平線分としている。

                        //0.48.02(2009/04/24)
                        //ガーバーデータの座標に変換したあとに座標が一致した場合は、
                        //フラッシュデータとして出力する
                        if (x1 == x2 && y1 == y2) {
                            if (m_CamOutUnit == CamOUtUnit.INCH) {
                                str = string.Format("X{0:000000}Y{1:000000}D03*", x1, y1);
                            } else {
                                str = string.Format("X{0:00000000}Y{1:00000000}D03*", x1, y1);
                            }
                            streamWriter.WriteLine(str);
                        } else {
                            if (m_CamOutUnit == CamOUtUnit.INCH) {
                                str = string.Format("X{0:000000}Y{1:000000}D02*", x1, y1);
                            }else{
                                str = string.Format("X{0:00000000}Y{1:00000000}D02*", x1, y1);
                            }
                            streamWriter.WriteLine(str);
                            if (m_CamOutUnit == CamOUtUnit.INCH) {
                                str = string.Format("X{0:000000}Y{1:000000}D01*", x2, y2);
                            } else {
                                str = string.Format("X{0:00000000}Y{1:00000000}D01*", x2, y2);
                            }
                            streamWriter.WriteLine(str);
                        }
                        //if (x1 != x2 || y1 != y2) { //ガーバーデータの座標に変換したあとでも始点終点が異なる場合のみ出力する。0.46.00(2008/12/28)
                        //    str = string.Format("X{0:000000}Y{1:000000}D02*", x1, y1);
                        //    streamWriter.WriteLine(str);
                        //    str = string.Format("X{0:000000}Y{1:000000}D01*", x2, y2);
                        //    streamWriter.WriteLine(str);
                        //}
                    } else {
                        System.Diagnostics.Debug.WriteLine("Gerber out: zero length vector");
                    }

				} else {
                    x1 = camd.pt0.X + CAMOUT_XOFFSET;
                    y1 = camd.pt0.Y + CAMOUT_YOFFSET;
                    if (m_CamOutUnit == CamOUtUnit.INCH) {
                        x1 = convertToUnitINCH(x1);
                        y1 = convertToUnitINCH(y1);
                        str = string.Format("X{0:000000}Y{1:000000}D03*", x1, y1);
                    } else {
                        //METRICのときは変換を必要としない
                        str = string.Format("X{0:00000000}Y{1:00000000}D03*", x1, y1);
                    }
					streamWriter.WriteLine(str);
				}
			}
		}

		protected void OutDefineDrill(StreamWriter streamWriter)
		{
			string tCode = "";
			double dia;
			string str;
			int n = baseDataList.Count;
			for (int i = 0; i < n; i++) {
				CamOutBaseData camd = baseDataList[i];
				if (camd.layer != MbeLayer.LayerValue.DRL) continue;
				if (tCode != camd.code) {
					tCode = camd.code;

                    if (m_CamOutUnit == CamOUtUnit.INCH) {
                        dia = (double)camd.width / 254000;
                    } else {
                        dia = (double)camd.width / 10000;
                    }
					str = string.Format("{0}C{1:0.0000}", tCode, dia);
					streamWriter.WriteLine(str);
				}
			}
			streamWriter.WriteLine("%");
		}

        //protected string ExellonMericCoordStr(int n)
        //{
        //    double d = n;
        //    int i = (int)Math.Round(d / 10);
        //    int fracVal = i % 1000;
        //    int intVal = i / 1000;
        //    string str = "";
        //    if(intVal!=

        //}
        
        protected void OutDrillPos(StreamWriter streamWriter)
		{
			string tCode = "";
			int x;
			int y;
			string str;
			int n = baseDataList.Count;
			for (int i = 0; i < n; i++) {
				CamOutBaseData camd = baseDataList[i];
				if (camd.layer != MbeLayer.LayerValue.DRL) continue;
				if (tCode != camd.code) {
					tCode = camd.code;
					streamWriter.WriteLine(tCode);
				}
                x = camd.pt0.X + CAMOUT_XOFFSET;
                y = camd.pt0.Y + CAMOUT_YOFFSET;
                if (m_CamOutUnit == CamOUtUnit.INCH) {
  				    x = convertToUnitINCH(x);   //For Excellon
                    y = convertToUnitINCH(y);   //For Excellon
                    str = string.Format("X{0}Y{1}", x, y);
                } else {
                    double dx = (double)x/10000;
                    double dy = (double)y/10000;
                    str = string.Format("X{0:###.000}Y{1:###.000}", dx, dy);
                }
				streamWriter.WriteLine(str);
			}
		}


		protected CamOutResult ExcellonDrillListOut(string path)
		{
			CamOutResult result = new CamOutResult();
			result.code = CamOutResult.ResultCode.NOERROR;
			string outpath = Path.ChangeExtension(path, "DRI"); //DRI -> delete
            StreamWriter streamWriter = null;
			try {
				streamWriter = new StreamWriter(outpath);
                if (m_CamOutUnit == CamOUtUnit.INCH) {
                    streamWriter.WriteLine("Code    Size(inch)            Number");
                } else {
                    streamWriter.WriteLine("Code    Size(mm)              Number");
                }

                //string tCode = "";
                //double dia;
                //string str;
                //string platedInfo;

                int dataCount = baseDataList.Count;
                int index = 0;
                CamOutBaseData camd = baseDataList[index];
                while(index<dataCount){
                    if (camd.shape == CamOutBaseData.Shape.Drill || camd.shape == CamOutBaseData.Shape.DrillPTH) {
                        CamOutBaseData.Shape shape = camd.shape;
                        int width = camd.width;
                        int drillCount = 0;
                        while (true) {
                            index++;
                            drillCount++;

                            if (index >= dataCount || baseDataList[index].shape != shape || baseDataList[index].width != width) {
                                string tCode = camd.code;
                                double dia;
                                if (m_CamOutUnit == CamOUtUnit.INCH) {
                                    dia = (double)camd.width / 254000;
                                } else {
                                    dia = (double)camd.width / 10000;
                                }
                                string platedInfo = (camd.shape == CamOutBaseData.Shape.Drill ? "NPTH" : "PTH ");
                                string str = string.Format("{0}       {1:0.0000}     {2}     {3}", tCode, dia, platedInfo, drillCount);
                                streamWriter.WriteLine(str);
                                camd = baseDataList[index];
                                break;
                            }
                        }
                    } else {
                        index++;
                    }
                }

                //string tCode = "";
                //double dia;
                //string str;
                //string platedInfo;
                //int n = baseDataList.Count;
                //for (int i = 0; i < n; i++) {
                //    CamOutBaseData camd = baseDataList[i];
                //    if (camd.layer != MbeLayer.LayerValue.DRL) continue;
                //    if (tCode != camd.code) {
                //        tCode = camd.code;
                //        dia = (double)camd.width / 254000;
                //        if(camd.shape == CamOutBaseData.Shape.Drill){
                //            platedInfo = "NPTH";
                //        }else{
                //            platedInfo = "PTH";
                //        }
                //        str = string.Format("{0}       {1:0.0000}     {2}", tCode, dia,platedInfo);
                //        streamWriter.WriteLine(str);
                //    }
                //}
			}
			catch (Exception) {
				result.code = CamOutResult.ResultCode.FILEERROR;
				result.filename = Path.GetFileName(outpath);
				return result;
			}
			finally {
				if (streamWriter != null) {
					streamWriter.Close();
				}
			}
			return result;
		}


		protected CamOutResult ExcellonDrillDataOut(string path)
		{
			CamOutResult result = new CamOutResult();
			result.code = CamOutResult.ResultCode.NOERROR;

			string outpath = Path.ChangeExtension(path,"TXT"); //DRD -> TXT
            StreamWriter streamWriter = null;
			try {
				streamWriter = new StreamWriter(outpath);
				int n;
                if (m_CamOutUnit == CamOUtUnit.INCH) {
                    n = ExcellonHeaderStringArray_INCH.Length;
                    for (int i = 0; i < n; i++) streamWriter.WriteLine(ExcellonHeaderStringArray_INCH[i]);
                } else {
                    n = ExcellonHeaderStringArray_METRIC.Length;
                    for (int i = 0; i < n; i++) streamWriter.WriteLine(ExcellonHeaderStringArray_METRIC[i]);
                }
				OutDefineDrill(streamWriter);
				OutDrillPos(streamWriter);
				n = ExcellonFooterStringArray.Length;
				for (int i = 0; i < n; i++) streamWriter.WriteLine(ExcellonFooterStringArray[i]);
			}
			catch (Exception) {
				result.code = CamOutResult.ResultCode.FILEERROR;
				result.filename = Path.GetFileName(outpath);
				return result;
			}
			finally {
				if (streamWriter != null) {
					streamWriter.Close();
				}
			}
			return result;
		}



		protected CamOutResult GerberOutLayer(string path, MbeLayer.LayerValue layer)
		{
			CamOutResult result = new CamOutResult();
			result.code = CamOutResult.ResultCode.NOERROR;
            string ext = MbeLayer.GetLayerName(layer);
            string outpath = string.Empty;
            if (GerberExtRemap.ContainsKey(ext))
            {
                outpath = Path.ChangeExtension(path, GerberExtRemap[MbeLayer.GetLayerName(layer)]);
            }
            else
            {
                outpath = Path.ChangeExtension(path, MbeLayer.GetLayerName(layer));
            }
            StreamWriter streamWriter = null;
			try {
				streamWriter = new StreamWriter(outpath);
				int n;
                if (m_CamOutUnit == CamOUtUnit.INCH) {
                    n = GerberHeaderStringArray_INCH.Length;
                    for (int i = 0; i < n; i++) streamWriter.WriteLine(GerberHeaderStringArray_INCH[i]);
                } else {
                    n = GerberHeaderStringArray_METRIC.Length;
                    for (int i = 0; i < n; i++) streamWriter.WriteLine(GerberHeaderStringArray_METRIC[i]);
                }
				OutAdCode(streamWriter, layer);
				OutPlotData(streamWriter, layer);
				n = GerberFooterStringArray.Length;
				for(int i=0;i<n;i++)streamWriter.WriteLine(GerberFooterStringArray[i]);
			}
			catch (Exception) {
				result.code = CamOutResult.ResultCode.FILEERROR;
				result.filename = Path.GetFileName(outpath);
				return result;
			}
			finally {
				if (streamWriter != null) {
					streamWriter.Close();
				}
			}
			return result;
		}

		public CamOutResult GerberOut(string path,ulong layerMask)
		{
			CamOutResult result;
			result = SetCodeString();
			//Dump(path);
			if (result.code != CamOutResult.ResultCode.NOERROR) return result;
			int n = OutLayerArray.Length;
			for (int i = 0; i < n; i++) {
                if ((layerMask & (ulong)(OutLayerArray[i])) != 0) {
                    if (OutLayerArray[i] == MbeLayer.LayerValue.DRL) {
                        result = ExcellonDrillDataOut(path);
                        if (result.code == CamOutResult.ResultCode.NOERROR) {
                            result = ExcellonDrillListOut(path);
                        }
                    } else {
                        result = GerberOutLayer(path, OutLayerArray[i]);
                    }
                    if (result.code != CamOutResult.ResultCode.NOERROR) return result;
                }
			}
			return result;
		}


		protected List<CamOutBaseData> baseDataList;
	}

	public struct CamOutResult
	{

		public ResultCode code;
		public string filename;


		public enum ResultCode
		{
			NOERROR = 0,
			FILEERROR,
			TCODEOVER,
			DCODEOVER
		}
	}

}
