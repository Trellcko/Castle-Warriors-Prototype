using CastleWarriors.GameLogic.Data;

namespace CastleWarriors.Infastructure.Services
{
    public interface IHeroDataService
    {
        void LoadAllData();
        HeroData ForHero(HeroType heroType);
    }
}