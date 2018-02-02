using UnityEngine;
using UnityEngine.UI;
using UDBase.UI.Common;

public class TestDialog : MonoBehaviour {

	public int MaxDepth = 3;
	public Button MoreButton = null;
	public Vector3 Offset;

	void Awake () {
		var curDepth = UIManager.Current.OverlayDepth;
		MoreButton.interactable = curDepth < MaxDepth;
		transform.localPosition += Offset * curDepth;
	}
}
