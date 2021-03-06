using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace mbe
{
	public partial class SetTextForm : Form
	{
		public SetTextForm()
		{
			InitializeComponent();
			nameString = "";
			textHeight = MbeObjText.DEFAULT_TEXT_HEIGHT;
			lineWidth = MbeObjText.DEFAULT_LINE_WIDTH;
            useSystemfontOnDoc = CHK_USE_SYSTEMFONT_ON_DOC_STATE.DISABLED;
		}

        public enum CHK_USE_SYSTEMFONT_ON_DOC_STATE
        {
            DISABLED =-1,
            FALSE =0,
            TRUE =1
        }

        public CHK_USE_SYSTEMFONT_ON_DOC_STATE UseSystemfontOnDoc
        {
            get { return useSystemfontOnDoc; }
            set { useSystemfontOnDoc = value; }
        }

		public string NameString
		{
			get { return nameString; }
			set { nameString = value; }
		}
	

		public int TextHeight
		{
			get { return textHeight; }
			set { 
				textHeight = value;
				if (textHeight < MbeObjText.MIN_TEXT_HEIGHT) {
					textHeight = MbeObjText.MIN_TEXT_HEIGHT;
				} else if (textHeight > MbeObjText.MAX_TEXT_HEIGHT) {
					textHeight = MbeObjText.MAX_TEXT_HEIGHT;
				}
			}
		}

		public int LineWidth
		{
			get { return lineWidth; }
			set
			{
				lineWidth = value;
				if (lineWidth < MbeObjText.MIN_LINE_WIDTH) {
					lineWidth = MbeObjText.MIN_LINE_WIDTH;
				} else if (lineWidth > MbeObjText.MAX_LINE_WIDTH) {
					lineWidth = MbeObjText.MAX_LINE_WIDTH;
				}
			}
		}

		private void FormLoad(object sender, EventArgs e)
		{
			double min;
			double max;
			colorTextBack = textBoxLineWidth.BackColor;

			min = MbeObjText.MIN_LINE_WIDTH / 10000.0F;
			max = MbeObjText.MAX_LINE_WIDTH / 10000.0F;
			labelWidthRange.Text = String.Format("({0:##0.0###} - {1:##0.0###}mm)", min, max);
			min = MbeObjText.MIN_TEXT_HEIGHT / 10000.0F;
			max = MbeObjText.MAX_TEXT_HEIGHT / 10000.0F;
			labelHeightRange.Text = String.Format("({0:##0.0###} - {1:##0.0###}mm)", min, max);
            SetValueToCtrl();
#if !MONO
            Properties.Settings.Default.Reload();
#endif
            LoadMyStandard();
            buttonDelete.Enabled = false;
            buttonUp.Enabled = false;   //20111008
            buttonDown.Enabled = false; //20111008


			textBoxText.Text = nameString;

            chk_UseSystemfontOnDoc.Checked = (useSystemfontOnDoc != CHK_USE_SYSTEMFONT_ON_DOC_STATE.FALSE);
            chk_UseSystemfontOnDoc.Enabled = (useSystemfontOnDoc != CHK_USE_SYSTEMFONT_ON_DOC_STATE.DISABLED);            

		}


		private void OnOK(object sender, EventArgs e)
		{
            DoOnOK();
		}

		private string nameString;
		private int textHeight;
		private int lineWidth;
        private CHK_USE_SYSTEMFONT_ON_DOC_STATE useSystemfontOnDoc;

    

		private void OnTextBoxHeightChanged(object sender, EventArgs e)
		{
			textBoxHeight.BackColor = colorTextBack;
		}

		private void OnTextBoxLineWidthChanged(object sender, EventArgs e)
		{
			textBoxLineWidth.BackColor = colorTextBack;
		}

		private Color colorTextBack;

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (!CheckInputValue()) return;

            TextInfo newInfo = new TextInfo();

            newInfo.LineWidth = lineWidth;
            newInfo.TextHeight = textHeight;
            
            int count = listBoxMyStandard.Items.Count;
            bool existFlag = false;
            for (int i = 0; i < count; i++) {
                if (newInfo.Equals((TextInfo)(listBoxMyStandard.Items[i]))) {
                    existFlag = true;
                    break;
                }
            }
            if (existFlag) return;


            int index = listBoxMyStandard.SelectedIndex;
            if (index < 0) index = 0;
            listBoxMyStandard.Items.Insert(index, newInfo);
            listBoxMyStandard.SelectedIndex = -1;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int index = listBoxMyStandard.SelectedIndex;
            if (index < 0) {
                buttonDelete.Enabled = false;
                return;
            }

            listBoxMyStandard.Items.RemoveAt(index);
        }

        private void listBoxMyStandard_DoubleClick(object sender, EventArgs e)
        {
            if (textBoxText.Text.Length > 0) {
                DoOnOK();
            }
        }

        private void listBoxMyStandard_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBoxMyStandard.SelectedIndex;
            if (index < 0) {
                buttonDelete.Enabled = false;
                buttonUp.Enabled = false;   //20111008
                buttonDown.Enabled = false; //20111008
                return;
            }
            buttonDelete.Enabled = true;

            buttonUp.Enabled = (index > 0);                                                 //20111008
            buttonDown.Enabled = ((listBoxMyStandard.Items.Count - 1) > index);             //20111008

            LineWidth = ((TextInfo)(listBoxMyStandard.Items[index])).LineWidth;
            TextHeight = ((TextInfo)(listBoxMyStandard.Items[index])).TextHeight;
            SetValueToCtrl();
        }

        private void SetValueToCtrl()
        {
            textBoxLineWidth.Text = String.Format("{0:##0.0###}", lineWidth / 10000.0);
            textBoxHeight.Text = String.Format("{0:##0.0###}", textHeight / 10000.0);
        }

        private void LoadMyStandard()
        {
            //MyStandard?l?????[?h
            string strMyStdInfo = Properties.Settings.Default.MyStandardTextString;
            MbeMyStd[] myStdInfoArray = MbeMyStd.LoadMyStdInfoArray(strMyStdInfo);

            foreach (MbeMyStd info in myStdInfoArray) {
                listBoxMyStandard.Items.Add((TextInfo)info);
            }

        }

        private void SaveMyStandard()
        {
            int count = listBoxMyStandard.Items.Count;
            TextInfo[] myStdInfoArray = new TextInfo[count];
            for (int i = 0; i < count; i++) {
                myStdInfoArray[i] = (TextInfo)(listBoxMyStandard.Items[i]);
            }
            Properties.Settings.Default.MyStandardTextString = MbeMyStd.SaveMyStdInfoArray(myStdInfoArray);

        }


        private bool CheckInputValue()
        {
            double _width;
            double _height;
            int n;
            bool err = false;



            _width = LengthString.ToDouble(textBoxLineWidth.Text, -1.0);
            _height = LengthString.ToDouble(textBoxHeight.Text, -1.0);

            n = (int)(_width * 10000);
            LineWidth = n;
            if (LineWidth != n) {
                textBoxLineWidth.BackColor = MbeColors.ColorInputErr;
                err = true;
            }

            n = (int)(_height * 10000);
            TextHeight = n;
            if (TextHeight != n) {
                textBoxHeight.BackColor = MbeColors.ColorInputErr;
                err = true;
            }


            if (err) {
                return false;
            }

            return true;
        }

        private void DoOnOK()
        {
            if (!CheckInputValue()) return;
            SaveMyStandard();
            NameString = textBoxText.Text;
            Properties.Settings.Default.Save();
            DialogResult = DialogResult.OK;
            if (useSystemfontOnDoc != CHK_USE_SYSTEMFONT_ON_DOC_STATE.DISABLED){
                useSystemfontOnDoc = (chk_UseSystemfontOnDoc.Checked ? CHK_USE_SYSTEMFONT_ON_DOC_STATE.TRUE : CHK_USE_SYSTEMFONT_ON_DOC_STATE.FALSE);
            }
        }

        // to change the order of my standard 20111008
        private void buttonUp_Click(object sender, EventArgs e)
        {
            int index = listBoxMyStandard.SelectedIndex;
            if (index <= 0) {
                buttonUp.Enabled = false;
                return;
            }

            TextInfo myStdInfo = (TextInfo)(listBoxMyStandard.Items[index]);
            listBoxMyStandard.Items.RemoveAt(index);
            index--;
            listBoxMyStandard.Items.Insert(index, myStdInfo);
            listBoxMyStandard.SelectedIndex = index;
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            int index = listBoxMyStandard.SelectedIndex;
            if ((listBoxMyStandard.Items.Count - 1) <= index) {
                buttonDown.Enabled = false;
                return;
            }
            TextInfo myStdInfo = (TextInfo)(listBoxMyStandard.Items[index]);
            listBoxMyStandard.Items.RemoveAt(index);
            index++;
            listBoxMyStandard.Items.Insert(index, myStdInfo);
            listBoxMyStandard.SelectedIndex = index;

        }


	
	}
}