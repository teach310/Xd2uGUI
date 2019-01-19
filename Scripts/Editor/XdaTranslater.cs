using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Xd2uGUI {
    public class XdaTranslater {

        public GameObject CreatePrefab (Xda xda) {
            IXdArtboardTranslater artboardTranslater = new DefaultXdArtboardTranslater();
            IXdRectangleTranslater rectangleTranslater = new DefaultXdRectangleTranslater();
            IXdTextTranslater textTranslater = new DefaultXdTextTranslater();
            IXdGroupTranslater groupTranslater = new DefaultXdGroupTranslater();

             // アートボード
            GameObject artboard = artboardTranslater.CreateGameObjectByArtboard(xda.artboard);
            
            var nodeTree = new Dictionary<Node, string> ();
            var siblingIndexMap = new Dictionary<Node, int>();
            var goMap = new Dictionary<string, GameObject> ();
            goMap.Add (xda.artboard.guid, artboard);
            // イメージ
            for (int i = 0; i < xda.rectangleList.Count; i++) {
                var node = xda.rectangleList[i];
                nodeTree.Add (node, node.parentGuid);
                siblingIndexMap.Add(node, node.siblingIndex);
                var go = rectangleTranslater.CreateGameObjectByRectangle (node, artboard);
                goMap.Add (node.guid, go);
            }

            // テキスト
            for (int i = 0; i < xda.textList.Count; i++) {
                var node = xda.textList[i];
                nodeTree.Add (node, node.parentGuid);
                siblingIndexMap.Add(node, node.siblingIndex);
                var go = textTranslater.CreateGameObjectByText (node, artboard);
                goMap.Add (node.guid, go);
            }

            // グループ
            for (int i = 0; i < xda.groupList.Count; i++) {
                var node = xda.groupList[i];
                nodeTree.Add (node, node.parentGuid);
                siblingIndexMap.Add(node, node.siblingIndex);
                var go = groupTranslater.CreateGameObjectByGroup (xda.groupList[i], artboard);
                goMap.Add (node.guid, go);
            }

            // 親子関係構築
            foreach (var kvp in nodeTree) {
                goMap[kvp.Key.guid].transform.SetParent (goMap[kvp.Value].transform);
            }

            // SiblingIndex設定
            foreach (var kvp in siblingIndexMap) { 
                goMap[kvp.Key.guid].transform.SetSiblingIndex (kvp.Value);
            }
            return artboard;
        }
    }
}