using UDBase.Controllers.SceneSystem;
using Zenject;

public class DirectSceneInstaller : MonoInstaller {
	public override void InstallBindings() {
		Container.Bind<IScene>().To<DirectSceneLoader>().AsSingle();
	}
}
