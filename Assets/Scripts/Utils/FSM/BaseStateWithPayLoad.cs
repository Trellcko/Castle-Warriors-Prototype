namespace CastleWarriors.Utils.FSM
{
    public abstract class BaseStateWithPayLoad<TPayLoad> : StateZero
    {
        protected BaseStateWithPayLoad(StateMachine machine) : base(machine)
        {
            
        }

        public virtual void Enter(TPayLoad payLoad) { }
    }
}