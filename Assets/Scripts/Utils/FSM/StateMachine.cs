using System;
using System.Collections.Generic;
using UnityEngine;

namespace CastleWarriors.Utils.FSM
{
    public class StateMachine
    {
        private Dictionary<Type, BaseState> _states;

        public BaseState CurrentState { get; private set; }

        public event Action<BaseState> StateExited;
        public event Action<BaseState> StateEntered;

        public StateMachine(params BaseState[] states)
        {
            _states = new Dictionary<Type, BaseState>();
            foreach (var state in states)
            {
                _states.Add(state.GetType(), state);
                state.StateCompleted += SetState;
            }
            _states.Add(typeof(EmptyState), new EmptyState());
            CurrentState = _states[typeof(EmptyState)];
        }
        public void Update()
        {
            CurrentState.CheckTransition();
            CurrentState.Update();
        }

        public void FixedUpdate()
        {
            CurrentState.FixedUpdate();
        }
        public void SetState<T>() where T : BaseState
        {
            SetState(typeof(T));
        }

        private void SetState(Type type)
        {
            if (_states.ContainsKey(type))
            {
                CurrentState?.Exit();
                StateExited?.Invoke(CurrentState);
                BaseState state = _states[type];
                CurrentState = state;
                CurrentState.Enter();
                StateEntered?.Invoke(CurrentState);
                return;
            }

            Debug.LogError("State: " + type.Name + " is not inclued");
        }
    }
}
