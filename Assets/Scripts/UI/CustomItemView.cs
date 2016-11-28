﻿using UnityEngine;
using System.Collections;
using UDBase.Controllers.InventorySystem;
using UDBase.Controllers.InventorySystem.UI;
using UDBase.Controllers.InfoSystem;

public class CustomItemView : ItemView<CustomItem> {

	public override void Init(CustomItem item) {
		if( NameText ) {
			var itemInfo = GetItemInfo(item);
			NameText.text = string.Format("{0} ({1})", item.Name, itemInfo);
		}
	}

	string GetItemInfo(CustomItem item) {
		switch( item.Type ) {
			case ItemInfo.Common:
			{
				var itemInfo = Info.GetInfo<CommonItem>(item.Name);	
				if( itemInfo != null ) {
					return "price: " + itemInfo.Price;
				}
			}
			break;
			
			case ItemInfo.Weapon:
				{
					var itemInfo = Info.GetInfo<WeaponItem>(item.Name);	
					if( itemInfo != null ) {
						return string.Format("price: {0}, damage: {1})", itemInfo.Price, itemInfo.Damage);
					}
				}
			break;

			case ItemInfo.Armor:
				{
					var itemInfo = Info.GetInfo<ArmorItem>(item.Name);	
					if( itemInfo != null ) {
						return string.Format("price: {0}, durability: {1}/{2})", 
							itemInfo.Price, item.Durability, itemInfo.MaxDurability);
					}
				}
			break;
		}
		return "";
	}
}