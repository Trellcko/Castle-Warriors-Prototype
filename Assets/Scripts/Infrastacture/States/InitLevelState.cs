using CastleWarriors.Utils.FSM;

namespace CastleWarriors.Infastructure.Services
{
    public class InitLevelState : BaseStateWithPayLoad<IHeroDataService>
    {
        private IHeroDataService _heroDataService;


        public InitLevelState(StateMachine machine) : base(machine)
        {
            
        }

        public override void Enter(IHeroDataService dataService)
        {
            dataService.LoadAllData();
            GoToState<EmptyState>();
        }
    }
}