using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorRuta : MonoBehaviour {

	public GameObject RutaContainer;
	public GameObject[] arrayRutas;
	public float velocity;
	public bool inGame;
	public bool gameOver;
	public GameObject oldRoad;
	public GameObject newRoad;
	public float roadSize;
	public GameObject maincamera;
	public GameObject car;
	public SoundFX soundFx;
	public GameObject panelGameOver;

	bool visibleOnScreen;
	Vector3 screenSizeLimit;
	int contRutas;
	int random;

	// Use this for initialization
	void Start () {
		StartGame();
	}
	
	// Update is called once per frame
	void Update () {
		if (inGame && !gameOver) {
			transform.Translate (Vector3.down * velocity * Time.deltaTime);
			if (oldRoad.transform.position.y + roadSize < screenSizeLimit.y && !visibleOnScreen) {
				visibleOnScreen = true;
				DestroyRoads();
			}
		}

	}

	void StartGame() {
		RutaContainer = GameObject.Find("RutaContainer");
		panelGameOver.SetActive(false);
		EngineVelocity();
		ScreenSize();
		FindRoads();
	}

	public void GameOverStates() {
		car.GetComponent<AudioSource>().Stop();
		soundFx.FXMusicGameOver();
		panelGameOver.SetActive(true);
	}

	// Set the container speed
	void EngineVelocity() {
		velocity = 16;
	}

	// Look for all roads in the scene
	void FindRoads() {
		arrayRutas = GameObject.FindGameObjectsWithTag("Ruta");
		for (int i = 0; i < arrayRutas.Length; i++) {
			arrayRutas[i].gameObject.transform.parent = RutaContainer.transform;
			arrayRutas[i].gameObject.SetActive(false);
			arrayRutas[i].gameObject.name = "RoadOFF_" + i;
		}
		CreateRoads();
	}

	// Instantiate the roads
	void CreateRoads() {
		contRutas++;
		random = Random.Range(0, arrayRutas.Length);
		GameObject road = Instantiate(arrayRutas[random]);
		road.SetActive(true);
		road.name = "Road" + contRutas;
		road.transform.parent = gameObject.transform;
		RoadPosition();
	}

	// Establish the road position
	void RoadPosition() {
		oldRoad = GameObject.Find("Road" + (contRutas-1));
		newRoad = GameObject.Find("Road" + contRutas);
		RoadSize();
		newRoad.transform.position = new Vector3(oldRoad.transform.position.x,
			oldRoad.transform.position.y + roadSize,
			0
		);
		visibleOnScreen = false;
	}

	void RoadSize() {
		for (int i = 0; i < oldRoad.transform.childCount; i++) {
			if (oldRoad.transform.GetChild (i).gameObject.GetComponent<Ruta>() != null) {
				float spriteSize = oldRoad.transform.GetChild (i).gameObject.GetComponent<SpriteRenderer> ().bounds.size.y;
				roadSize += spriteSize;
			}
		}
	}

	void ScreenSize() {
		screenSizeLimit = new Vector3(0, maincamera.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(0,0,0)).y - 0.5f ,0);
	}

	void DestroyRoads() {
		Destroy(oldRoad);
		roadSize = 0;
		oldRoad = null;
		CreateRoads();
	}
}
