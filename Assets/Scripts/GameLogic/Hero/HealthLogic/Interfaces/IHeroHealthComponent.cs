using System;

namespace CastleWarriors.GameLogic.Hero
{
    public interface IHeroHealthComponent : IHeroComponent
    {
        float MaxValue { get; }
        float CurrentValue { get; }
        void TakeDamage(float damage);
        void Heal(float heal);
        event Action Changed;
    }
}