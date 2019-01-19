using System;
using System.Collections;
using System.Collections.Generic;

namespace Xd2uGUI {

    public enum XdComponent {
        Artboard,
        Rectangle,
        Text,
        Group
    }

    [System.Serializable]
    public class Xda {
        public XdArtboard artboard;
        public List<XdRectangle> rectangleList;
        public List<XdText> textList;
        public List<XdGroup> groupList;
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
}