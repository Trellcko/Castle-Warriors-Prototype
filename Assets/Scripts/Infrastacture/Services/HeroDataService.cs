using System.Collections.Generic;
using System.Linq;
using CastleWarriors.Assets.Scripts.Constants;
using CastleWarriors.GameLogic.Hero.Data;
using UnityEngine;

namespace CastleWarriors.Infastructure.Services
{
    public class HeroDataService : IHeroDataService
    {
        private Dictionary<HeroType, HeroData> _heroDataStorage;
        
        public void LoadAllData()
        {
            _heroDataStorage = Resources.LoadAll<HeroData>(AssetsNames.HeroData).ToDictionary(x=>x.HeroType, x=>x);
        }

        public HeroData ForHero(HeroType heroType) => 
            _heroDataStorage.GetValueOrDefault(heroType);
    }
}
