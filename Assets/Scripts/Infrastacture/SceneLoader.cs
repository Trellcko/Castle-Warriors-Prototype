using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace CastleWarriors.Infastructure
{
    public class SceneLoader : ISceneLoader
    {
        private ICorountineRunner _corountineRunner;
        public string CurrentScene => SceneManager.GetActiveScene().name;

        [Inject]
        private void Construct(ICorountineRunner corountineRunner)
        {
            _corountineRunner = corountineRunner;
        }

        public void Load(string sceneName, Action onLoaded = null) => 
            _corountineRunner.StartCoroutine(LoadScene(sceneName, onLoaded));

        private IEnumerator LoadScene(string sceneName, Action onLoaded = null)
        {
            AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(sceneName);

            while (!waitNextScene.isDone)
            {
                yield return null;
            }
            onLoaded?.Invoke();
        }
    }
}