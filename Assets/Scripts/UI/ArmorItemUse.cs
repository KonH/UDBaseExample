using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UDBase.Controllers.InventorySystem;
using UDBase.Controllers.InventorySystem.UI;
using UDBase.Controllers.EventSystem;

public class ArmorItemUse : ItemControl {
	public Button UseButton = null;

	string        _holderName = null;
	InventoryItem _item       = null;

	void Awake() {
		UseButton.onClick.AddListener(() => UseItem());
	}

	public override void Init(HolderItemsView owner, InventoryItem item) {
		_holderName = owner.HolderName;
		_item = item;
		var canUse = (owner.HolderName == "player") && (item.Type == ItemTypes.Armor);
		gameObject.SetActive(canUse);
	}

	void UseItem() {
		var armorItem = _item as ArmorItem;
		if( armorItem != null ) {
			armorItem.Durability-= 10;
			Events.Fire<ItemChanged>(new ItemChanged(_holderName, _item));
			Inventory.SaveChanges();
		}
		if( armorItem.Durability <= 0 ) {
			Inventory.RemoveItem(_holderName, _item);
		}
	}
}
