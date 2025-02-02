using System;

namespace CastleWarriors.GameLogic.Hero
{
    public interface IHeroAnimator : IHeroComponent
    {
        void SetIdle();
        void SetRun();
        void PlayMeleeAttackAnimation();
        event Action MeleeAttackFramePlayed;
        void SetDie();
    }
}