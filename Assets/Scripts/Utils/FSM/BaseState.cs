namespace CastleWarriors.Utils.FSM 
{
    public abstract class BaseState : StateZero
    {
        protected BaseState(StateMachine machine) : base(machine)
        {
            
        }

        public virtual void Enter() { }

    }
}

