using UnityEngine;
using System.Collections;
using UDBase.Controllers.ConfigSystem;
using UDBase.Controllers.SaveSystem;
using UDBase.Utils.Json;

public class ConcreteStateExample : IStateExample {

	class ConcreteStateExampleConfig:IJsonNode {

		public string Name { get { return "example_node"; } }

		public string Value = "";
	}

	class ConcreteStateExampleSave:IJsonNode {
		public string Name { get { return "save_node"; } }

		public int IntValue = 0;
	}

	public void Init() {}

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
		if( _save != null ) {
			return _save.IntValue;
		}
		return -1;
	}

	public void SetSavedData(int value) {
		if( _save == null ) {
			_save = new ConcreteStateExampleSave();
		}
		_save.IntValue = value;
		Save.SaveNode(_save);
	}
}
