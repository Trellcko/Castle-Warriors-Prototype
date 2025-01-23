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
        private float _attackComboCount;
        private float _delayBetweenCombos;
        private float _distanceToAttack;

        private BetterTimer _timerToAttack;
        private IHealthComponent _healthTargetComponent;
        
        private int _currentComboCount;

        public void Init(HeroData hero)
        {
            HeroFighterData heroFighterData = (HeroFighterData)hero;
            
            _damage = heroFighterData.Damage;
            _attackComboCount = heroFighterData.AttackCounts;
            
            _delayBetweenCombos = heroFighterData.DelayBetweenAttack;
            _distanceToAttack = heroFighterData.DistanceToStartAttack;
            
            _timerToAttack = new(_delayBetweenCombos, playAwake: true, loop: true);
            _timerToAttack.Completed += OnDelayTimeRunOut;
        }

        private void OnEnable()
        {
            _heroTargetChooser.TargetChanged += ChangeTarget;
            _heroAnimator.MeleeAttackFramePlayed += Attack;
        }

        private void OnDisable()
        {
            _heroTargetChooser.TargetChanged -= ChangeTarget;
            _timerToAttack.Completed -= OnDelayTimeRunOut;
            _heroAnimator.MeleeAttackFramePlayed -= Attack;
        }

        private void OnDestroy()
        {
            _timerToAttack.Completed -= OnDelayTimeRunOut;
        }

        private void Update()
        {
            if(_healthTargetComponent == null)
                return;

            if (_heroTargetChooser.CurrentTarget.position.DistanceSqrTo(transform.position) < _distanceToAttack)
            {
                _heroAnimator.SetMode(HeroAnimationMode.Combat);
                _timerToAttack.Tick();       
                return;
            }
            _heroAnimator.SetMode(HeroAnimationMode.Movement);
        }

        private void OnDelayTimeRunOut()
        {
            _heroAnimator.PlayMeleeAttackAnimation();
        }

        private void ChangeTarget()
        {
            _healthTargetComponent = _heroTargetChooser.CurrentTarget.GetComponentInChildren<IHealthComponent>();
        }

        private void Attack()
        {
            _healthTargetComponent.TakeDamage(_damage);
            _currentComboCount++;
            if (_currentComboCount < _attackComboCount)
            {
                OnDelayTimeRunOut();
            }
            else
            {
                _timerToAttack.Reset();
            }
        }
    }
}
