using UDBase.Controllers.AudioSystem;
using Zenject;

public class SaveAudioInstaller : MonoInstaller {
	public SaveAudioController.Settings Settings;

	public override void InstallBindings() {
		Container.BindInstance(Settings);
		Container.Bind<IAudio>().To<SaveAudioController>().AsSingle();
	}
}
