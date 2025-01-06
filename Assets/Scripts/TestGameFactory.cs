using CastleWarriors.Infastructure.Factory;
using UnityEngine;
using Zenject;

namespace CastleWarriors
{
    public class TestGameFactory : MonoBehaviour
    {
        private IHeroFactory _heroFactory;

        [Inject]
        private void Construct(IHeroFactory heroFactory)
        {
            _heroFactory = heroFactory;
        }

        void Start()
        {
            _heroFactory.CreateYoungSwordsman(transform.position, transform.rotation, transform);
        }
    }
}
