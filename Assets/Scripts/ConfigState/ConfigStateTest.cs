using UnityEngine;
using System.Collections;
using UDBase.Controllers.LogSystem;

public class ConfigStateTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		var configValue = StateExample.GetConfigData();
		Log.MessageFormat("Config value: '{0}'", LogTags.Common, configValue);

		var saveValue = StateExample.GetSavedData();
		Log.MessageFormat("Saved data: {0}", LogTags.Common, saveValue);

		StateExample.SetSavedData(saveValue + 1);

		var saveValueAfter = StateExample.GetSavedData();
		Log.MessageFormat("Saved data after change: {0}", LogTags.Common, saveValueAfter);
	}
}
