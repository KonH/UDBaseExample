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

public class ConcreteStateExample {
	ConcreteStateExampleConfig _configExample = null;
	ConcreteStateExampleSave _saveExample = null;

	ISave _save;

	public ConcreteStateExample(ISave save) {
		_save = save;
	}

	public string GetConfigData() {
		_configExample = Config.GetNode<ConcreteStateExampleConfig>();
		if ( _configExample != null ) {
			return _configExample.Value;
		}
		return "";
	}

	public int GetSavedData() {
		_saveExample = _save.GetNode<ConcreteStateExampleSave>();
		return _saveExample.IntValue;
	}

	public void SetSavedData(int value) {
		if ( _saveExample == null ) {
			_saveExample = new ConcreteStateExampleSave();
		}
		_saveExample.IntValue = value;
		_save.SaveNode(_saveExample);
	}
}
