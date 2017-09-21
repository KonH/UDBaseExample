using UnityEngine;
using UDBase.Controllers.ContentSystem;
using UDBase.Controllers.SoundSystem;

public class SoundSample : MonoBehaviour {
	public ContentId ContentId;

	public void Play() {
		Sound.Play(ContentId, Random.Range(1.0f, 3.0f));
	}
}
