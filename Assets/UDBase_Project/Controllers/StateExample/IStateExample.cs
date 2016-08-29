using UnityEngine;
using System.Collections;
using UDBase.Components;

public interface IStateExample : IComponent {

	string GetConfigData();
	int    GetSavedData();
	void   SetSavedData(int value);
}
