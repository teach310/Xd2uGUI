using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Xd2uGUI
{
    interface IXdArtboardTranslater
    {
        GameObject CreateGameObjectByArtboard(XdArtboard artboard);
    }

    interface IXdRectangleTranslater
    {
        GameObject CreateGameObjectByRectangle(XdRectangle xdRect, GameObject artboard);
    }

    interface IXdTextTranslater
    {
        GameObject CreateGameObjectByText(XdText xdRect, GameObject artboard);
    }

    interface IXdGroupTranslater
    {
        GameObject CreateGameObjectByGroup(XdGroup xdGroup, GameObject artboard);
    }
}
