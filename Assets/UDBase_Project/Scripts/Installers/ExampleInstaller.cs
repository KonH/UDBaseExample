using UnityEngine;
using UDBase.Installers;
using UDBase.Controllers.LogSystem;
using UDBase.Controllers.SaveSystem;
using UDBase.Controllers.AudioSystem;
using UDBase.Controllers.SceneSystem;
using UDBase.Controllers.SoundSystem;
using UDBase.Controllers.LogSystem.UI;
using UDBase.Controllers.ConfigSystem;
using UDBase.Controllers.ContentSystem;
using UDBase.Controllers.LeaderboardSystem;
using UDBase.Controllers.LocalizationSystem;

public class ExampleInstaller : UDBaseInstaller {
	public UnityLog.Settings UnityLogSettings;
	public VisualLogHandler.Settings VisualLogSettings;
	public Config.JsonNetworkSettings JsonConfigSettings;
	public Save.JsonSettings JsonSaveSettings;
	public AsyncSceneLoader.Settings SceneSettings;
	public AssetBundleContentController.Settings AssetBundleSettings;
	public SaveAudioController.Settings SaveAudioSettings;
	public SoundUtility.Settings SoundSettings;
	public WebLeaderboard.Settings WebLeaderboardSettings;
	public SingleLocaleParser.Settings LocalizationParserSettings;
	public Localization.Settings LocalizationSettings;


	public override void InstallBindings() {

		// Utility controllers

		// Optional BuildType usage
		if ( _buildType != null ) {
			Debug.Log($"BuildType is {_buildType}");
			if ( _buildType.IsEditor ) {
				AddUnityLogger(UnityLogSettings);
			} else if ( _buildType.Is(BuildTypes.Development) ) {
				AddVisualLogger(VisualLogSettings);
			} else {
				AddEmptyLogger();
			}
		} else {
			Debug.LogWarning($"BuildType isn't specified!");
			AddEmptyLogger();
		}

		AddEvents();
		AddJsonNetworkConfig(JsonConfigSettings);
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
		AddLocalLeaderboard();
		AddSingleFileLocalizationParser(LocalizationParserSettings);
		AddSaveLocalization(LocalizationSettings);
		AddUnityAnalytics();

		// Project-specific controller
		Container.Bind<ConcreteStateExample>().AsSingle();
		Container.Bind<SceneTracker>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();
	}
}
