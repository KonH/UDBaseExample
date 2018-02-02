using UDBase.Controllers.AudioSystem;
using Zenject;

public class AudioInstaller : MonoInstaller {
	public AudioController.Settings Settings;

	public override void InstallBindings() {
		Container.BindInstance(Settings);
		Container.Bind<IAudio>().To<AudioController>().AsSingle();
	}
}
