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
    }

}