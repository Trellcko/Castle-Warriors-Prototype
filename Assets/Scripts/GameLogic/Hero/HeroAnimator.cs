﻿using System;
using CastleWarriors.GameLogic.Hero.Data;
using UnityEngine;

namespace CastleWarriors.GameLogic.Hero
{
    public class HeroAnimator : MonoBehaviour, IHeroAnimator
    {
        [SerializeField] private Animator _animator;
        public event Action MeleeAttackFramePlayed;

        private HeroAnimationMode _currentMode = HeroAnimationMode.Movement;

        public bool IsActive { get; private set; } = true;

        private static readonly int Speed = Animator.StringToHash("Speed");
        private static readonly int Attack = Animator.StringToHash("Attack");
        private static readonly int Dying = Animator.StringToHash("Dying");

        public void Init(HeroData hero){ }

        public void Enable()
        {
            IsActive = true;
        }

        public void Disable()
        {
            IsActive = false;
        }

        public void SetMode(HeroAnimationMode mode)
        { 
            if(_currentMode == mode) return;
            
            _currentMode = mode;
            _animator.SetTrigger(mode.ToString());            
        }

        public void SetDie()
        {
            if(!IsActive) return;
            
            _animator.SetTrigger(Dying);
        }

        public void SetIdle()
        {
            if(!IsActive) return;
            
            _animator.SetFloat(Speed, 0f);
        }

        public void SetRun()
        {
            if(!IsActive) return;

            _animator.SetFloat(Speed, 1f);
        }

        public void PlayMeleeAttackAnimation()
        {
            if (!IsActive) return;
            
            _animator.SetTrigger(Attack);
        }

        public void InvokeMeleeAttackFramePlayed()
        {
            MeleeAttackFramePlayed?.Invoke();
        }
    }

    public enum HeroAnimationMode
    {
        None = -1,
        Movement = 0,
        Combat = 1,
        Dying = 2,
    }
}