using UnityEngine;

public class TestSpawner : MonoBehaviour {
	public int Count = 10000;
	public bool Custom = false;

	void Start () {
		for( int i = 0; i < Count; i++ ) {
			var go = new GameObject("test");
			if( Custom ) {
				go.AddComponent<CustomUpdateExample>();
			} else {
				go.AddComponent<UpdateExample>();
			}
		}	
	}
}
