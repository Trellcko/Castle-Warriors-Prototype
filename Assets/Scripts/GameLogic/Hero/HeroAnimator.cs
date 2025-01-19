using UnityEngine;
using UnityEngine.Serialization;

namespace CastleWarriors.GameLogic.Hero
{
    public class HeroAnimator : MonoBehaviour, IHeroAnimator
    {
        [SerializeField] private Animator _animator;
        
        private static readonly int Speed = Animator.StringToHash("Speed");

        public void SetIdle()
        {
            _animator.SetFloat(Speed, 0f);
        }

        public void SetRun()
        {
            _animator.SetFloat(Speed, 1f);
        }
    }

    public interface IHeroAnimator
    {
        void SetIdle();
        void SetRun();
    }
}