using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UDBase.Controllers.InventorySystem;

public struct ItemChanged {
	public string        HolderName { get; private set; }
	public InventoryItem Item       { get; private set; }

	public ItemChanged(string holderName, InventoryItem item) {
		HolderName = holderName;
		Item = item;
	}
}
