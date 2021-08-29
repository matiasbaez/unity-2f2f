using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bus : MonoBehaviour {

	public Timer timer;
	public SoundFX soundFx;

	void OnTriggerEnter2D(Collider2D colision) {
		if (colision.GetComponent<Car>() != null) {
			soundFx.FXCollisionSound();
			timer.time = timer.time - 20;
			Destroy(gameObject);
		}
	}
}
