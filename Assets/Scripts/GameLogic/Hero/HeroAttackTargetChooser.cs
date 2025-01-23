using System;
using CastleWarriors.GameLogic.Data;
using CastleWarriors.GameLogic.Utils;
using UnityEngine;

namespace CastleWarriors.GameLogic
{
    public class HeroAttackTargetChooser : MonoBehaviour, IHeroTargetChooser
    {
        [SerializeField] private HeroTrigger _heroTrigger;
        public Transform CurrentTarget { get; private set; }
        public bool IsActive { get; set; } = true;

        private Transform _mainTarget;

        private bool _canBeDistracted;

        private BetterTimer _betterTimer;
        
        public event Action TargetChanged;

        private const float TimeToCheckForEnemyHeroes = 0.2f;

        private void Awake()
        {
            _betterTimer = new(TimeToCheckForEnemyHeroes, playAwake: true, loop: true);   
        }

        private void OnEnable()
        {
            _betterTimer.Completed+= TryDistract;
        }

        private void OnDisable()
        {
            _betterTimer.Completed -= TryDistract;
        }

        private void TryDistract()
        {
            Transform closetTarget = _heroTrigger.GetClosetOpponent();

            if (!closetTarget) return;
           
            CurrentTarget = closetTarget;
            TargetChanged?.Invoke();
        }

        public void Init(HeroData hero){ }

        private void Update()
        {
            if (IsActive && _canBeDistracted)
            {
                _betterTimer.Tick();
            }

            if (CurrentTarget) return;
            
            CurrentTarget = _mainTarget;
            TargetChanged?.Invoke();
        }

        public void SetMainTarget(Transform mainTarget)
        {
            if(!IsActive) return;
            
            _mainTarget = mainTarget;
            if (!CurrentTarget)
            {
                CurrentTarget = _mainTarget;
            }
            TargetChanged?.Invoke();
        }

        public void EnableDistractionOnOthers()
        {
            if(!IsActive) return;
         
            _canBeDistracted = true;
        }

        public void DisableDistractionOnOthers()
        {
            if(!IsActive) return;
         
            _canBeDistracted = false;
        }
    }
}