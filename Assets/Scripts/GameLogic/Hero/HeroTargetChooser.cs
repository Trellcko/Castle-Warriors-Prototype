using System;
using UnityEngine;

namespace CastleWarriors.GameLogic.Hero
{
    public class HeroTargetChooser : MonoBehaviour, IHeroTargetChooser
    {
        public Transform CurrentTarget { get; private set; }
        
        private Transform _mainTarget;
        
        private bool _canBeDistracted;

        public event Action TargetChanged;

        public void SetMainTarget(Transform mainTarget)
        {
            _mainTarget = mainTarget;
            if (!CurrentTarget)
            {
                CurrentTarget = _mainTarget;
            }
            TargetChanged?.Invoke();
        }

        public void EnableDistractionOnOthers() => 
            _canBeDistracted = true;

        public void DisableDistractionOnOthers() => 
            _canBeDistracted = false;
    }
}