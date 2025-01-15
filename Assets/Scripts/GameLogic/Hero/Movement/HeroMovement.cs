using UnityEngine;
using UnityEngine.AI;

namespace CastleWarriors.GameLogic.Hero.Movement
{
    public class HeroMovement : MonoBehaviour, IMovementComponent
    {
        [SerializeField] private HeroTargetChooser _heroTargetChooser;
        [SerializeField] private NavMeshAgent _navMeshAgent;

        private void Update()
        {
            if (_heroTargetChooser.CurrentTarget)
            {
                _navMeshAgent.destination = _heroTargetChooser.CurrentTarget.position;
            }
        }

        public void StopMoving()
        {
            _navMeshAgent.isStopped = true;
        }

        public void ResumeMoving()
        {
            _navMeshAgent.isStopped = false;
        }
    }
}