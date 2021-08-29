using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFX : MonoBehaviour {

	public AudioClip[] fxs;
	private AudioSource audioSource;

	void Start() {
		audioSource = GetComponent<AudioSource>();
	}

	public void FXCollisionSound() {
		audioSource.clip = fxs[0];
		audioSource.Play();
	}

	public void FXMusicGameOver() {
		audioSource.clip = fxs[1];
		audioSource.Play();
	}
}
