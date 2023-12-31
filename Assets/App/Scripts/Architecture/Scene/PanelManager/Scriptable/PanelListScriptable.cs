﻿using App.Scripts.UI.PanelControllers.Base;
using UnityEngine;

namespace App.Scripts.Architecture.Scene.PanelManager.Scriptable
{
    [CreateAssetMenu(fileName = "Panel List", menuName = "Scriptable Object/Base/Panel Config", order = 0)]
    public class PanelListScriptable : ScriptableObject
    {
        public LocalizedPanelController[] panelList;
    }
}