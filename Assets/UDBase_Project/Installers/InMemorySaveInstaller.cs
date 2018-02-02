using UDBase.Controllers.SaveSystem;
using Zenject;

public class InMemorySaveInstaller : MonoInstaller {
	public override void InstallBindings() {
		Container.Bind<ISave>().To<InMemorySave>().AsSingle();
	}
}
