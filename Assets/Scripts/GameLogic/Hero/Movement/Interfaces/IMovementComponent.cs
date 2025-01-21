namespace CastleWarriors.GameLogic.Movement
{
    public interface IMovementComponent : IHeroComponent
    {
        void StopMoving();
        void ResumeMoving();
    }
}