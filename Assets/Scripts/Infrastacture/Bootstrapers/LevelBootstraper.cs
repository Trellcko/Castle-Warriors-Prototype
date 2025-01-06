using CastleWarriors.Infastructure.Factory;
using Zenject;

namespace CastleWarriors.Infastructure.Boostrapers
{
    public class LevelBootstraper : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindHeroFactory();
        }

        private void BindHeroFactory()
        {
            Container.Bind<IHeroFactory>().
                To<HeroFactory>()
                .AsSingle();
        }
    }
}
