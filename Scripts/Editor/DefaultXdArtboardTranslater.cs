using UnityEngine;

namespace Xd2uGUI
{
    public class DefaultXdArtboardTranslater : IXdArtboardTranslater
    {
        public GameObject CreateGameObjectByArtboard(XdArtboard artboard)
        {
            GameObject go = new GameObject (artboard.name);
            var canvas = go.AddComponent<Canvas> ();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            return go;
        }
    }
}