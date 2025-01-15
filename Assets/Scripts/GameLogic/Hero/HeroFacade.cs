using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CastleWarriors.GameLogic.Hero
{
    public class HeroFacade : MonoBehaviour
    {
        private readonly List<IHeroComponent> _heroComponents = new();
        
        private void Awake() 
        {
            foreach (var heroComponent in GetComponentsInChildren<IHeroComponent>())
            {
                _heroComponents.Add(heroComponent);
            }
        }
        
        public IHeroComponent GetHeroComponent<T>() where T : IHeroComponent => 
            _heroComponents.FirstOrDefault(x => x is T);
    }
}