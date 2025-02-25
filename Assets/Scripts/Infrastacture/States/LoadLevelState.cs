﻿using CastleWarriors.UI;
using CastleWarriors.Utils.FSM;

namespace CastleWarriors.Infastructure.Services.States
{
    public class LoadLevelState : BaseState
    {
        private readonly ILoadingCurtain _loadingCurtain;
        private readonly ISceneLoader _sceneLoader;

        public LoadLevelState(ILoadingCurtain loadingCurtain, ISceneLoader sceneLoader, StateMachine stateMachine) : base(stateMachine)
        {
            _loadingCurtain = loadingCurtain;
            _sceneLoader = sceneLoader;
        }

        public override void Enter()
        {
            _loadingCurtain.Show();
            _sceneLoader.Load(SceneName.GameScene.ToString(), GoToEmptyState);
        }

        private void GoToEmptyState()
        {
            _loadingCurtain.Hide();
            GoToState<EmptyState>();
        }
    }
}
