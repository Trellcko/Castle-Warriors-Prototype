using CastleWarriors.GameLogic.Data;
using CastleWarriors.Utils;
using UnityEngine;

namespace CastleWarriors.GameLogic
{
    public class HeroTrigger : MonoBehaviour, IHeroTriggerComponent
    {
        [SerializeField] private float _radius;
        
        public bool IsActive { get; set; } = true;

        private LayerMask _enemyLayer;

        private readonly Collider[] _colliders = new Collider[10];

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _radius);
        }

        public void Init(HeroData hero)
        {
            _radius = ((HeroFighterData)hero).TriggerDistance;
        }

        public void SetOpponentLayerMask(LayerMask enemyLayer)
        {
            _enemyLayer = enemyLayer;
        }

        public Transform GetClosetTarget()
        {
            int count = Physics.OverlapSphereNonAlloc(transform.position, _radius, _colliders, _enemyLayer);
            Transform closetTarget = null;
            float distance = Mathf.Infinity;
            
            for (int i = 0; i < count; i++)
            {
                float newDistance = _colliders[i].transform.position.DistanceSqrTo(transform.position);

                if (!(newDistance < distance)) continue;
                
                closetTarget = _colliders[i].transform;
                distance = newDistance;
            }

            return closetTarget;
        }
    }
}
