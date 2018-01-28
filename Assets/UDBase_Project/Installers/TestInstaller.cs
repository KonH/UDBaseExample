using Zenject;

public class TestInstaller : MonoInstaller {
	public override void InstallBindings() {
		Container.Bind<IStateExample>().To<ConcreteStateExample>().AsSingle();
	}
}
