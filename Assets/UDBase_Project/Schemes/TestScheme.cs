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
using UDBase.Controllers.UserSystem;
using UDBase.Controllers.LeaderboardSystem;
using UDBase.Controllers.AudioSystem;
using UDBase.Controllers.SoundSystem;
using UDBase.Controllers.MusicSystem;

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
			AddNode<RewardNode>("reward").
			AddNode<UserSaveNode>("user").
			AddNode<AudioSaveNode>("audio");

		var transition = new TradeTransitionHelper(
			ItemTypes.Money, ItemHelper.GetItemPriceSelector, ItemHelper.GetPackPriceSelector);

		var inventory =
			new BasicInventory(transition).
			AddType<ArmorItem>(ItemTypes.Armor);

		// Default controllers
		AddController<Log>      (new UnityLog(), new VisualLog());
		AddController<Config>   (config);
		AddController<Save>     (save);
		AddController<Inventory>(inventory);
		AddController<Content>  (
			new DirectContentController(), 
			new AssetBundleContentController(AssetBundleMode.WebServer, "https://konh.github.io/Data/UDB/AssetBundles"));
	}
}
#endif
