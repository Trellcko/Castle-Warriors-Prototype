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
