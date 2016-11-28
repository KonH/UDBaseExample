using UnityEngine;
using System.Collections;
using UDBase.Controllers.InfoSystem;

[System.Serializable]
public class CommonItem:IInfoItem {
	public string Name  { get { return name;  } }
	public int    Price { get { return price; } }

	[SerializeField]
	protected string name;
	[SerializeField]
	int price;
}

public class CommonItemInfo:ConfigInfoNode<CommonItem> {
	public override string Name { get { return ItemInfo.Common; } }
}

