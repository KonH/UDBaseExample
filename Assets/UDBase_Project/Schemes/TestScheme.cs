#if Scheme_TestScheme
using UDBase.Common;
using UDBase.Controllers.LogSystem;
using UDBase.Controllers.ConfigSystem;
using UDBase.Controllers.SaveSystem;
using UDBase.Controllers.SceneSystem;
using UDBase.Controllers.InventorySystem;
using UDBase.Controllers.EventSystem;
using UDBase.Controllers.ContentSystem;
using UDBase.Controllers.UTime;

public class ProjectScheme : Scheme {

	public ProjectScheme() {
		var config = 
			new FsJsonResourcesConfig().
			AddNode<ConcreteStateExampleConfig>("example_node").
			AddNode<ItemSourceConfigNode>("inventory_source").
			AddList<CommonItemInfo>(ItemTypes.Common).
			AddList<WeaponItemInfo>(ItemTypes.Weapon).
			AddList<ArmorItemInfo>(ItemTypes.Armor).
			AddList<PackInfo>(ItemTypes.Packs);

		var save = 
			new FsJsonDataSave(true, true).
			AddNode<ConcreteStateExampleSave>("save_node").
			AddNode<InventorySaveNode>("inventory").
			AddNode<RewardNode>("reward");

		var transition = new TradeTransitionHelper(
			ItemTypes.Money, ItemHelper.GetItemPriceSelector, ItemHelper.GetPackPriceSelector);

		var inventory =
			new BasicInventory(transition).
			AddType<ArmorItem>(ItemTypes.Armor);

		// Default controllers
		AddController<Log>      (new UnityLog(), new VisualLog());
		AddController<Config>   (config);
		AddController<Save>     (save);
		AddController<Scene>    (new AsyncSceneLoader("Loading", "MainScene"));
		AddController<Inventory>(inventory);
		AddController<Events>   (new EventController());
		AddController<Content>  (
			new DirectContentController(), 
			new AssetBundleContentController(AssetBundleMode.WebServer, "https://konh.github.io/Data/UDB/AssetBundles"));
		AddController<UTime>(
			new LocalTime(), 
			new NetworkTime("http://konh.strangled.net/dotnet_time/"), // For non-production test cases
			new NetworkTime("http://konh.strangled.net/erlang_time/")); // For non-production test cases

		// Examples
		AddController<StateExample>(new ConcreteStateExample());
	}
}
#endif
