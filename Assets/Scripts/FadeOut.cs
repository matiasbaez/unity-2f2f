using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour {

	public Image fadeOutImg;
	public string[] scenes;

	// Use this for initialization
	void Start () {
		// For the fadeout
		fadeOutImg.CrossFadeAlpha(0, 1f, false);
	}

	public void Scene(int s) {
		fadeOutImg.CrossFadeAlpha(1, 1f, false);
		StartCoroutine(ChangeScene(scenes[s]));
	}

	IEnumerator ChangeScene(string scene) {
		yield return new WaitForSeconds(1);
		SceneManager.LoadScene(scene);
	}
}