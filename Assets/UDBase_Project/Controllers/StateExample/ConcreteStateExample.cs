using UnityEngine;
using System.Collections;
using UDBase.Components.Config;

public class ConcreteStateExample : IStateExample {

	public class ConcreteStateExampleConfig:IConfigNode {

		public string Name { get { return "example_node"; } }

		public string Value = "";
	}

	public void Init() {}

	public string GetConfigData()
	{
		var config = Config.GetNode<ConcreteStateExampleConfig>();
		if( config != null ) {
			return config.Value;
		}
		return "";
	}

	public int GetSavedData()
	{
		return -1;
	}
}
