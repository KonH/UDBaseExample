using UDBase.Controllers.InventorySystem;
using UDBase.Controllers.InventorySystem.UI;
using UDBase.Controllers.ConfigSystem;
using UDBase.Controllers.EventSystem;

public class CustomItemView : ItemView {

	HolderItemsView _owner = null;
	InventoryItem   _item  = null;

	void OnEnable() {
		Events.Subscribe<ItemChanged>(this, OnItemChanged);
	}

	void OnItemChanged(ItemChanged e) {
		if( _owner && (_item != null) ) {
			if( (e.HolderName == _owner.HolderName) && (e.Item.Name == _item.Name) ) {
				Init(_owner, e.Item);
			}
		}
	}

	public override void Init(HolderItemsView owner, InventoryItem item) {
		_owner = owner;
		_item  = item;
		if( NameText ) {
			var itemInfo = GetItemInfo(item);
			NameText.text = string.Format("{0} ({1})", item.Name, itemInfo);
		}
		InitControls(owner, item);
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
					var armorState = item as ArmorItem;
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
