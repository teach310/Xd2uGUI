# Xd2uGUI
AdobeXDのアートボードをUnityのプレハブとして生成する

![xd2ugui](https://user-images.githubusercontent.com/16421323/51428703-20811980-1c4a-11e9-9ff2-7de890f9b040.jpg)

# XDA

xda is json format like this.

```SampleScreen.xda
{
	"artboard": {
		"guid": "7f3c0811-2209-466b-a600-cff1b2b48a32",
		"component": "Artboard",
		"name": "SampleScreen",
		"width": 667,
		"height": 375
	},
	"rectangleList": [
		{
			"guid": "3188e88d-7cd7-43c2-afb2-8ccc7b8736fb",
			"component": "Rectangle",
			"name": "長方形 10",
			"parentGuid": "7f3c0811-2209-466b-a600-cff1b2b48a32",
			"siblingIndex": 0,
			"artboardPosX": 36,
			"artboardPosY": 36,
			"width": 595,
			"height": 303,
			"color": "#fcfaf2"
		},
		{
			"guid": "b1da4c69-07d8-4307-8ce4-4b5747b250df",
			"component": "Rectangle",
			"name": "dog",
			"parentGuid": "7f3c0811-2209-466b-a600-cff1b2b48a32",
			"siblingIndex": 1,
			"artboardPosX": 290,
			"artboardPosY": 50,
			"width": 87,
			"height": 91,
			"color": "#FFF"
		},
		{
			"guid": "99545c77-3746-4997-9a9f-2d5189485e9d",
			"component": "Rectangle",
			"name": "長方形 4",
			"parentGuid": "75182f7e-a658-4368-8a43-f66cdc69d274",
			"siblingIndex": 0,
			"artboardPosX": 0,
			"artboardPosY": 0,
			"width": 36,
			"height": 375,
			"color": "#fb32bb"
		},
		{
			"guid": "85721e33-f4f1-4755-b427-7ea8fe871259",
			"component": "Rectangle",
			"name": "長方形 5",
			"parentGuid": "75182f7e-a658-4368-8a43-f66cdc69d274",
			"siblingIndex": 1,
			"artboardPosX": 36,
			"artboardPosY": 0,
			"width": 290,
			"height": 36,
			"color": "#fb32bb"
		},
		{
			"guid": "de43011f-5315-4813-9f3e-507022b1d8b7",
			"component": "Rectangle",
			"name": "長方形 6",
			"parentGuid": "75182f7e-a658-4368-8a43-f66cdc69d274",
			"siblingIndex": 2,
			"artboardPosX": 631,
			"artboardPosY": 0,
			"width": 36,
			"height": 375,
			"color": "#262525"
		},
		{
			"guid": "dac96a62-9cce-4ce4-b9fc-5f9328edce56",
			"component": "Rectangle",
			"name": "長方形 7",
			"parentGuid": "75182f7e-a658-4368-8a43-f66cdc69d274",
			"siblingIndex": 3,
			"artboardPosX": 28,
			"artboardPosY": 339,
			"width": 306,
			"height": 36,
			"color": "#fb32bb"
		},
		{
			"guid": "67262ccb-66f1-4624-959a-c79b3d5b24c2",
			"component": "Rectangle",
			"name": "長方形 8",
			"parentGuid": "75182f7e-a658-4368-8a43-f66cdc69d274",
			"siblingIndex": 4,
			"artboardPosX": 326,
			"artboardPosY": 0,
			"width": 305,
			"height": 36,
			"color": "#262525"
		},
		{
			"guid": "398ddfa1-88c3-4121-9867-909b426fdf91",
			"component": "Rectangle",
			"name": "長方形 9",
			"parentGuid": "75182f7e-a658-4368-8a43-f66cdc69d274",
			"siblingIndex": 5,
			"artboardPosX": 326,
			"artboardPosY": 339,
			"width": 312,
			"height": 36,
			"color": "#262525"
		}
	],
	"groupList": [
		{
			"guid": "75182f7e-a658-4368-8a43-f66cdc69d274",
			"component": "Group",
			"name": "frame",
			"parentGuid": "7f3c0811-2209-466b-a600-cff1b2b48a32",
			"siblingIndex": 2,
			"artboardPosX": 0,
			"artboardPosY": 0
		},
		{
			"guid": "59a7bb44-cb91-48b5-a26f-a168f8cc2570",
			"component": "Group",
			"name": "title",
			"parentGuid": "7f3c0811-2209-466b-a600-cff1b2b48a32",
			"siblingIndex": 4,
			"artboardPosX": 113,
			"artboardPosY": 132
		}
	],
	"textList": [
		{
			"guid": "b1d2be85-2069-4a63-8178-4afff019bbed",
			"component": "Text",
			"name": "2",
			"parentGuid": "7f3c0811-2209-466b-a600-cff1b2b48a32",
			"siblingIndex": 3,
			"artboardPosX": 298,
			"artboardPosY": 132,
			"text": "2",
			"fontSize": 100,
			"color": "#fb32bb",
			"charSpacing": 1,
			"lineSpacing": 18,
			"align": "center"
		},
		{
			"guid": "1ac69d04-4974-4284-bd89-f642ee6bb75e",
			"component": "Text",
			"name": "Xd",
			"parentGuid": "59a7bb44-cb91-48b5-a26f-a168f8cc2570",
			"siblingIndex": 0,
			"artboardPosX": 113,
			"artboardPosY": 132,
			"text": "Xd",
			"fontSize": 100,
			"color": "#fb32bb",
			"charSpacing": 1,
			"lineSpacing": 18,
			"align": "center"
		},
		{
			"guid": "329a6f10-e016-4010-a732-888ad8adcd14",
			"component": "Text",
			"name": "uGUI",
			"parentGuid": "59a7bb44-cb91-48b5-a26f-a168f8cc2570",
			"siblingIndex": 1,
			"artboardPosX": 379,
			"artboardPosY": 132,
			"text": "uGUI",
			"fontSize": 100,
			"color": "#262525",
			"charSpacing": 1,
			"lineSpacing": 18,
			"align": "center"
		},
		{
			"guid": "b6277826-5cb3-453d-a111-b36625159373",
			"component": "Text",
			"name": "2_1",
			"parentGuid": "59a7bb44-cb91-48b5-a26f-a168f8cc2570",
			"siblingIndex": 2,
			"artboardPosX": 298,
			"artboardPosY": 132,
			"text": "2",
			"fontSize": 100,
			"color": "#fb32bb",
			"charSpacing": 1,
			"lineSpacing": 18,
			"align": "center"
		},
		{
			"guid": "dc974149-fb98-4393-b574-1847f4b2a4cb",
			"component": "Text",
			"name": "2",
			"parentGuid": "59a7bb44-cb91-48b5-a26f-a168f8cc2570",
			"siblingIndex": 3,
			"artboardPosX": 306,
			"artboardPosY": 132,
			"text": "2",
			"fontSize": 100,
			"color": "#262525",
			"charSpacing": 1,
			"lineSpacing": 18,
			"align": "center"
		}
	]
}
```

# How to use

## Download AdobeXD Plugin

[XDAExporter1_0_0](https://www.dropbox.com/s/jg4iqvwb8iymn6x/XDAExporter1_0_0.xdx?dl=0)

Download from link and install then you can use XDAExporter in Adobe XD.
currently this plugin has bug.

```
// Completed
Artboard
Rectangle
Text
Group

// Progress
Ellipse
Line
Path
BooleanGroup
SymbolInstance
RepeatGrid
LinkedGraphic
```

If there is any progress node in your artboard, this plugin will crash.
I will fix and release.
And I will create new remort repository to publish xda_exporter src after fix.

## Export artboard as xda in AdobeXD

![icon](https://user-images.githubusercontent.com/16421323/51436369-04738b80-1ccf-11e9-96d8-ec786017013f.png)

![2019-01-20 16 14 58](https://user-images.githubusercontent.com/16421323/51436364-f0c82500-1cce-11e9-9582-e672ff2861a4.jpg)

I will write detail later

## Import xda
only import xda file.
you can see prefab next to xda

# License
This library is under the MIT License.
