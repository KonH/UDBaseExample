#if Scheme_TestScheme
using UnityEngine;
using System.Collections;
using UDBase.Common;
using UDBase.Controllers.LogSystem;
using UDBase.Controllers.ConfigSystem;
using UDBase.Controllers.SaveSystem;
using UDBase.Controllers.SceneSystem;
using UDBase.Controllers.InventorySystem;

public class ProjectScheme : Scheme {

	public ProjectScheme() {
		var config = 
			new JsonResourcesConfig().
			Add<ConcreteStateExampleConfig>("example_node").
			Add<ItemSourceConfigNode>("inventory_source").
			AddList<CommonItem>(ItemInfo.Common).
			AddList<WeaponItem>(ItemInfo.Weapon).
			AddList<ArmorItem>(ItemInfo.Armor);

		var save = 
			new JsonDataSave(true).
			Add<ConcreteStateExampleSave>("save_node").
			Add<InventorySaveNode>("inventory");

		// Default controllers
		AddController<Log>      (new UnityLog(), new VisualLog());
		AddController<Config>   (config);
		AddController<Save>     (save);
		AddController<Scene>    (new AsyncSceneLoader("Loading", "MainScene"));
		AddController<Inventory>(new BasicInventory());

		// Examples
		AddController<StateExample>(new ConcreteStateExample());
	}
}
#endif
