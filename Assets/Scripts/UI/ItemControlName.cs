using UnityEngine.UI;
using UDBase.Controllers.InventorySystem;
using UDBase.Controllers.InventorySystem.UI;

public class ItemControlName : ItemControl {
	public Text ButtonText = null;

	public override void Init(HolderItemsView owner, InventoryItem item) {
		if( owner.HolderName == "player" ) {
			ButtonText.text = "Sell";
		} else {
			ButtonText.text = "Buy";
		}
	}
}
