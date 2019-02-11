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
            IXdEllipseTranslater ellipseTranslater = new DefaultXdEllipseTranslater();
            IXdLineTranslater lineTranslater = new DefaultXdLineTranslater();
            IXdPathTranslater pathTranslater = new DefaultXdPathTranslater();
            IXdSymbolInstanceTranslater symbolInstanceTranslater = new DefaultXdSymbolInstanceTranslater();
            IXdLinkedGraphicTranslater linkedGraphicTranslater = new DefaultXdLinkedGraphicTranslater();

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

            // Ellipse
            for (int i = 0; i < xda.ellipseList.Count; i++) {
                var node = xda.ellipseList[i];
                nodeTree.Add (node, node.parentGuid);
                siblingIndexMap.Add(node, node.siblingIndex);
                var go = ellipseTranslater.CreateGameObjectByEllipse (xda.ellipseList[i], artboard);
                goMap.Add (node.guid, go);
            }

            // Line
            for (int i = 0; i < xda.lineList.Count; i++) {
                var node = xda.lineList[i];
                nodeTree.Add (node, node.parentGuid);
                siblingIndexMap.Add(node, node.siblingIndex);
                var go = lineTranslater.CreateGameObjectByLine (xda.lineList[i], artboard);
                goMap.Add (node.guid, go);
            }

            // Path
             for (int i = 0; i < xda.pathList.Count; i++) {
                var node = xda.pathList[i];
                nodeTree.Add (node, node.parentGuid);
                siblingIndexMap.Add(node, node.siblingIndex);
                var go = pathTranslater.CreateGameObjectByPath (xda.pathList[i], artboard);
                goMap.Add (node.guid, go);
            }

            // SymbolInstance
            for (int i = 0; i < xda.symbolInstanceList.Count; i++) {
                var node = xda.symbolInstanceList[i];
                nodeTree.Add (node, node.parentGuid);
                siblingIndexMap.Add(node, node.siblingIndex);
                var go = symbolInstanceTranslater.CreateGameObjectBySymbolInstance (xda.symbolInstanceList[i], artboard);
                goMap.Add (node.guid, go);
            }

            // LinkedGraphic
            for (int i = 0; i < xda.linkedGraphicList.Count; i++) {
                var node = xda.linkedGraphicList[i];
                nodeTree.Add (node, node.parentGuid);
                siblingIndexMap.Add(node, node.siblingIndex);
                var go = linkedGraphicTranslater.CreateGameObjectByLinkedGraphic (xda.linkedGraphicList[i], artboard);
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