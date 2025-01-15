namespace CastleWarriors.GameLogic.Hero.Movement
{
    public interface IMovementComponent : IHeroComponent
    {
        void StopMoving();
        void ResumeMoving();
    }
}