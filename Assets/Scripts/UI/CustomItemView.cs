using UnityEngine;
using System.Collections;
using UDBase.Controllers.InventorySystem;
using UDBase.Controllers.InventorySystem.UI;
using UDBase.Controllers.ConfigSystem;

public class CustomItemView : ItemView {

	public override void Init(InventoryItem item) {
		if( NameText ) {
			var itemInfo = GetItemInfo(item);
			NameText.text = string.Format("{0} ({1})", item.Name, itemInfo);
		}
	}

	string GetItemInfo(InventoryItem item) {
		switch( item.Type ) {
			case ItemInfo.Common:
			{
				var itemInfo = Config.GetItem<CommonItem>(item.Name);	
				if( itemInfo != null ) {
					return "price: " + itemInfo.Price;
				}
			}
			break;
			
			case ItemInfo.Weapon:
				{
					var itemInfo = Config.GetItem<WeaponItem>(item.Name);	
					if( itemInfo != null ) {
						return string.Format("price: {0}, damage: {1})", itemInfo.Price, itemInfo.Damage);
					}
				}
			break;

			case ItemInfo.Armor:
				{
					var armorState = item.As<ArmorState>();
					var itemInfo = Config.GetItem<ArmorItem>(item.Name);	
					if( itemInfo != null ) {
						return string.Format("price: {0}, durability: {1}/{2})", 
							itemInfo.Price, armorState.Durability, itemInfo.MaxDurability);
					}
				}
			break;
		}
		return "";
	}
}
