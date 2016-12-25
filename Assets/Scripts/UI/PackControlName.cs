using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UDBase.Controllers.InventorySystem;
using UDBase.Controllers.InventorySystem.UI;

public class PackControlName : PackControl {
	public Text ButtonText = null;

	public override void Init(HolderPacksView owner, InventoryPack pack) {
		if( owner.HolderName == "player" ) {
			ButtonText.text = "Sell";
		} else {
			ButtonText.text = "Buy";
		}
	}
}
