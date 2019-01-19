using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEditor.Experimental.AssetImporters;
using UnityEngine;
using UnityEngine.UI;

namespace Xd2uGUI {
    [ScriptedImporter (1, "xda")]
    public class XdaImporter : ScriptedImporter {
        public override void OnImportAsset (AssetImportContext ctx) {
            string text = File.ReadAllText (ctx.assetPath);
            Xda xda = null;
            try {
                xda = JsonUtility.FromJson<Xda> (text);
            } catch (System.Exception ex) {
                throw ex;
            }

            // 以下だとプレハブがソートされてしまうバグがあるため新しいプレハブとして生成
            // ctx.AddObjectToAsset (xda.artboard.guid, artboard);
            // ctx.SetMainObject (artboard);

            var artboard = new XdaTranslater ().CreatePrefab (xda);
            PrefabUtility.SaveAsPrefabAsset(artboard, ctx.assetPath.Replace("xda", "prefab"));
            GameObject.DestroyImmediate(artboard);
        }

        GameObject CreateCanvas (Xda xda) {
            // アートボード
            GameObject artboard = new GameObject (xda.artboard.name);
            var canvas = artboard.AddComponent<Canvas> ();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            var xdRect = xda.rectangleList[0];
            var nodeTree = new Dictionary<Node, string> ();
            var goMap = new Dictionary<string, GameObject> ();
            goMap.Add (xda.artboard.guid, artboard);
            // イメージ
            for (int i = 0; i < xda.rectangleList.Count; i++) {
                var node = xda.rectangleList[i];
                nodeTree.Add (node, node.parentGuid);
                var go = CreateImage (node, artboard);
                goMap.Add (node.guid, go);
            }

            // テキスト
            for (int i = 0; i < xda.textList.Count; i++) {
                var node = xda.textList[i];
                nodeTree.Add (node, node.parentGuid);
                var go = CreateText (node, artboard);
                goMap.Add (node.guid, go);
            }

            // グループ
            for (int i = 0; i < xda.groupList.Count; i++) {
                var node = xda.groupList[i];
                nodeTree.Add (node, node.parentGuid);
                var go = CreateGroup (xda.groupList[i], artboard);
                goMap.Add (node.guid, go);
            }

            // 親子関係構築
            foreach (var kvp in nodeTree) {
                goMap[kvp.Key.guid].transform.SetParent (goMap[kvp.Value].transform);
            }
            return artboard;
        }

        GameObject CreateImage (XdRectangle xdRect, GameObject artboard) {
            GameObject goImg = new GameObject (xdRect.name);
            var img = goImg.AddComponent<Image> ();
            goImg.transform.SetParent (artboard.transform);
            var imgRectTran = GetOrAddComponent<RectTransform> (img.gameObject);
            var imgRect = new Rect (xdRect.artboardPosX, -xdRect.artboardPosY, xdRect.width, xdRect.height);
            imgRectTran.anchorMin = new Vector2 (0, 1);
            imgRectTran.anchorMax = new Vector2 (0, 1);
            imgRectTran.pivot = new Vector2 (0, 1);
            imgRectTran.anchoredPosition = imgRect.position;
            imgRectTran.sizeDelta = imgRect.size;

            img.sprite = FindSprite (xdRect.name);
            Color newCol;
            img.color = ColorUtility.TryParseHtmlString (xdRect.color, out newCol) ? newCol : Color.white;
            return goImg;
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

        // 位置は概ね一致するように
        // pixel位置を重視 alignによってpivotを決め、ある程度余裕を持たせる
        GameObject CreateText (XdText xdText, GameObject artboard) {
            GameObject go = new GameObject (xdText.name);
            var label = go.AddComponent<Text> ();
            go.transform.SetParent (artboard.transform);
            var rectTran = GetOrAddComponent<RectTransform> (go);
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

        GameObject CreateGroup (XdGroup xdGroup, GameObject artboard) {
            GameObject go = new GameObject (xdGroup.name, typeof (RectTransform));
            go.transform.SetParent (artboard.transform);
            var rectTran = GetOrAddComponent<RectTransform> (go);
            var rect = new Rect (xdGroup.artboardPosX, -xdGroup.artboardPosY, 10, 10);
            rectTran.anchorMin = new Vector2 (0, 1);
            rectTran.anchorMax = new Vector2 (0, 1);
            rectTran.pivot = new Vector2 (0, 1);
            rectTran.anchoredPosition = rect.position;
            rectTran.sizeDelta = rect.size;
            return go;
        }

        T GetOrAddComponent<T> (GameObject target)
        where T : Component {
            return target.GetComponent<T> () ?? target.AddComponent<T> ();
        }
    }

}