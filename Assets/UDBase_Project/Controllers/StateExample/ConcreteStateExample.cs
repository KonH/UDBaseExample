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

	IConfig _config;
	ISave _save;

	public ConcreteStateExample(IConfig config, ISave save) {
		_config = config;
		_save = save;
	}

	public string GetConfigData() {
		_configExample = _config.GetNode<ConcreteStateExampleConfig>();
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
