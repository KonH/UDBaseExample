using UDBase.Controllers.MusicSystem;
using Zenject;

public class MusicInstaller : MonoInstaller {
	public override void InstallBindings() {
		Container.Bind<IMusic>().To<MusicController>().AsSingle().NonLazy();
	}
}
