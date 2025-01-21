using CastleWarriors.GameLogic;
using CastleWarriors.Infastructure.Services.Factory.Data;
using UnityEngine;

namespace CastleWarriors.Infastructure.Services.Factory
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