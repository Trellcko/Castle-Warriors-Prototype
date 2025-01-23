using CastleWarriors.GameLogic;
using CastleWarriors.Infastructure.Services.Factory;
using Zenject;

namespace CastleWarriors.Infastructure.Services.Boostrapers
{
    public class LevelBootstraper : MonoInstaller
    {   
        public override void InstallBindings()
        {
            BindHeroFactory();
            BindHeroStaticDataService();
            BindInitLevelStateInvoker();
        }

        private void BindInitLevelStateInvoker()
        {
            Container.BindInterfacesTo<InitLevelStateInvoker>()
                .AsSingle();
        }

        private void BindHeroStaticDataService()
        {
            Container.Bind<IHeroDataService>()
                .To<HeroDataService>()
                .AsSingle();
        }

        private void BindHeroFactory()
        {
            Container.Bind<IHeroFactory>().
                To<HeroFactory>()
                .AsSingle();
        }
    }
}
