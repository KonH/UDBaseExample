using UDBase.Controllers.SoundSystem;
using Zenject;

public class SoundInstaller : MonoInstaller {
	public SoundUtility.Settings Settings;

	public override void InstallBindings() {
		Container.BindInstance(Settings);
		Container.Bind<SoundUtility>().FromNewComponentOnNewGameObject().AsSingle();
		Container.Bind<ISound>().To<SoundController>().AsSingle().NonLazy();
	}
}
