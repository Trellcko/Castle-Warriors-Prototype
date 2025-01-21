using System;
using CastleWarriors.GameLogic.Data;
using UnityEngine;

namespace CastleWarriors.GameLogic
{
    public class HeroHealth : MonoBehaviour, IHeroHealthComponent
    {
        [field:SerializeField] public float MaxValue { get; private set; } = 100f;
        public float CurrentValue { get; private set; }
        public bool IsActive { set; get; } = true;

        public event Action Changed;
        
        public void Init(HeroData hero)
        {
            MaxValue = CurrentValue = hero.Health;
        }
        
        public void TakeDamage(float damage)
        {
            if(!IsActive) return;
            
            CurrentValue -= damage;
            ClampValue();
            Changed?.Invoke();
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
