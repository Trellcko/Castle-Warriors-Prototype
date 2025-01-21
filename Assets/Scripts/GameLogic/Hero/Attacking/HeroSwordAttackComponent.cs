using System;
using CastleWarriors.GameLogic.Data;
using CastleWarriors.GameLogic.Utils;
using CastleWarriors.Utils;
using UnityEngine;

namespace CastleWarriors.GameLogic.Attacking
{
    public class HeroSwordAttackComponent : MonoBehaviour, IHeroAttackComponent
    {
        [SerializeField] private HeroAnimator _heroAnimator;
        [SerializeField] private HeroAttackTargetChooser _heroTargetChooser;

        public bool IsActive { get; set; } = true;
        
        private float _damage;
        private float _count;
        private float _delayBetweenCombos;
        private float _distanceToAttack;

        private BetterTimer _betterTimer;
        
        private IHealthComponent _healthTargetComponent;
        
        private const float TimeToCheckDistance = 0.2f;

        public void Init(HeroData hero)
        {
            HeroFighterData heroFighterData = (HeroFighterData)hero;
            _damage = heroFighterData.Damage;
            _count = heroFighterData.AttackCounts;
            _delayBetweenCombos = heroFighterData.DelayBetweenAttack;
            _distanceToAttack = heroFighterData.DistanceToStartAttack;
            _betterTimer = new(_delayBetweenCombos, playAwake: true, loop: true);
        }

        private void OnEnable()
        {
            _heroTargetChooser.TargetChanged+= ChangeTarget;
            _betterTimer.Completed+= OnDelayTimeRunOut;
        }

        private void OnDisable()
        {
            _heroTargetChooser.TargetChanged-= ChangeTarget;
            _betterTimer.Completed-= OnDelayTimeRunOut;
        }

        //TODO: Complete attack logic
        private void OnDelayTimeRunOut()
        {
        }

        private void Update()
        {
            if(_healthTargetComponent == null)
                return;

            if (_heroTargetChooser.CurrentTarget.position.DistanceSqrTo(transform.position) < _distanceToAttack)
            {
                _betterTimer.Tick();       
            }
        }

        private void ChangeTarget()
        {
            _healthTargetComponent = _heroTargetChooser.CurrentTarget.GetComponentInChildren<IHealthComponent>();
        }

        public void Attack()
        {
            
        }
    }
}
