using UDBase.Controllers.InventorySystem;
using UDBase.Controllers.InventorySystem.UI;
using UDBase.Controllers.ConfigSystem;

public class CustomPackView : PackView {

	public override void Init(HolderPacksView owner, InventoryPack pack) {
		if( NameText ) {
			var packInfo = GetPackInfo(pack);
			NameText.text = string.Format("{0} ({1})", pack.Name, packInfo);
		}
		InitCount(pack);
		InitControls(owner, pack);
	}

	string GetPackInfo(InventoryPack pack) {
		PackInfo packInfo = Config.GetItem<PackInfo>(pack.Name);
		return "price: " + packInfo.Price;
	}
}
