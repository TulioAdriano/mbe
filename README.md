# MBE
Fork of MBE PCB editor by SUIGYODO

## About this repository
MBE (Minimal Board Editor) is a PCB board editor that is light weight, portable and easy to use. It has been available for many years from SUIGYODO website, but I couldn't find the code on GitHub so I decided to uplaod it as a "fork" of the original code, along with my changes. 

## Changes in this version
As I use this software, changes were implemented to add some quality of life improvements and some extension to its capabilities.
- Allows boards up to 50x50 cm.
- Exports Gerber files using standard Gerber extensions.
- Allows adding a node by middle clicking over a polygon.
- Added shortcuts for DRC (Ctrl+D), Polygon view (Ctrl+P) and Polygon update (Ctrl+U).
- Added Set Grid Pitch context menu for right click over the editing area.

## Future
If I make more changes they'll be updated here. There's no formal plan. 

## Credits
SUIGYODO  Hitoshi Okada

http://www.suigyodo.com/online/e

## License
This program is distributed under the 2 clause BSD license.

## Disclaimer
This program is provided as is. Neither I or the original author assume any responsibility for issues this program causes on your system, or issues resulting from the generated gerber files that get sent to manufacture. Please verify your Gerber files before sending to manufacture in order to assert that they don't have any unexpected shorts. These files can be verified with a Gerber viewer, and there are many of those available for free on the Inteneret.
