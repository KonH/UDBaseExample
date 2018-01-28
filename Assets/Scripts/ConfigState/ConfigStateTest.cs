using UnityEngine;
using UDBase.Controllers.LogSystem;
using Zenject;

public class ConfigStateTest : MonoBehaviour {

	IStateExample _stateExample;

	[Inject]
	void Init(IStateExample stateExample) {
		_stateExample = stateExample;
	}

	void Start () {
		var configValue = _stateExample.GetConfigData();
		Log.MessageFormat("Config value: '{0}'", LogTags.Common, configValue);

		var saveValue = _stateExample.GetSavedData();
		Log.MessageFormat("Saved data: {0}", LogTags.Common, saveValue);

		_stateExample.SetSavedData(saveValue + 1);

		var saveValueAfter = _stateExample.GetSavedData();
		Log.MessageFormat("Saved data after change: {0}", LogTags.Common, saveValueAfter);
	}
}
