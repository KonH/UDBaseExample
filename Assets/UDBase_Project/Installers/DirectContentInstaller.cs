using UDBase.Controllers.ContentSystem;
using Zenject;

public class DirectContentInstaller : MonoInstaller {
	public override void InstallBindings() {
		Container.Bind<IContent>().To<DirectContentController>().AsSingle();
	}
}
