using UnityEngine;
using System.Collections;
using UDBase.Controllers.InventorySystem;

[System.Serializable]
public class TestPack : IInventoryPack {

	[SerializeField]
	public string name;
	[SerializeField]
	public int    count;

	public string Name { 
		get {
			return name;
		} 
		set {
			name = value;
		}
	}

	public int Count {
		get {
			return count;
		}
		set {
			count = value;
		}
	}
}
