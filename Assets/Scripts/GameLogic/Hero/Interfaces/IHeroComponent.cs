using CastleWarriors.GameLogic.Data;

namespace CastleWarriors.GameLogic
{
    public interface IHeroComponent
    {
        bool IsActive { get; set; }
        void Init(HeroData hero);
    }
}