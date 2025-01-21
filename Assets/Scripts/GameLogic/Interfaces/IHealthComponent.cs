using System;

namespace CastleWarriors.GameLogic
{
    public interface IHealthComponent
    {
        float MaxValue { get; }
        float CurrentValue { get; }
        void TakeDamage(float damage);
        void Heal(float heal);
        event Action Changed;
    }
}