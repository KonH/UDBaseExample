using UDBase.Controllers.AudioSystem;
using UDBase.Controllers.MusicSystem;
using UDBase.Controllers.SoundSystem;
using Zenject;

public class TestInstaller : MonoInstaller {
	public override void InstallBindings() {
		// TODO: Helper methods
		Container.Bind<IAudio>().To<IAudio>().FromMethod(_ => CreateAudioController()).AsSingle();
		Container.Bind<ISound>().To<SoundController>().AsSingle().NonLazy();
		Container.Bind<IMusic>().To<MusicController>().AsSingle().NonLazy();
		
		Container.Bind<IStateExample>().To<ConcreteStateExample>().AsSingle();
	}

	IAudio CreateAudioController() {
		return new SaveAudioController("AudioMixer", channels: new string[] { "SoundVolume", "MusicVolume" });
	}
}
