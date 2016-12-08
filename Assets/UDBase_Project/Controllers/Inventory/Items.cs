using UnityEngine;
using System.Collections;
using FullSerializer;

public static class ItemTypes {
	public const string Common = "common_item";
	public const string Weapon = "weapon_item";
	public const string Armor  = "armor_item";
}

public class CommonItemInfo {
	[fsProperty("price")]
	public int Price { get; private set; }
}

public class WeaponItemInfo:CommonItemInfo {
	[fsProperty("damage")]
	public int Damage { get; private set; }
}

public class ArmorItemInfo:CommonItemInfo {
	[fsProperty("max_durability")]
	public int MaxDurability { get; private set; }
}