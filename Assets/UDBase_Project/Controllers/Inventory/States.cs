using UDBase.Controllers.InventorySystem;
using UDBase.Controllers.ConfigSystem;
using FullSerializer;
using Zenject;

public class ArmorItem:InventoryItem {
	
	[fsProperty("durability")]
	public int Durability = 0;

	[Inject]
	IConfig _config;

	public ArmorItem() {}

	public ArmorItem(string name, string type, int durability):base(name, type) {
		Durability = durability;
	}

	public override void Init() {
		var info = _config.GetItem<ArmorItemInfo>(Name);
		var maxDurability = info != null ? info.MaxDurability : 0;
		Durability = maxDurability;
	}

	public override InventoryItem Clone() {
		return new ArmorItem(Name, Type, Durability);
	}
}
