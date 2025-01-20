using CastleWarriors.Infastructure.Factory;
using CastleWarriors.Infastructure.Factory.Data;
using UnityEngine;
using Zenject;

namespace CastleWarriors
{
    public class TestGameFactory : MonoBehaviour
    {
        [SerializeField] private Transform _testTarget;

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
                transform, _testTarget);
            return spawnData;
        }
    }
}
