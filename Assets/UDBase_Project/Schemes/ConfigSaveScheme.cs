#if Scheme_ConfigSaveScheme
using UnityEngine;
using System.Collections;
using UDBase.Common;
using UDBase.Controllers.Log;
using UDBase.Controllers.Config;
using UDBase.Controllers.Save;

public class ProjectScheme : Scheme {

	public ProjectScheme() {
		AddController(new Log(), new UnityLog(), new VisualLog());
		AddController(new Config(), new JsonResourcesConfig());
		AddController(new Save(), new JsonDataSave());
		AddController(new StateExample(), new ConcreteStateExample());
	}
}
#endif
