using UDBase.Controllers.UserSystem;
using Zenject;

public class SaveUserInstaller : MonoInstaller {
	public override void InstallBindings() {
		Container.Bind<IUser>().To<SaveUser>().AsSingle();
	}
}
