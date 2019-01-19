using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.IO;

namespace Xd2uGUI
{
    public class DefaultXdRectangleTranslater : IXdRectangleTranslater
    {
        public GameObject CreateGameObjectByRectangle(XdRectangle xdRect, GameObject artboard)
        {
            GameObject go = new GameObject (xdRect.name);
            var img = go.AddComponent<Image> ();
            go.transform.SetParent (artboard.transform);
            var imgRectTran = go.GetComponent<RectTransform> ();
            var imgRect = new Rect (xdRect.artboardPosX, -xdRect.artboardPosY, xdRect.width, xdRect.height);
            imgRectTran.anchorMin = new Vector2 (0, 1);
            imgRectTran.anchorMax = new Vector2 (0, 1);
            imgRectTran.pivot = new Vector2 (0, 1);
            imgRectTran.anchoredPosition = imgRect.position;
            imgRectTran.sizeDelta = imgRect.size;

            img.sprite = FindSprite (xdRect.name);
            Color newCol;
            img.color = ColorUtility.TryParseHtmlString (xdRect.color, out newCol) ? newCol : Color.white;
            return go;
        }

        Sprite FindSprite (string name) {
            var guids = AssetDatabase.FindAssets ($"{name} t:Sprite");
            if (guids.Length == 0)
                return null;
            var assetPaths = guids.Select (x => AssetDatabase.GUIDToAssetPath (x)).ToList ();
            var nameMatch = assetPaths.FirstOrDefault (x => Path.GetFileNameWithoutExtension (x) == name);
            var targetPath = !string.IsNullOrEmpty (nameMatch) ? nameMatch : assetPaths[0];
            return AssetDatabase.LoadAssetAtPath<Sprite> (targetPath);
        }
    }
}