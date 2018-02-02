using UDBase.Controllers.EventSystem;
using Zenject;

public class EventInstaller : MonoInstaller {
	public override void InstallBindings() {
		Container.Bind<IEvent>().To<EventController>().AsSingle();
	}
}
