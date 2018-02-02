using UnityEngine;
using UDBase.Utils;

public class CustomUpdateExample : MonoBehaviour, ICustomUpdate
{
	void OnEnable() {
		UpdateHelper.SceneSubscribe(this);
	}

	void OnDisable() {
		UpdateHelper.SceneUnsubscribe(this);
	}

    public void CustomUpdate() {
	}
}
