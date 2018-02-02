using UDBase.Controllers.SaveSystem;
using Zenject;

public class JsonSaveInstaller : MonoInstaller {
	public Save.JsonSettings Settings;

	public override void InstallBindings() {
		Container.BindInstance(Settings);
		Container.Bind<ISave>().To<FsJsonDataSave>().AsSingle();
	}
}
