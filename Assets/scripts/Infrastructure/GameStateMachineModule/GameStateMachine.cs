﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.GameStateMachineModule.States;

namespace Infrastructure.GameStateMachineModule
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type, IGameState> _states;
        private IGameState _currentState;

        public GameStateMachine()
        {
            _states = new Dictionary<Type, IGameState>
            {
                { typeof(BootstrapState), new BootstrapState() },
                { typeof(MainMenuState), new MainMenuState() }
            };
        }

        public async Task Enter<T>() where T : IGameState
        {
            if(_currentState != null)
                await _currentState?.Exit()!;

            _currentState = _states[typeof(T)];
            await _currentState.Enter();
        }
    }
}