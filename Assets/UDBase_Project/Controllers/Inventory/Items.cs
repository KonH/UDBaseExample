using UnityEngine;
using System.Collections;
using Newtonsoft.Json;

public static class ItemInfo {
	public const string Common = "common_item";
	public const string Weapon = "weapon_item";
	public const string Armor  = "armor_item";
}

public class CommonItem {
	[JsonProperty("price")]
	public int Price { get; private set; }
}

public class WeaponItem:CommonItem {
	[JsonProperty("damage")]
	public int Damage { get; private set; }
}

public class ArmorItem:CommonItem {
	[JsonProperty("max_durability")]
	public int MaxDurability { get; private set; }
}


// TODO: Use?
/*
public class ArmorItemState: InventoryItem, IClonableItem<CustomItem> {

	public ArmorItemState(string name, string type, int durability):base(name, type) {
		Durability = durability;
	}

	public override void Init() {
		if ( type == ItemInfo.Armor ) {
			var info = Info.GetInfo<ArmorItem>(name);
			durability = info.MaxDurability;
		}
	}

	public override void Load() {
		if ( type == ItemInfo.Armor ) {
			var info = Info.GetInfo<ArmorItem>(name);
			durability = Mathf.Min(durability, info.MaxDurability);
		}
	}

	public new ArmorItemState Clone() {
		return new CustomItem(Name, Type, Durability);
	}
}*/