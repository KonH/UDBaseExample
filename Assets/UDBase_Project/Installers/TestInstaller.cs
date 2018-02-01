using System.Collections.Generic;
using UDBase.Controllers.AudioSystem;
using UDBase.Controllers.ConfigSystem;
using UDBase.Controllers.ContentSystem;
using UDBase.Controllers.EventSystem;
using UDBase.Controllers.LeaderboardSystem;
using UDBase.Controllers.MusicSystem;
using UDBase.Controllers.SaveSystem;
using UDBase.Controllers.SceneSystem;
using UDBase.Controllers.SoundSystem;
using UDBase.Controllers.UserSystem;
using UDBase.Controllers.UTime;
using Zenject;

public class TestInstaller : MonoInstaller {
	public AsyncSceneLoader.Settings SceneSettings;
	public AudioController.Settings AudioSettings;
	public SaveAudioController.Settings SaveAudioSettings;
	public SoundUtility.Settings SoundUtilitySettings;
	public WebLeaderboard.Settings WebLeaderboardSettings;
	public AssetBundleContentController.Settings AssetBundleSettings;

	public override void InstallBindings() {
		// TODO: Build Types

		// TODO: Do I need all these mono helpers?

		// TODO: Helper methods?

		// TODO: Installer per controller?
		
		// TODO: Log (drop logger and use visual helper only, what with enable/disable by build type?)
		// => TODO: Fix start issue
		
		// TODO: Fix issue in Audio example
		// TODO: Fix issue in Audio Controller
		
		Container.Bind<ISave>().FromMethod(_ => CreateSave()).AsSingle();

		Container.Bind<IConfig>().FromMethod(_ => CreateConfig()).AsSingle();

		Container.Bind<ITime>().To<LocalTime>().AsSingle();

		Container.Bind<IEvent>().To<EventController>().AsSingle();

		Container.Bind<AsyncLoadHelper>().FromNewComponentOnNewGameObject().AsSingle();
		Container.BindInstance(SceneSettings);
		Container.Bind<IScene>().To<AsyncSceneLoader>().AsSingle();

		Container.BindInstance(AudioSettings);
		Container.BindInstance(SaveAudioSettings);
		Container.Bind<IAudio>().To<SaveAudioController>().AsSingle();
		
		Container.BindInstance(SoundUtilitySettings);
		Container.Bind<SoundUtility>().FromNewComponentOnNewGameObject().AsSingle();
		Container.Bind<ISound>().To<SoundController>().AsSingle().NonLazy();
		
		Container.Bind<IMusic>().To<MusicController>().AsSingle().NonLazy();

		Container.Bind<IUser>().To<SaveUser>().AsSingle();

		Container.BindInstance(WebLeaderboardSettings);
		Container.Bind<ILeaderboard>().To<WebLeaderboard>().AsSingle();

		Container.Bind<IContent>().To<DirectContentController>().AsSingle();
		
		Container.Bind<AssetBundleHelper>().FromNewComponentOnNewGameObject().AsSingle();
		Container.BindInstance(AssetBundleSettings);
		Container.Bind<IContent>().To<AssetBundleContentController>().AsSingle();
		
		Container.Bind<ConcreteStateExample>().AsSingle();
	}

	// TODO: Use custom property drawer for this stuff?
	ISave CreateSave() {
		return new FsJsonDataSave(true, true).
			AddNode<ConcreteStateExampleSave>("save_node").
			AddNode<RewardNode>("reward").
			AddNode<UserSaveNode>("user").
			AddNode<AudioSaveNode>("audio");
	}

	IConfig CreateConfig() { 
		return new FsJsonResourcesConfig().
			AddNode<ConcreteStateExampleConfig>("example_node");
	}
}
