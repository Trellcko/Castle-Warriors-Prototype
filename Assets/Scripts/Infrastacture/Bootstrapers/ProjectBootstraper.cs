using CastleWarriors.UI;
using System;
using CastleWarriors.Infastructure.Services.AssetManagment;
using UnityEngine;
using Zenject;

namespace CastleWarriors.Infastructure.Services.Boostrapers
{
    public class ProjectBootstraper : MonoInstaller, ICorountineRunner
    {
        [SerializeField] private LoadingCurtain _loadingCurtain;

        public override void InstallBindings()
        {
            BindCorountineRunner();
            BindSceneLoader();
            BindLoadingCurtain();
            BindAssetProvider();
            BindGameBehaviour();
        }

        private void BindAssetProvider()
        {
            Container.Bind<IAssetProvider>()
                .To<AssetProvider>()
                .AsSingle();
        }

        private void BindSceneLoader()
        {
            Container.Bind<ISceneLoader>()
                .To<SceneLoader>()
                .AsSingle();
        }

        private void BindGameBehaviour()
        {
            Container.BindInterfacesTo<GameBehaviour>()
                .AsSingle();
        }

        private void BindLoadingCurtain()
        {
            Container.Bind<ILoadingCurtain>()
                .FromComponentInNewPrefab(_loadingCurtain)
                .AsSingle();
        }

        private void BindCorountineRunner()
        {
            Container.Bind<ICorountineRunner>()
                .FromInstance(this)
                .AsSingle();
        }
    }
}
