using UnityEngine;
using UnityEngine.AI;

namespace CastleWarriors.GameLogic.Hero.Movement
{
    public class HeroMovement : MonoBehaviour, IMovementComponent
    {
        [SerializeField] private HeroTargetChooser _heroTargetChooser;
        [SerializeField] private HeroAnimator _heroAnimator;
        [SerializeField] private NavMeshAgent _navMeshAgent;

        public bool IsActive { get; set; } = true;

        private void Update()
        {
            if(!IsActive) return;
            
            UpdateDestination();
            UpdateAnimation();
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
            if (_heroTargetChooser.CurrentTarget) _navMeshAgent.destination = _heroTargetChooser.CurrentTarget.position;
        }

        private void UpdateAnimation()
        {
            if (_navMeshAgent.isStopped || _navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
                _heroAnimator.SetIdle();
            else
                _heroAnimator.SetRun();
        }
    }
}