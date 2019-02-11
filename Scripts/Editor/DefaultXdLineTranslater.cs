using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Xd2uGUI
{
    public class DefaultXdLineTranslater : IXdLineTranslater
    {
        public GameObject CreateGameObjectByLine(XdLine xdLine, GameObject artboard)
        {
            GameObject go = new GameObject (xdLine.name, typeof (RectTransform));
            go.transform.SetParent (artboard.transform);
            var rectTran = go.GetComponent<RectTransform> ();
            var rect = new Rect (xdLine.artboardPosX, -xdLine.artboardPosY, 10, 10);
            rectTran.anchorMin = new Vector2 (0, 1);
            rectTran.anchorMax = new Vector2 (0, 1);
            rectTran.pivot = new Vector2 (0, 1);
            rectTran.anchoredPosition = rect.position;
            rectTran.sizeDelta = rect.size;
            return go;
        }

    }
}