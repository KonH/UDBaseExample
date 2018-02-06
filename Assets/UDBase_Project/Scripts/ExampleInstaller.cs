using UDBase.Common;
using UDBase.Controllers.LogSystem.UI;
using UDBase.Controllers.ConfigSystem;
using UDBase.Controllers.SaveSystem;
using UDBase.Controllers.AudioSystem;
using UDBase.Controllers.ContentSystem;
using UDBase.Controllers.LeaderboardSystem;
using UDBase.Controllers.SceneSystem;
using UDBase.Controllers.SoundSystem;

public class ExampleInstaller : UDBaseInstaller {
	public VisualLogHandler.Settings LogSettings;
	public Config.JsonSettings JsonConfigSettings;
	public Save.JsonSettings JsonSaveSettings;
	public AsyncSceneLoader.Settings SceneSettings;
	public AssetBundleContentController.Settings AssetBundleSettings;
	public SaveAudioController.Settings SaveAudioSettings;
	public SoundUtility.Settings SoundSettings;
	public WebLeaderboard.Settings WebLeaderboardSettings;


	public override void InstallBindings() {
		// TODO: Build Types

		// Utility controllers
		AddUnityLogger();
		AddEvents();
		AddJsonConfig(JsonConfigSettings);
		AddJsonSave(JsonSaveSettings);
		AddDirectContentLoader();
		AddBundleContentLoader(AssetBundleSettings);

		// Common controllers
		AddAsyncSceneLoader(SceneSettings);
		AddSaveAudio(SaveAudioSettings);
		AddSound(SoundSettings);
		AddMusic();

		// Specific controllers
		AddNetUtils();
		AddLocalTime();
		AddSaveUser();
		AddWebLeaderboards(WebLeaderboardSettings);

		// Project-specific controller
		Container.Bind<ConcreteStateExample>().AsSingle();
	}
}
