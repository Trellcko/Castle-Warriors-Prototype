using UnityEngine;
using UnityEngine.Serialization;

namespace CastleWarriors.GameLogic.Hero
{
    public class HeroAnimator : MonoBehaviour, IHeroAnimator
    {
        [SerializeField] private Animator _animator;
        private bool _isActive = true;

        public bool IsActive
        {
            get => _isActive;
            set
            {
                _isActive = value;
                _animator.speed = value ? 1f : 0f;
            }
        }

        private static readonly int Speed = Animator.StringToHash("Speed");

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
    }

    public interface IHeroAnimator : IHeroComponent
    {
        void SetIdle();
        void SetRun();
    }
}