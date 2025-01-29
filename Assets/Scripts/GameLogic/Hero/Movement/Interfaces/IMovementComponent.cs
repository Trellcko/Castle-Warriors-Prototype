namespace CastleWarriors.GameLogic.Movement
{
    public interface IMovementComponent : IHeroComponent
    {
        void StopMoving();
        void ResumeMoving();
        bool IsIdle { get; set; }
    }
}