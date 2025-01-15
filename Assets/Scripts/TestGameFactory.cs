using System;
using CastleWarriors.Infastructure.Factory;
using UnityEngine;
using Zenject;

namespace CastleWarriors
{
    public class TestGameFactory : MonoBehaviour
    {
        void Start()
        {
            _camera = Camera.main;
            _heroFactory.CreateYoungSwordsman(transform.position, transform.rotation, transform);
        }

        private IHeroFactory _heroFactory;
        private Camera _camera;

        [Inject]
        private void Construct(IHeroFactory heroFactory)
        {
            _heroFactory = heroFactory;
            
        }

    }
}
