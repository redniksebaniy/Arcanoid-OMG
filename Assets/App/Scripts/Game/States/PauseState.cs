﻿using System.Threading.Tasks;
using App.Scripts.Architecture.Scene.PanelManager;
using App.Scripts.Libs.Patterns.StateMachine;
using App.Scripts.Libs.Patterns.Service.Container;
using App.Scripts.UI.PanelControllers.Game.Pause;

namespace App.Scripts.Game.States
{
    public class PauseState : GameState
    {
        private readonly PanelManager _panelManager;
        
        public PauseState(GameStateMachine machine, ServiceContainer container) : base(machine, container)
        {
            _panelManager = container.GetService<PanelManager>();
        }
        
        public override Task OnEnterState()
        {
            var panel = _panelManager.GetPanel<PausePanelController>();
            _panelManager.AddActive(panel);
            
            var task = panel.ShowPanel();
            return task;
        }

        public override async Task OnExitState()
        {
            var panel = _panelManager.RemoveActive();
            var task = panel.HidePanel();
            await task;
        }
    }
}