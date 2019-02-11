using System;
using System.Collections;
using System.Collections.Generic;

namespace Xd2uGUI {

    public enum XdComponent {
        Artboard,
        Rectangle,
        Text,
        Group,
        Ellipse,
        Line,
        Path,
        SymbolInstance,
        LinkedGraphic
    }

    [System.Serializable]
    public class Xda {
        public XdArtboard artboard;
        public List<XdRectangle> rectangleList;
        public List<XdText> textList;
        public List<XdGroup> groupList;
        public List<XdEllipse> ellipseList;
        public List<XdLine> lineList;
        public List<XdPath> pathList;
        public List<XdSymbolInstance> symbolInstanceList;
        public List<XdLinkedGraphic> linkedGraphicList;
    }

    [System.Serializable]
    public class Node {
        public string guid;
        public string component;
        public string name;

        XdComponent ToXdComponent (string componentName) {
            switch (componentName) {
                case "Artboard":
                    return XdComponent.Artboard;
                case "Rectangle":
                    return XdComponent.Rectangle;
                case "Text":
                    return XdComponent.Text;
                case "Ellipse":
                    return XdComponent.Ellipse;
                case "Line":
                    return XdComponent.Line;
                case "Path":
                    return XdComponent.Path;
                case "SymbolInstance":
                    return XdComponent.SymbolInstance;
                case "LinkedGraphic":
                    return XdComponent.LinkedGraphic;
                case "Group":
                default:
                    return XdComponent.Group;
            }
        }
    }

    [System.Serializable]
    public class XdArtboard : Node{
        public int width;
        public int height;
    }

    [System.Serializable]
    public class XdRectangle : Node{
        public string parentGuid;
        public int siblingIndex;
        public float artboardPosX;
        public float artboardPosY;
        public int width;
        public int height;
        public string color;
    }

    [System.Serializable]
    public class XdText : Node{
        public string parentGuid;
        public int siblingIndex;
        public float artboardPosX;
        public float artboardPosY;
        public string text;
        public int fontSize;
        public string color;
        public string charSpacing; // 未使用
        public string lineSpacing; // pixel 未使用
        public string align; // 未使用
    }

    [System.Serializable]
    public class XdGroup : Node{
        public string parentGuid;
        public int siblingIndex;
        public float artboardPosX;
        public float artboardPosY;
    }

    [System.Serializable]
    public class XdEllipse : Node{
        public string parentGuid;
        public int siblingIndex;
        public float artboardPosX;
        public float artboardPosY;
        public int width;
        public int height;
        public string color;
        public float radiusX;
        public float radiusY;
    }

    [System.Serializable]
    public class XdLine : Node{
        public string parentGuid;
        public int siblingIndex;
        public float artboardPosX;
        public float artboardPosY;
        public int width;
        public int height;
        public string color;
        public float lineWidth;
        public float startPosX;
        public float startPosY;
        public float endPosX;
        public float endPosY;
    }    

    [System.Serializable]
    public class XdPath : Node{
        public string parentGuid;
        public int siblingIndex;
        public float artboardPosX;
        public float artboardPosY;
        public int width;
        public int height;
        public string color;
        public string pathData;
    }

    [System.Serializable]
    public class XdSymbolInstance : Node{
        public string parentGuid;
        public int siblingIndex;
        public float artboardPosX;
        public float artboardPosY;
        public int width;
        public int height;
    }

    [System.Serializable]
    public class XdLinkedGraphic : Node{
        public string parentGuid;
        public int siblingIndex;
        public float artboardPosX;
        public float artboardPosY;
        public int width;
        public int height;
    }
}