using UnityEngine;
using System.Collections;
using UDBase.Controllers.InventorySystem;
using UDBase.Controllers.ConfigSystem;
using Newtonsoft.Json;

public class ArmorItem:InventoryItem {

	[JsonProperty("durability")]
	public int Durability = 0;

	public ArmorItem() {}

	public ArmorItem(string name, string type, int durability):base(name, type) {
		Durability = durability;
	}

	public override void Init() {
		var info = Config.GetItem<ArmorItemInfo>(Name);
		var maxDurability = info != null ? info.MaxDurability : 0;
		Durability = maxDurability;
	}

	public override InventoryItem Clone() {
		return new ArmorItem(Name, Type, Durability);
	}
}
