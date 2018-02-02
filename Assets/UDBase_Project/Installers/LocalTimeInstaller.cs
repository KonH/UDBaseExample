using UDBase.Controllers.UTime;
using Zenject;

public class LocalTimeInstaller : MonoInstaller {
	public override void InstallBindings() {
		Container.Bind<ITime>().To<LocalTime>().AsSingle();
	}
}
