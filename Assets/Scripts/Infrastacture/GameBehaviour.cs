using CastleWarriors.Infastructure.Services.States;
using CastleWarriors.UI;
using CastleWarriors.Utils.FSM;
using Zenject;

namespace CastleWarriors.Infastructure.Services
{
    public class GameBehaviour : ITickable, IInitializable, IGameBehaviour
    {
        private StateMachine _stateMachine;
        private ISceneLoader _sceneLoader;
        private ILoadingCurtain _loadingCurtain;

        [Inject]
        private void Construct(ILoadingCurtain loadingCurtain, ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
            _loadingCurtain = loadingCurtain;
        }

        public void Initialize()
        {
            _stateMachine = new(
                new LoadLevelState(_loadingCurtain, _sceneLoader)
                );

            _stateMachine.SetState<LoadLevelState>();
        }

        public void Tick() => 
            _stateMachine.Update();
    }
}
