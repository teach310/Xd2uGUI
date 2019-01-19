using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Xd2uGUI
{
    public class DefaultXdTextTranslater : IXdTextTranslater
    {
        public GameObject CreateGameObjectByText(XdText xdText, GameObject artboard)
        {
            GameObject go = new GameObject (xdText.name);
            var label = go.AddComponent<Text> ();
            go.transform.SetParent (artboard.transform);
            var rectTran = go.GetComponent<RectTransform> ();
            var rect = new Rect (xdText.artboardPosX, -xdText.artboardPosY, 10, 10);
            rectTran.anchorMin = new Vector2 (0, 1);
            rectTran.anchorMax = new Vector2 (0, 1);
            rectTran.pivot = new Vector2 (0, 1);
            rectTran.anchoredPosition = rect.position;
            label.font = Resources.GetBuiltinResource (typeof (Font), "Arial.ttf") as Font;
            label.fontSize = xdText.fontSize;
            label.text = xdText.text;
            rectTran.sizeDelta = new Vector2 (label.preferredWidth, label.preferredHeight);
            Color newCol;
            label.color = ColorUtility.TryParseHtmlString (xdText.color, out newCol) ? newCol : Color.white;
            return go;
        }

    }
}