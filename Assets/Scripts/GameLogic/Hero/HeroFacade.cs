using System.Collections.Generic;
using System.Linq;
using CastleWarriors.GameLogic.Hero;
using UnityEngine;

namespace CastleWarriors.GameLogic
{
    public class HeroFacade : MonoBehaviour
    {
        public readonly List<IHeroComponent> HeroComponents = new();
        
        private void Awake() 
        {
            foreach (IHeroComponent heroComponent in GetComponentsInChildren<IHeroComponent>())
            {
                HeroComponents.Add(heroComponent);
            }
        }
        
        public T GetHeroComponent<T>() where T : class, IHeroComponent => 
            HeroComponents.FirstOrDefault(x => x is T) as T;
    }
}