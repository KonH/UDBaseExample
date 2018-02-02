using UDBase.Controllers.SceneSystem;
using Zenject;

public class AsyncSceneInstaller : MonoInstaller {
	public AsyncSceneLoader.Settings Settings;

	public override void InstallBindings() {
		Container.Bind<AsyncLoadHelper>().FromNewComponentOnNewGameObject().AsSingle();
		Container.BindInstance(Settings);
		Container.Bind<IScene>().To<AsyncSceneLoader>().AsSingle();
	}
}
