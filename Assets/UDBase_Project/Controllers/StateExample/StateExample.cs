using UnityEngine;
using System.Collections;
using UDBase.Components;

public class StateExample : ComponentHelper<IStateExample> {

	public static string GetConfigData() {
		if( Instance != null ) {
			return Instance.GetConfigData();
		}
		return "";
	}

	public static int GetSavedData() {
		if( Instance != null ) {
			return Instance.GetSavedData();
		}
		return -1;
	}
}
