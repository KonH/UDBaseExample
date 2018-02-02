using UDBase.Controllers.UTime;
using Zenject;

public class NetworkTimeInstaller : MonoInstaller {
	public NetworkTime.Settings Settings;

	public override void InstallBindings() {
		Container.BindInstance(Settings);
		Container.Bind<ITime>().To<NetworkTime>().AsSingle();
	}
}
