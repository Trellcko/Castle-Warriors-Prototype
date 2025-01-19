using CastleWarriors.GameLogic.Hero;
using UnityEngine;

namespace CastleWarriors.Infastructure.Factory
{
    public interface IHeroFactory
    {
        HeroFacade CreateHero(HeroSpawnData heroSpawnData, HeroType heroType);
    }
}

public enum HeroType
{
    Swordsman = 0
}