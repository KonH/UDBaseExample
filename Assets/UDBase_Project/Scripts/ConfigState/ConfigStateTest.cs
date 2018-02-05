using UnityEngine;
using UDBase.Controllers.LogSystem;
using Zenject;

public class ConfigStateTest : MonoBehaviour {

	ConcreteStateExample _stateExample;
	ILog _log;

	[Inject]
	public void Init(ConcreteStateExample stateExample, ILog log) {
		_stateExample = stateExample;
		_log = log;
	}

	void Start () {
		var configValue = _stateExample.GetConfigData();
		_log.MessageFormat(LogTags.Common, "Config value: '{0}'", configValue);

		var saveValue = _stateExample.GetSavedData();
		_log.MessageFormat(LogTags.Common, "Saved data: {0}", saveValue);

		_stateExample.SetSavedData(saveValue + 1);

		var saveValueAfter = _stateExample.GetSavedData();
		_log.MessageFormat(LogTags.Common, "Saved data after change: {0}", saveValueAfter);
	}
}
