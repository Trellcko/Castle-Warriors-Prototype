using CastleWarriors.GameLogic.Hero.Data;
using UnityEngine;
using UnityEngine.AI;

namespace CastleWarriors.GameLogic.Hero
{
    public class HeroMovement : MonoBehaviour, IMovementComponent
    {
        [SerializeField] private HeroAttackTargetChooser heroAttackTargetChooser;
        [SerializeField] private HeroAnimator _heroAnimator;
        [SerializeField] private NavMeshAgent _navMeshAgent;

        public float RotationSpeed => _navMeshAgent.angularSpeed;

        public bool IsActive { get; private set; } = true;

        public bool IsIdle { get; set; } = true;

        private bool _wasStopped;
        
        private void Update()
        {
            if(!IsActive) return;
            
            UpdateDestination();
            UpdateAnimation();
        }

        public void Init(HeroData hero)
        {
            _navMeshAgent.speed = hero.Speed;
            _navMeshAgent.stoppingDistance = hero.StoppingDistance;
        }

        public void Enable()
        {
            IsActive = true;
            _navMeshAgent.isStopped = _wasStopped;
        }

        public void Disable()
        {
            IsActive = false;
            _wasStopped = _navMeshAgent.isStopped;
            _navMeshAgent.isStopped = true;
        }

        public void StopMoving()
        {
            _navMeshAgent.isStopped = true;
        }

        public void ResumeMoving()
        {
            if(IsActive)
                _navMeshAgent.isStopped = false;
        }

        private void UpdateDestination()
        {
            if (heroAttackTargetChooser.CurrentTarget) 
                _navMeshAgent.destination = heroAttackTargetChooser.CurrentTarget.position;
        }

        private void UpdateAnimation()
        {
            if (_navMeshAgent.isStopped || _navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                IsIdle = true;
                _heroAnimator.SetIdle();
            }
            else
            {
                IsIdle = false;
                _heroAnimator.SetMode(HeroAnimationMode.Movement);
                _heroAnimator.SetRun();
            }
        }
    }
}