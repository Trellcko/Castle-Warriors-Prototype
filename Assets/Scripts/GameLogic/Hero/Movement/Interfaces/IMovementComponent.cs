namespace CastleWarriors.GameLogic.Hero
{
    public interface IMovementComponent : IHeroComponent
    {
        void StopMoving();
        void ResumeMoving();
        bool IsIdle { get; set; }
    }
}