using System;

namespace CastleWarriors.GameLogic
{
    public interface IHeroAnimator : IHeroComponent
    {
        void SetIdle();
        void SetRun();
        void PlayMeleeAttackAnimation();
        event Action MeleeAttackFramePlayed;
    }
}