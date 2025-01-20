using System;
using UnityEngine;

namespace CastleWarriors.GameLogic.Hero
{
    public class HeroTargetChooser : MonoBehaviour, IHeroTargetChooser
    {
        public Transform CurrentTarget { get; private set; }
        public bool IsActive { get; set; } = true;

        private Transform _mainTarget;
        private bool _canBeDistracted;

        public event Action TargetChanged;
        
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