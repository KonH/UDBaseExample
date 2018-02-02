using UDBase.Controllers.ContentSystem;
using Zenject;

public class AssetBundleContentInstaller : MonoInstaller {
	public AssetBundleContentController.Settings Settings;

	public override void InstallBindings() {
		Container.Bind<AssetBundleHelper>().FromNewComponentOnNewGameObject().AsSingle();
		Container.BindInstance(Settings);
		Container.Bind<IContent>().To<AssetBundleContentController>().AsSingle();
	}
}
