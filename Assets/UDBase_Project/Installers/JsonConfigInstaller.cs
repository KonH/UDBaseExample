using UDBase.Controllers.ConfigSystem;
using Zenject;

public class JsonConfigInstaller : MonoInstaller {
	public Config.JsonSettings JsonConfigSettings;

	public override void InstallBindings() {
		Container.BindInstance(JsonConfigSettings);
		Container.Bind<IConfig>().To<FsJsonResourcesConfig>().AsSingle();
	}
}
