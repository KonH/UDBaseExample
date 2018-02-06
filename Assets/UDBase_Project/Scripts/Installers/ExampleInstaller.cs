using UnityEngine;
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

		// Utility controllers

		// Optional BuildType usage
		if ( _buildType != null ) {
			Debug.Log($"BuildType is {_buildType}");
			if ( _buildType.IsEditor ) {
				AddUnityLogger();
			} else if ( _buildType.Is(BuildTypes.Development) ) {
				AddVisualLogger(LogSettings);
			} else {
				AddEmptyLogger();
			}
		} else {
			Debug.LogWarning($"BuildType isn't specified!");
			AddEmptyLogger();
		}

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
