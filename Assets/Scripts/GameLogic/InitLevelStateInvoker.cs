using CastleWarriors.Infastructure.Services;
using Zenject;

namespace CastleWarriors.GameLogic
{
    public class InitLevelStateInvoker : IInitializable
    {
        private IHeroDataService _heroDataService;
        private IGameBehaviour _gameBehaviour;

        [Inject]
        private void Construct(IHeroDataService heroDataService, IGameBehaviour gameBehaviour)
        {
            _heroDataService = heroDataService;
            _gameBehaviour = gameBehaviour;
        }
        
        public void Initialize()
        {
            _gameBehaviour.InitLevel(_heroDataService);
        }
    }
}