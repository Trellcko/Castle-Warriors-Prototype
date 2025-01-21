using CastleWarriors.Infastructure.Services.Factory;
using CastleWarriors.Infastructure.Services.Factory.Data;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace CastleWarriors
{
    public class TestGameFactory : MonoBehaviour
    {
        [SerializeField] private Transform _testTarget;
        [SerializeField] private LayerMask _opponentLayerMask;
        [SerializeField] private LayerMask _myLayerMask;

        private IHeroFactory _heroFactory;
        private Camera _camera;

        [Inject]
        private void Construct(IHeroFactory heroFactory)
        {
            _heroFactory = heroFactory;
        }

        private void Start()
        {
            _camera = Camera.main;
            
            _heroFactory.CreateHero(CreateHeroSpawnData(), HeroType.Swordsman);
        }

        private HeroSpawnData CreateHeroSpawnData()
        {
            HeroSpawnData spawnData = new(transform.position, transform.rotation, 
                transform, _testTarget, _opponentLayerMask, _myLayerMask);
            return spawnData;
        }
    }
}
