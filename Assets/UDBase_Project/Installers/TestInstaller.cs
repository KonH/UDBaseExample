using UDBase.Controllers.AudioSystem;
using UDBase.Controllers.EventSystem;
using UDBase.Controllers.InventorySystem;
using UDBase.Controllers.LeaderboardSystem;
using UDBase.Controllers.MusicSystem;
using UDBase.Controllers.SaveSystem;
using UDBase.Controllers.SceneSystem;
using UDBase.Controllers.SoundSystem;
using UDBase.Controllers.UserSystem;
using UDBase.Controllers.UTime;
using Zenject;

public class TestInstaller : MonoInstaller {
	public override void InstallBindings() {
		// TODO: Helper methods

		// TODO: Use settings pattern?
		
		// TODO: Log
		// => TODO: Fix start issue
		// TODO: Fix issue in Audio example
		
		// TODO: Config
		// => TODO: Fix issues in Inventory example
		// => TODO: Inventory

		// TODO: Content

		// TODO: Full move audio/sound/music
		
		Container.Bind<ISave>().To<ISave>().FromMethod(_ => CreateSave()).AsSingle();

		Container.Bind<ITime>().To<LocalTime>().AsSingle();

		Container.Bind<IEvent>().To<EventController>().AsSingle();

		Container.Bind<AsyncLoadHelper>().To<AsyncLoadHelper>().FromNewComponentOnNewGameObject(GameObjectCreationParameters.Default).AsSingle();
		Container.Bind<AsyncSceneLoader.SceneSetup>().FromInstance(new AsyncSceneLoader.SceneSetup("Loading", "MainScene")).AsSingle();
		Container.Bind<IScene>().To<AsyncSceneLoader>().AsSingle();

		Container.Bind<IAudio>().To<IAudio>().FromMethod(_ => CreateAudioController()).AsSingle();
		Container.Bind<ISound>().To<SoundController>().AsSingle().NonLazy();
		Container.Bind<IMusic>().To<MusicController>().AsSingle().NonLazy();

		Container.Bind<IUser>().To<SaveUser>().AsSingle();

		Container.Bind<ILeaderboard>().To<WebLeaderboard>().FromMethod(_ => CreateWebLeaderboard()).AsSingle();
		
		Container.Bind<ConcreteStateExample>().AsSingle();
	}

	IAudio CreateAudioController() {
		var save = Container.Resolve<ISave>();
		return new SaveAudioController(save, "AudioMixer", channels: new string[] { "SoundVolume", "MusicVolume" });
	}

	WebLeaderboard CreateWebLeaderboard() {
		return new WebLeaderboard("https://konhit.xyz/lbservice/", "testGame", "1.0.0", "testUser", "mGPRudr8");
	}

	ISave CreateSave() {
		return new FsJsonDataSave(true, true).
			AddNode<ConcreteStateExampleSave>("save_node").
			AddNode<InventorySaveNode>("inventory").
			AddNode<RewardNode>("reward").
			AddNode<UserSaveNode>("user").
			AddNode<AudioSaveNode>("audio");
	}
}
