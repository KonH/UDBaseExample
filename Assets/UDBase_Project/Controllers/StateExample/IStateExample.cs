using UDBase.Controllers;

public interface IStateExample : IController {

	string GetConfigData();
	int    GetSavedData();
	void   SetSavedData(int value);
}
