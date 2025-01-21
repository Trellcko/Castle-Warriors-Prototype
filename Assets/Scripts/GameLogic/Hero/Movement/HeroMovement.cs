using CastleWarriors.GameLogic.Data;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

namespace CastleWarriors.GameLogic.Movement
{
    public class HeroMovement : MonoBehaviour, IMovementComponent
    {
        [FormerlySerializedAs("_heroTargetChooser")] [SerializeField] private HeroAttackTargetChooser heroAttackTargetChooser;
        [SerializeField] private HeroAnimator _heroAnimator;
        [SerializeField] private NavMeshAgent _navMeshAgent;

        public bool IsActive { get; set; } = true;

        private void Update()
        {
            if(!IsActive) return;
            
            UpdateDestination();
            UpdateAnimation();
        }

        public void Init(HeroData hero)
        {
            _navMeshAgent.speed = hero.Speed;
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
            if (heroAttackTargetChooser.CurrentTarget) _navMeshAgent.destination = heroAttackTargetChooser.CurrentTarget.position;
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