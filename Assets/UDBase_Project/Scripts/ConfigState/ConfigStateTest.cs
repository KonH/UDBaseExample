using UnityEngine;
using UDBase.Controllers.LogSystem;
using Zenject;

public class ConfigStateTest : MonoBehaviour, ILogContext {

	ConcreteStateExample _stateExample;
	ILog _log;

	[Inject]
	public void Init(ConcreteStateExample stateExample, ILog log) {
		_stateExample = stateExample;
		_log = log;
	}

	void Start () {
		var configValue = _stateExample.GetConfigData();
		_log.MessageFormat(this, "Config value: '{0}'", configValue);

		var saveValue = _stateExample.GetSavedData();
		_log.MessageFormat(this, "Saved data: {0}", saveValue);

		_stateExample.SetSavedData(saveValue + 1);

		var saveValueAfter = _stateExample.GetSavedData();
		_log.MessageFormat(this, "Saved data after change: {0}", saveValueAfter);
	}
}
