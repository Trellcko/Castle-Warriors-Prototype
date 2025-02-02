using CastleWarriors.GameLogic.Hero.Data;

namespace CastleWarriors.GameLogic.Hero
{
    public interface IHeroComponent
    {
        void Enable();
        void Disable();
        bool IsActive { get; }
        void Init(HeroData hero);
    }
}