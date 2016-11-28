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
		// Default controllers
		AddController<Log>      (new UnityLog(), new VisualLog());
		AddController<Config>   (new JsonResourcesConfig());
		AddController<Save>     (new JsonDataSave(true));
		AddController<Scene>    (new AsyncSceneLoader("Loading", "MainScene"));
		AddController<Inventory>(new CustomInventory());

		// Examples
		AddController<StateExample>(new ConcreteStateExample());

		var infos = new IInfoBase[3];
		infos[0] = new ConfigInfoHolder<CommonItem, CommonItemInfo>();
		infos[1] = new ConfigInfoHolder<WeaponItem, WeaponItemInfo>();
		infos[2] = new ConfigInfoHolder<ArmorItem, ArmorItemInfo>();
		AddController(new Info(), infos);
	}
}
#endif
