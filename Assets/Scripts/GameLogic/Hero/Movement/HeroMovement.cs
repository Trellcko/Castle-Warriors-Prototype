using CastleWarriors.GameLogic.Data;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

namespace CastleWarriors.GameLogic.Movement
{
    public class HeroMovement : MonoBehaviour, IMovementComponent
    {
        [SerializeField] private HeroAttackTargetChooser heroAttackTargetChooser;
        [SerializeField] private HeroAnimator _heroAnimator;
        [SerializeField] private NavMeshAgent _navMeshAgent;

        public float RotationSpeed => _navMeshAgent.angularSpeed;
        
        public bool IsActive { get; set; } = true;
        
        public bool IsIdle { get; set; } = true;

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

        public void StopMoving()
        {
            _navMeshAgent.isStopped = true;
        }

        public void ResumeMoving()
        {
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