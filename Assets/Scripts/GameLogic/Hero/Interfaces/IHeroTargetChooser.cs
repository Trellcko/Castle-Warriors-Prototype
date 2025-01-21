using System;
using UnityEngine;

namespace CastleWarriors.GameLogic
{
    public interface IHeroTargetChooser : IHeroComponent
    {
        void SetMainTarget(Transform mainTarget);
        void EnableDistractionOnOthers();
        void DisableDistractionOnOthers();
        event Action TargetChanged;
    }
}