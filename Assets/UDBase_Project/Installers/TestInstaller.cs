using UDBase.Controllers.AudioSystem;
using UDBase.Controllers.LeaderboardSystem;
using UDBase.Controllers.MusicSystem;
using UDBase.Controllers.SoundSystem;
using UDBase.Controllers.UserSystem;
using Zenject;

public class TestInstaller : MonoInstaller {
	public override void InstallBindings() {
		// TODO: Helper methods
		Container.Bind<IAudio>().To<IAudio>().FromMethod(_ => CreateAudioController()).AsSingle();
		Container.Bind<ISound>().To<SoundController>().AsSingle().NonLazy();
		Container.Bind<IMusic>().To<MusicController>().AsSingle().NonLazy();

		Container.Bind<IUser>().To<SaveUser>().AsSingle();

		Container.Bind<ILeaderboard>().To<WebLeaderboard>().FromMethod(_ => CreateWebLeaderboard()).AsSingle();
		
		Container.Bind<IStateExample>().To<ConcreteStateExample>().AsSingle();
	}

	IAudio CreateAudioController() {
		return new SaveAudioController("AudioMixer", channels: new string[] { "SoundVolume", "MusicVolume" });
	}

	WebLeaderboard CreateWebLeaderboard() {
		return new WebLeaderboard("https://konhit.xyz/lbservice/", "testGame", "1.0.0", "testUser", "mGPRudr8");
	}
}
