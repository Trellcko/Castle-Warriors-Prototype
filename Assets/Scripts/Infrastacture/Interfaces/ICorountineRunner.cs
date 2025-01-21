using System.Collections;
using UnityEngine;

namespace CastleWarriors.Infastructure.Services
{
    public interface ICorountineRunner
    {
        Coroutine StartCoroutine(IEnumerator enumerator);
    }
}