using System;
using CastleWarriors.GameLogic.Hero.Data;
using Sirenix.OdinInspector;
using UnityEngine;

namespace CastleWarriors.GameLogic.Hero
{
    public class HeroHealth : MonoBehaviour, IHeroHealthComponent
    {
        [field:SerializeField] public float MaxValue { get; private set; } = 100f;
        [field: ShowInInspector, ReadOnly] public float CurrentValue { get; private set; }

        public bool IsActive { private set; get; } = true;

        public event Action Changed;

        public event Action ChangedToZero;

        public void Init(HeroData hero)
        {
            MaxValue = CurrentValue = hero.Health;
        }

        public void Enable()
        {
            IsActive = true;
        }

        public void Disable()
        {
            IsActive = false;
        }
        
        [Button]
        public void TakeDamage(float damage)
        {
            if(!IsActive) return;
            
            CurrentValue -= damage;
            ClampValue();

            if (CurrentValue > 0)
            {
                Changed?.Invoke();
            }
            else
            {
                 ChangedToZero?.Invoke();
            }
        }

        public void Heal(float heal)
        {
            if(!IsActive) return;

            CurrentValue += heal;
            ClampValue();
            Changed?.Invoke();
        }

        private void ClampValue()
        {
            CurrentValue = Mathf.Clamp(CurrentValue, 0f, MaxValue);
        }
    }
}
