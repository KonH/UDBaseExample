using UnityEngine;
using System.Collections;
using UDBase.Components.Log;

public class ConfigStateTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		var configValue = StateExample.GetConfigData();
		Log.Message("Config value: '" + configValue + "'");

		var saveValue = StateExample.GetSavedData();
		Log.Message("Saved data: " + saveValue);

		StateExample.SetSavedData(saveValue + 1);

		var saveValueAfter = StateExample.GetSavedData();
		Log.Message("Saved data after change: " + saveValueAfter);
	}
}
