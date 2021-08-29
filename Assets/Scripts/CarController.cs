using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {

	public GameObject car;
	public float turnAngle;
	public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float turnZ = 0;
		transform.Translate(Vector3.right * Input.GetAxis("Horizontal") *  speed * Time.deltaTime);
		turnZ = Input.GetAxis("Horizontal") * turnAngle;
		car.transform.rotation = Quaternion.Euler(0, 0, turnZ);
	}
}
