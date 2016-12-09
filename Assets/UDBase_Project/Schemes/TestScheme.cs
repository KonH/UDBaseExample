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
			new FsJsonResourcesConfig().
			AddNode<ConcreteStateExampleConfig>("example_node").
			AddNode<ItemSourceConfigNode>("inventory_source").
			AddList<CommonItemInfo>(ItemTypes.Common).
			AddList<WeaponItemInfo>(ItemTypes.Weapon).
			AddList<ArmorItemInfo>(ItemTypes.Armor);

		var save = 
			new FsJsonDataSave(true).
			AddNode<ConcreteStateExampleSave>("save_node").
			AddNode<InventorySaveNode>("inventory");

		var transition = new TradeTransitionHelper("money", ItemHelper.GetPriceSelector);

		var inventory =
			new BasicInventory(transition).
			AddType<ArmorItem>(ItemTypes.Armor);

		// Default controllers
		AddController<Log>      (new UnityLog(), new VisualLog());
		AddController<Config>   (config);
		AddController<Save>     (save);
		AddController<Scene>    (new AsyncSceneLoader("Loading", "MainScene"));
		AddController<Inventory>(inventory);

		// Examples
		AddController<StateExample>(new ConcreteStateExample());
	}
}
#endif
