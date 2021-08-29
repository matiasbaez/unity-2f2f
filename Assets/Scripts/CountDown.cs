using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDown : MonoBehaviour {

	public MotorRuta motorRuta;
	public Sprite[] numbers;
	public SpriteRenderer countNumbers;
	public GameObject carContoller;
	public GameObject countDown;
	public GameObject car;

	// Use this for initialization
	void Start () {
		InitComponents();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void InitComponents() {
		motorRuta = GameObject.Find("MotorCarretera").GetComponent<MotorRuta>();
		countNumbers = GameObject.Find("CountNumbers").GetComponent<SpriteRenderer>();
		carContoller = GameObject.Find("CarController");
		car = GameObject.Find("Car");
		countDown = GameObject.Find("CountDown");

		Count_Down();
	}

	void Count_Down() {
		StartCoroutine("StartCountDown");
	}

	// Corutine for the count down
	IEnumerator StartCountDown() {
		carContoller.GetComponent<AudioSource>().Play();
		yield return new WaitForSeconds(2);

		countNumbers.sprite = numbers[1];
		this.gameObject.GetComponent<AudioSource>().Play();
		yield return new WaitForSeconds(1);

		countNumbers.sprite = numbers[2];
		this.gameObject.GetComponent<AudioSource>().Play();
		yield return new WaitForSeconds(1);

		countNumbers.sprite = numbers[3];
		motorRuta.inGame = true;
		countNumbers.GetComponent<AudioSource>().Play();
		car.GetComponent<AudioSource>().Play();
		yield return new WaitForSeconds(1);

		countDown.SetActive(false);
	}
}
