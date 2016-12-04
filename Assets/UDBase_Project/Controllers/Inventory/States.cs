using UnityEngine;
using System.Collections;
using UDBase.Controllers.InventorySystem;
using Newtonsoft.Json;

public class ArmorState:InventoryItem {
	[JsonProperty("durability")]
	public int Durability = 0;
}
