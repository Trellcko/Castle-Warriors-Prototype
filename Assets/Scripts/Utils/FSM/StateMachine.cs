using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace CastleWarriors.Utils.FSM
{
    public class StateMachine
    {
        private Dictionary<Type, StateZero> _states;

        private StateZero _currentState;

        public StateMachine(params StateZero[] states)
        {
            _states = new();
            foreach (StateZero state in states)
            {
                _states.Add(state.GetType(), state);
            }
            AddState(new EmptyState(this));
            _currentState = _states[typeof(EmptyState)];
        }

        public void AddState(params StateZero[] states)
        {
            foreach (StateZero state in states)
            {
                _states.Add(state.GetType(), state);
            }
        }
        
        public void Update()
        {
            _currentState.CheckTransition();
            _currentState.Update();
        }

        public void FixedUpdate()
        {
            _currentState.FixedUpdate();
        }
        public void SetState<T>() where T : BaseState
        {
            SetState(typeof(T), x=> ((BaseState)x).Enter());
        }

        public void SetState<T ,TPayload>(TPayload payload) where T : BaseStateWithPayLoad<TPayload>
        {
            SetState(typeof(T), x=> ((BaseStateWithPayLoad<TPayload>)x).Enter(payload));   
        }

        private void SetState(Type type, Action<StateZero> enterAction)
        {
            if (_states.ContainsKey(type))
            {
                ExitCurrentState();
                ChangeState(type, enterAction);
                return;
            }

            Debug.LogError("State: " + type.Name + " is not inclued");
        }

        private void ChangeState(Type type, Action<StateZero> enterAction)
        {
            StateZero state = _states[type];
            _currentState = state;
            enterAction(_currentState);
        }

        private void ExitCurrentState()
        {
            _currentState?.Exit();
        }
    }
}
