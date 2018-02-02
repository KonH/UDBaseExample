using UDBase.Controllers.LeaderboardSystem;
using Zenject;

public class WebLeaderboardInstaller : MonoInstaller {
	public WebLeaderboard.Settings Settings;

	public override void InstallBindings() {
		Container.BindInstance(Settings);
		Container.Bind<ILeaderboard>().To<WebLeaderboard>().AsSingle();
	}
}
