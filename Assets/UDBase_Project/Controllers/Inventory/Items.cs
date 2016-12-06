using UnityEngine;
using System.Collections;
using Newtonsoft.Json;

public static class ItemTypes {
	public const string Common = "common_item";
	public const string Weapon = "weapon_item";
	public const string Armor  = "armor_item";
}

public class CommonItemInfo {
	[JsonProperty("price")]
	public int Price { get; private set; }
}

public class WeaponItemInfo:CommonItemInfo {
	[JsonProperty("damage")]
	public int Damage { get; private set; }
}

public class ArmorItemInfo:CommonItemInfo {
	[JsonProperty("max_durability")]
	public int MaxDurability { get; private set; }
}