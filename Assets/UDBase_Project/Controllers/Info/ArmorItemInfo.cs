using UnityEngine;
using System.Collections;
using UDBase.Controllers.InfoSystem;

[System.Serializable]
public class ArmorItem:CommonItem {
	public int MaxDurability { get { return maxDurability; } }

	[SerializeField]
	int maxDurability;
}

public class ArmorItemInfo:ConfigInfoNode<ArmorItem> {
	public override string Name { get { return ItemInfo.Armor; } }
}
