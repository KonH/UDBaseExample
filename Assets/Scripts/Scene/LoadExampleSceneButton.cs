using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UDBase.Controllers.Scene;

[RequireComponent(typeof(Button))]
public class LoadExampleSceneButton : MonoBehaviour {
	public string ExampleName = "";

	void Start () {
		GetComponent<Button>().onClick.AddListener(OnClick);
	}
	

	void OnClick () {
		Scene.LoadScene("Example", ExampleName);
	}
}
