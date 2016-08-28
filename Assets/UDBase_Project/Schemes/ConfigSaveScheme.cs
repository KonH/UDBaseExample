#if Scheme_ConfigSaveScheme
using UnityEngine;
using System.Collections;
using UDBase.Common;
using UDBase.Components.Log;
using UDBase.Components.Config;

public class ProjectScheme : Scheme {

	public ProjectScheme() {
		AddComponent(new Log(), new Log_Unity());
		AddComponent(new Config(), new JsonResourcesConfig());
		AddComponent(new StateExample(), new ConcreteStateExample());
	}
}
#endif
