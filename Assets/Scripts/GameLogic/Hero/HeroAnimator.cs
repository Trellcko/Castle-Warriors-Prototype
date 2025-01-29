using System;
using CastleWarriors.GameLogic.Data;
using UnityEngine;

namespace CastleWarriors.GameLogic
{
    public class HeroAnimator : MonoBehaviour, IHeroAnimator
    {
        [SerializeField] private Animator _animator;

        public event Action MeleeAttackFramePlayed;

        private HeroAnimationMode _currentMode = HeroAnimationMode.Movement;
        
        public bool IsActive
        {
            get => _isActive;
            set
            {
                _isActive = value;
                _animator.speed = value ? 1f : 0f;
            }
        }
        
        private bool _isActive = true;

        private static readonly int Speed = Animator.StringToHash("Speed");
        private static readonly int Attack = Animator.StringToHash("Attack");

        public void Init(HeroData hero){ }

        public void SetMode(HeroAnimationMode mode)
        { 
            if(_currentMode == mode) return;
            
            _currentMode = mode;
            _animator.SetTrigger(mode.ToString());            
        }
        
        public void SetIdle()
        {
            if(!_isActive) return;
            
            _animator.SetFloat(Speed, 0f);
        }

        public void SetRun()
        {
            if(!_isActive) return;

            _animator.SetFloat(Speed, 1f);
        }

        public void PlayMeleeAttackAnimation()
        {
            if (!_isActive) return;
            
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
    }
}