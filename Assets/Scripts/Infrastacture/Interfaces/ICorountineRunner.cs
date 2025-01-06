using System.Collections;
using UnityEngine;

namespace CastleWarriors.Infastructure
{
    public interface ICorountineRunner
    {
        Coroutine StartCoroutine(IEnumerator enumerator);
    }
}