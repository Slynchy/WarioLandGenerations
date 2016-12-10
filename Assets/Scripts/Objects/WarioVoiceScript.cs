using UnityEngine;
using System.Collections;

public class WarioVoiceScript : MonoBehaviour {

	private string[] SOUNDS;
	public AudioClip[] SoundFiles;

	private AudioSource audsrc;

	// Use this for initialization
	void Start () {
		audsrc = this.GetComponent<AudioSource> ();

		SOUNDS = new string[SoundFiles.Length];
		for (int i = 0; i < SOUNDS.Length; i++) {
			SOUNDS [i] = SoundFiles [i].name;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PlaySound(string _snd)
	{
		if (SOUNDS == null)
			return;
		AudioClip result = null;
		for (int i = 0; i < SOUNDS.Length; i++) {
			if (_snd == SOUNDS [i]) {
				result = SoundFiles [i];
				break;
			}
		}
		if (result == null)
			return;
		audsrc.PlayOneShot(result);
	}

	public void PlaySFX(AudioClip _clp){
		audsrc.PlayOneShot (_clp);
	}
}
