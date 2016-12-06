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
			case ItemTypes.Common:
			{
				var itemInfo = Config.GetItem<CommonItemInfo>(item.Name);	
				if( itemInfo != null ) {
					return "price: " + itemInfo.Price;
				}
			}
			break;
			
			case ItemTypes.Weapon:
				{
					var itemInfo = Config.GetItem<WeaponItemInfo>(item.Name);	
					if( itemInfo != null ) {
						return string.Format("price: {0}, damage: {1})", itemInfo.Price, itemInfo.Damage);
					}
				}
			break;

			case ItemTypes.Armor:
				{
					var armorState = item.As<ArmorItem>();
					var itemInfo = Config.GetItem<ArmorItemInfo>(item.Name);	
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
