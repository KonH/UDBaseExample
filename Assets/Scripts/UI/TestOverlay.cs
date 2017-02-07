using UnityEngine;
using UnityEngine.UI;
using UDBase.UI.Common;

public class TestOverlay : MonoBehaviour {

	public int MaxDepth = 3;
	public Button MoreButton = null;
	public UIElement NextOverlay = null;
	public Vector3 Offset;

	void Start () {
		var curDepth = UIManager.Current.OverlayDepth;
		if( curDepth < MaxDepth ) {
			MoreButton.onClick.AddListener(() => OnClick());
		} else {
			MoreButton.interactable = false;
		}
		transform.localPosition += Offset * curDepth;
	}
	
	void OnClick() {
		var go = Instantiate(NextOverlay.gameObject) as GameObject;
		UIManager.Current.ShowOverlay(go.GetComponent<UIElement>());
	}
}
