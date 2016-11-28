using UnityEngine;
using System.Collections;
using UDBase.Controllers.InfoSystem;

[System.Serializable]
public class WeaponItem:CommonItem {
	public int Damage { get { return damage; } }

	[SerializeField]
	int damage;
}

public class WeaponItemInfo:ConfigInfoNode<WeaponItem> {
	public override string Name { get { return ItemInfo.Weapon; } }
}

