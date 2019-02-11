using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Xd2uGUI
{
    public class DefaultXdSymbolInstanceTranslater : IXdSymbolInstanceTranslater
    {
        public GameObject CreateGameObjectBySymbolInstance(XdSymbolInstance xdSymbolInstance, GameObject artboard)
        {
            GameObject go = new GameObject (xdSymbolInstance.name, typeof (RectTransform));
            go.transform.SetParent (artboard.transform);
            var rectTran = go.GetComponent<RectTransform> ();
            var rect = new Rect (xdSymbolInstance.artboardPosX, -xdSymbolInstance.artboardPosY, 10, 10);
            rectTran.anchorMin = new Vector2 (0, 1);
            rectTran.anchorMax = new Vector2 (0, 1);
            rectTran.pivot = new Vector2 (0, 1);
            rectTran.anchoredPosition = rect.position;
            rectTran.sizeDelta = rect.size;
            return go;
        }

    }
}