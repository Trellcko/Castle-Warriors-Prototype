using CastleWarriors.GameLogic;
using CastleWarriors.GameLogic.Hero;
using CastleWarriors.GameLogic.Hero.Data;
using CastleWarriors.Infastructure.Services.AssetManagment;
using CastleWarriors.Infastructure.Services.Factory.Data;
using CastleWarriors.Utils;
using UnityEngine;
using Zenject;

namespace CastleWarriors.Infastructure.Services.Factory
{
    public class HeroFactory : IHeroFactory
    {
        private IAssetProvider _assetProvider;
        private IHeroDataService _heroDataService;
        
        [Inject]
        private void Construct(IAssetProvider assetProvider, IHeroDataService heroDataService)
        {
            _assetProvider = assetProvider;
            _heroDataService = heroDataService;
        }


        public HeroFacade CreateHero(HeroSpawnData heroSpawnData, HeroType heroType)
        {
            HeroData heroData = _heroDataService.ForHero(heroType);
            
            HeroFacade facade = SpawnHero(heroSpawnData, heroData);

            InitAllComponents(facade, heroData);
            
            TrySetMainTarget(heroSpawnData, facade);

            TrySetLayers(facade, heroSpawnData.OpponentMask, heroSpawnData.MyMask);

            return facade;
        }

        private static void TrySetLayers(HeroFacade facade, LayerMask opponentMask, LayerMask myMask)
        {
            facade.gameObject.layer = myMask.GetLayerInteger();
            IHeroTriggerComponent triggerComponent = facade.GetHeroComponent<IHeroTriggerComponent>();
            triggerComponent?.SetOpponentLayerMask(opponentMask);
        }

        private static HeroFacade SpawnHero(HeroSpawnData heroSpawnData, HeroData heroData)
        {
            GameObject heroSpawned = Object.Instantiate(heroData.HeroPrefab, 
                heroSpawnData.Position, heroSpawnData.Quaternion, heroSpawnData.Parent);

            HeroFacade facade = heroSpawned.GetComponent<HeroFacade>();
            return facade;
        }

        private static void TrySetMainTarget(HeroSpawnData heroSpawnData, HeroFacade facade)
        {
            IHeroTargetChooser heroTargetChooser = facade.GetHeroComponent<IHeroTargetChooser>();
            heroTargetChooser?.SetMainTarget(heroSpawnData.OpponentBase);
        }

        private static void InitAllComponents(HeroFacade facade, HeroData heroData)
        {
            foreach (IHeroComponent heroComponent in facade.HeroComponents)
            {
                heroComponent.Init(heroData);
            }
        }
    }
}
