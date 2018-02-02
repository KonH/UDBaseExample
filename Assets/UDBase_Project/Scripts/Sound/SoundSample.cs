using UnityEngine;
using UDBase.Controllers.ContentSystem;
using UDBase.Controllers.SoundSystem;
using Zenject;

public class SoundSample : MonoBehaviour {
	public ContentId ContentId;

	ISound _sound;

	[Inject]
	public void Init(ISound sound) {
		_sound = sound;
	}

	public void Play() {
		_sound.Play(ContentId, Random.Range(1.0f, 3.0f));
	}
}
