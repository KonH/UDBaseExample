using UDBase.Controllers.InventorySystem;
using UDBase.Controllers.InventorySystem.UI;
using UDBase.Controllers.ConfigSystem;
using Zenject;

public class CustomPackView : PackView {
	IConfig _config;

	[Inject]
	public void PreInit(IConfig config) {
		_config = config;
	}

	public override void Init(HolderPacksView owner, InventoryPack pack) {
		if( NameText ) {
			var packInfo = GetPackInfo(pack);
			NameText.text = string.Format("{0} ({1})", pack.Name, packInfo);
		}
		InitCount(pack);
		InitControls(owner, pack);
	}

	string GetPackInfo(InventoryPack pack) {
		PackInfo packInfo = _config.GetItem<PackInfo>(pack.Name);
		return "price: " + packInfo.Price;
	}
}
