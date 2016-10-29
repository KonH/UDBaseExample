#if Scheme_ConfigSaveScheme
using UnityEngine;
using System.Collections;
using UDBase.Common;
using UDBase.Controllers.Log;
using UDBase.Controllers.Config;
using UDBase.Controllers.Save;

public class ProjectScheme : Scheme {

	public ProjectScheme() {
		AddComponent(new Log(), new UnityLog(), new VisualLog());
		AddComponent(new Config(), new JsonResourcesConfig());
		AddComponent(new Save(), new JsonDataSave());
		AddComponent(new StateExample(), new ConcreteStateExample());
	}
}
#endif
