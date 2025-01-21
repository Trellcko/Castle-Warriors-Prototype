using System;

namespace CastleWarriors.Infastructure.Services
{
    public interface ISceneLoader
    {
        string CurrentScene { get; }
        void Load(string sceneName, Action onLoaded = null);
    }
}