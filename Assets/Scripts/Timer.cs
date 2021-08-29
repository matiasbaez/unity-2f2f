using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public MotorRuta motorRuta;
	public Text txtTime;
	public Text txtDistance;
	public Text txtFinalDistance;

	public float time = 120;
	public float distance;

	// Use this for initialization
	void Start () {
		motorRuta = GameObject.Find("MotorCarretera").GetComponent<MotorRuta>();
		txtTime.text = "02:00";
		txtDistance.text = "0";
	}
	
	// Update is called once per frame
	void Update () {
		if (motorRuta.inGame && !motorRuta.gameOver) TimeAndDistance();
		if (time <= 0 && !motorRuta.gameOver) {
			motorRuta.gameOver = true;
			motorRuta.GameOverStates();
			txtFinalDistance.text = ((int)distance).ToString() + " M";
			txtTime.text = "00:00";
		}
	}

	void TimeAndDistance() {
		distance += Time.deltaTime * motorRuta.velocity;
		txtDistance.text = ((int)distance).ToString();
		time -= Time.deltaTime;
		int minutes = (int)time/60;
		int seconds = (int)time%60;
		txtTime.text = minutes.ToString() + ":" + seconds.ToString().PadLeft(2, '0');
	}
}
