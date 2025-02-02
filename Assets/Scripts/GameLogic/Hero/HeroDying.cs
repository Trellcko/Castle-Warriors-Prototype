using CastleWarriors.GameLogic.Dying;
using CastleWarriors.GameLogic.Hero.Data;
using UnityEngine;

namespace CastleWarriors.GameLogic.Hero
{
    public class HeroDying : MonoBehaviour, IHeroDyingComponent
    {
        [SerializeField] private HeroFacade _heroFacade;

        public bool IsActive { get; private set; } = true;

        private IHeroHealthComponent _heroHealth;

        public void Init(HeroData hero)
        {
            _heroHealth = _heroFacade.GetHeroComponent<IHeroHealthComponent>();
            _heroHealth.ChangedToZero += Die;
        }

        public void Enable()
        {
            IsActive = true;
            
            _heroHealth.ChangedToZero -= Die;
            _heroHealth.ChangedToZero += Die;
        }

        public void Disable()
        {
            IsActive = false;
            _heroHealth.ChangedToZero -= Die;
        }

        public void Die()
        {
            _heroFacade.GetHeroComponent<IHeroAnimator>().SetDie();
            
            foreach (IHeroComponent heroComponent in _heroFacade.HeroComponents)
            {
                heroComponent.Disable();
            }
        }
    }
}