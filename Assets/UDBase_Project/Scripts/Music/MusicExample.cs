using UnityEngine;
using UDBase.Controllers.MusicSystem;
using Zenject;

public class MusicExample : MonoBehaviour {
	IMusic _music;

	[Inject]
	public void Init(IMusic music) {
		_music = music;
	}

	public void Pause() {
		_music.Pause();
	}

	public void UnPause() {
		_music.UnPause();
	}
}
