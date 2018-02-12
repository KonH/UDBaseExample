using UnityEngine;
using UnityEngine.UI;
using UDBase.UI.Common;
using Zenject;

public class TestDialog : MonoBehaviour {

	public int MaxDepth = 3;
	public Button MoreButton = null;
	public Vector3 Offset;

	[Inject]
	public void Init(UIManager manager) {
		var curDepth = manager.OverlayDepth;
		MoreButton.interactable = curDepth < MaxDepth;
		transform.localPosition += Offset * curDepth;
	}
}
