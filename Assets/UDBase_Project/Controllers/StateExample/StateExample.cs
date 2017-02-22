using UDBase.Controllers;

public class StateExample : ControllerHelper<IStateExample> {

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

	public static void SetSavedData(int value) {
		if( Instance != null ) {
			Instance.SetSavedData(value);
		}
	}
}
