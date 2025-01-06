using System;

namespace CastleWarriors.Infastructure
{
    public interface ISceneLoader
    {
        string CurrentScene { get; }
        void Load(string sceneName, Action onLoaded = null);
    }
}