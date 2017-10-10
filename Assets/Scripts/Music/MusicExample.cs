using UnityEngine;
using UDBase.Controllers.MusicSystem;

public class MusicExample : MonoBehaviour {

	public void Pause() {
		Music.Pause();
	}

	public void UnPause() {
		Music.UnPause();
	}
}
