﻿using FullSerializer;
using UDBase.Controllers.ConfigSystem;
using UDBase.Controllers.InventorySystem;

public static class ItemTypes {
	public const string Common  = "common_item";
	public const string Weapon  = "weapon_item";
	public const string Armor   = "armor_item";
	public const string Packs   = "packs";
	public const string Money   = "money";
	public const string Potions = "potions"; 
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

public class PackInfo {
	[fsProperty("price")]
	public int Price { get; private set; }
}

public static class ItemHelper {
	public static int GetItemPriceSelector(InventoryItem item) {
		return GetItemPrice(item.Type, item.Name);
	}

	public static int GetPackPriceSelector(InventoryPack pack) {
		return GetPackPrice(pack.Name);
	}

	static int GetItemPrice(string type, string name) {
		CommonItemInfo itemInfo = null;
		switch( type ) {
			case ItemTypes.Common: itemInfo = Config.GetItem<CommonItemInfo>(name);	break;
			case ItemTypes.Weapon: itemInfo = Config.GetItem<WeaponItemInfo>(name); break;
			case ItemTypes.Armor:  itemInfo = Config.GetItem<ArmorItemInfo>(name);  break;
		}
		if( itemInfo != null ) {
			return itemInfo.Price;
		}
		return 0;
	}

	static int GetPackPrice(string name) {
		PackInfo packInfo = Config.GetItem<PackInfo>(name);
		if( packInfo != null ) {
			return packInfo.Price;
		}
		return 0;
	}
}