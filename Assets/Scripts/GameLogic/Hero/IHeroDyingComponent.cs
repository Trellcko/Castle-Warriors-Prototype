using CastleWarriors.GameLogic.Hero;

namespace CastleWarriors.GameLogic.Dying
{
    public interface IHeroDyingComponent : IHeroComponent
    {
        void Die();
    }
}