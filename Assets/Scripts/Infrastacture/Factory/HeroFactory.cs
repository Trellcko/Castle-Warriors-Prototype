using CastleWarriors.Assets.Scripts.Constants;
using CastleWarriors.Infastructure.AssetManagment;
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


        public GameObject CreateYoungSwordsman(Vector3 position, Quaternion quaternion, Transform parent) => 
            _assetProvider.Instantiate(AssetsNames.YoungSwordsman, position, quaternion, parent);
    }
}
