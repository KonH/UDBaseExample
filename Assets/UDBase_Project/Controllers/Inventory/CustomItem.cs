using UnityEngine;
using System.Collections;
using UDBase.Controllers.InventorySystem;
using UDBase.Controllers.InfoSystem;

[System.Serializable]
public class CustomItem : SimpleItem, IClonableItem<CustomItem> {
	public int Durability { get { return durability; } }

	[SerializeField]
	int durability;

	public CustomItem() {}

	public CustomItem(string name, string type, int durability):base(name, type) {
		this.durability = durability;
	}

	public override void Init() {
		if ( type == ItemInfo.Armor ) {
			var info = Info.GetInfo<ArmorItem>(name);
			durability = info.MaxDurability;
		}
	}

	public override void Load() {
		if ( type == ItemInfo.Armor ) {
			var info = Info.GetInfo<ArmorItem>(name);
			durability = Mathf.Min(durability, info.MaxDurability);
		}
	}

	public new CustomItem Clone() {
		return new CustomItem(Name, Type, Durability);
	}
}
