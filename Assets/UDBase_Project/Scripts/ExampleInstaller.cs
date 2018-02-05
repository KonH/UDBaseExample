using UDBase.Common;
using UDBase.Controllers.LogSystem.UI;
using UDBase.Controllers.ConfigSystem;
using UDBase.Controllers.SaveSystem;
using UDBase.Controllers.AudioSystem;
using UDBase.Controllers.ContentSystem;
using UDBase.Controllers.LeaderboardSystem;
using UDBase.Controllers.SceneSystem;
using UDBase.Controllers.SoundSystem;
using Zenject;

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

		// TODO: Fix circular dep in visual log

		// TODO: Fix start issue
		// TODO: Fix issue in Audio example
		// TODO: Fix issue in Audio Controller
		// TODO: Check config/save works

		// Utility controllers
		AddVisualLogger(LogSettings);
		AddNetUtils();
		AddEvents();
		AddJsonConfig(JsonConfigSettings);
		AddJsonSave(JsonSaveSettings);
		AddLocalTime();

		// Common controllers
		AddAsyncSceneLoader(SceneSettings);
		AddSaveAudio(SaveAudioSettings);
		AddSound(SoundSettings);
		AddMusic();

		// Specific controllers
		AddSaveUser();
		AddWebLeaderboards(WebLeaderboardSettings);

		// Project-specific controller
		Container.Bind<ConcreteStateExample>().AsSingle();
	}
}
