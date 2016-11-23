using UnityEngine;
using System.Collections;
using UDBase.Controllers.InfoSystem;

public class InfoTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		var data = Info.GetInfo<TestData>("123");
		Debug.Log(data.Data);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
