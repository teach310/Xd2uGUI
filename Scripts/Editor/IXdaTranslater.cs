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

    interface IXdEllipseTranslater
    {
        GameObject CreateGameObjectByEllipse(XdEllipse xdEllipse, GameObject artboard);
    }

    interface IXdLineTranslater
    {
        GameObject CreateGameObjectByLine(XdLine xdLine, GameObject artboard);
    }

    interface IXdPathTranslater
    {
        GameObject CreateGameObjectByPath(XdPath xdLinxdPath, GameObject artboard);
    }

    interface IXdSymbolInstanceTranslater
    {
        GameObject CreateGameObjectBySymbolInstance(XdSymbolInstance xdSymbolInstance, GameObject artboard);
    }

    interface IXdLinkedGraphicTranslater
    {
        GameObject CreateGameObjectByLinkedGraphic(XdLinkedGraphic xdLinkedGraphic, GameObject artboard);
    }
}
