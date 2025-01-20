using CastleWarriors.Assets.Scripts.Constants;
using CastleWarriors.GameLogic.Hero;
using CastleWarriors.Infastructure.AssetManagment;
using CastleWarriors.Infastructure.Factory.Data;
using UnityEngine;
using Zenject;

namespace CastleWarriors.Infastructure.Factory
{
    public class HeroFactory : IHeroFactory
    {
        private IAssetProvider _assetProvider;
        
        [Inject]
        private void Construct(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }


        public HeroFacade CreateHero(HeroSpawnData heroSpawnData, HeroType heroType)
        {
            GameObject heroSpawned = _assetProvider.Instantiate(GetPath(heroType), 
                heroSpawnData.Position, heroSpawnData.Quaternion, heroSpawnData.Parent);
            
            HeroFacade facade = heroSpawned.GetComponent<HeroFacade>();

            IHeroTargetChooser heroTargetChooser = facade.GetHeroComponent<IHeroTargetChooser>() as IHeroTargetChooser; 
            heroTargetChooser?.SetMainTarget(heroSpawnData.OpponentTarget);
            
            return facade;
        }

        private static string GetPath(HeroType heroType)
        {
            return heroType switch
            {
                HeroType.Swordsman => AssetsNames.YoungSwordsman,
                _ => ""
            };
        }
        
    }
}
