#if Scheme_TestScheme
using UnityEngine;
using System.Collections;
using UDBase.Common;
using UDBase.Controllers.LogSystem;
using UDBase.Controllers.ConfigSystem;
using UDBase.Controllers.SaveSystem;
using UDBase.Controllers.SceneSystem;
using UDBase.Controllers.InventorySystem;
using UDBase.Controllers.InfoSystem;

public class ProjectScheme : Scheme {

	public ProjectScheme() {
		AddController(new Log(), new UnityLog(), new VisualLog());
		AddController(new Config(), new JsonResourcesConfig());
		AddController(new Save(), new JsonDataSave(true));
		AddController(new StateExample(), new ConcreteStateExample());
		AddController(new Scene(), new AsyncSceneLoader("Loading", "MainScene"));
		AddController(new Inventory(), new SimpleInventory());

		var infos = new IInfoBase[1];
		infos[0] = new ConfigInfoHolder<TestData>();
		AddController(new Info(), infos);
	}
}
#endif
