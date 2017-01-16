using UnityEngine;
using System.Collections;
using UDBase.Controllers.ConfigSystem;
using UDBase.Controllers.SaveSystem;
using FullSerializer;

public class ConcreteStateExampleConfig {
	[fsProperty("value")]
	public string Value = "";
}

public class ConcreteStateExampleSave {
	[fsProperty("int_value")]
	public int IntValue = 0;
}

public class ConcreteStateExample : IStateExample {

	public void Init() {}
	public void PostInit() {}

	ConcreteStateExampleConfig _config = null;
	ConcreteStateExampleSave   _save   = null;

	public string GetConfigData()
	{
		_config = Config.GetNode<ConcreteStateExampleConfig>();
		if( _config != null ) {
			return _config.Value;
		}
		return "";
	}

	public int GetSavedData()
	{
		_save = Save.GetNode<ConcreteStateExampleSave>();
		return _save.IntValue;
	}

	public void SetSavedData(int value) {
		if( _save == null ) {
			_save = new ConcreteStateExampleSave();
		}
		_save.IntValue = value;
		Save.SaveNode(_save);
	}
}
