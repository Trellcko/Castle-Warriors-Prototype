using System;
using CastleWarriors.GameLogic.Hero.Data;
using CastleWarriors.GameLogic.Utils;
using CastleWarriors.Utils;
using UnityEngine;

namespace CastleWarriors.GameLogic.Hero
{
    public class HeroSwordAttackComponent : MonoBehaviour, IHeroAttackComponent
    {
        [SerializeField] private HeroAnimator _heroAnimator;
        [SerializeField] private HeroAttackTargetChooser _heroTargetChooser;
        [SerializeField] private HeroMovement _heroMovement;

        public bool IsActive { get; private set; } = true;

        private Transform CurrentTarget => _heroTargetChooser.CurrentTarget;

        private float _damage;

        private float _attackComboCount;

        private float _delayBetweenCombos;

        private  bool _fromOtherStateToAttack = true;

        private BetterTimer _timerToAttack;

        private IHealthComponent _healthTargetComponent;

        private int _currentComboCount;

        public void Init(HeroData hero)
        {
            HeroFighterData heroFighterData = (HeroFighterData)hero;
            
            _damage = heroFighterData.Damage;
            _attackComboCount = heroFighterData.AttackCounts;
            
            _delayBetweenCombos = heroFighterData.DelayBetweenAttack;
            
            _timerToAttack = new(_delayBetweenCombos, playAwake: true, loop: true);
            _timerToAttack.Completed += OnDelayTimeRunOut;
        }

        public void Enable()
        {
            IsActive = true;
        }

        public void Disable()
        {
            IsActive = false;
        }

        private void OnEnable()
        {
            _heroTargetChooser.TargetChanged += OnTargetChanged;
            _heroAnimator.MeleeAttackFramePlayed += Attack;
        }

        private void OnDisable()
        {
            _heroTargetChooser.TargetChanged -= OnTargetChanged;
            _timerToAttack.Completed -= OnDelayTimeRunOut;
            _heroAnimator.MeleeAttackFramePlayed -= Attack;
        }

        private void OnDestroy()
        {
            _timerToAttack.Completed -= OnDelayTimeRunOut;
        }

        private void Update()
        {
            if(_healthTargetComponent == null && !IsActive)
                return;

            if (_heroMovement.IsIdle)
            {
                _heroAnimator.SetMode(HeroAnimationMode.Combat);
                
                LookAtTarget();
                if (_fromOtherStateToAttack)
                {
                    _fromOtherStateToAttack = false;
                    OnDelayTimeRunOut();
                    _timerToAttack.Reset();
                }
                _timerToAttack.Tick();       
                return;
            }
            _fromOtherStateToAttack = true;
        }

        private void LookAtTarget()
        {
            if (!IsActive)
                return;
            Vector3 direction = CurrentTarget.position - transform.parent.position;
            direction.y = 0;

            if (direction.magnitude < 0.01f) return;
            
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            transform.parent.rotation = Quaternion.Lerp(transform.rotation, targetRotation, _heroMovement.RotationSpeed * Time.deltaTime);
        }

        private void OnDelayTimeRunOut()
        {
            _heroAnimator.PlayMeleeAttackAnimation();
        }

        private void OnTargetChanged()
        {
            _healthTargetComponent = CurrentTarget.GetComponentInChildren<IHealthComponent>();
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
