using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UDBase.Controllers.LogSystem;
using Rotorz.Games.Reflection;
using OneLine;

public class Example : MonoBehaviour {

	[System.Serializable]
	public class ExampleItem {
		[ClassImplements(typeof(ILogContext))]
		public ClassTypeReference Reference;
		public bool Field;
	}

	[OneLine]
	public List<ExampleItem> Items;
}
