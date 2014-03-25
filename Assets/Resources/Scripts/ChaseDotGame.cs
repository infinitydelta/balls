using UnityEngine;
using System.Collections;

public class ChaseDotGame : MonoBehaviour {
	Vector3 mousePos;
	float minScale = 0.5f;
	//public GameObject gameScript;
	float initialScale;
	float initialRange;
	float initialIntensity;
	float initialStartWidth;
	Game gameController;
	float lifeLeft = 5;
	// Use this for initialization
	void Start () {
		initialScale = GetComponent<Stretch>().myScale;
		initialRange = light.range;
		initialIntensity = light.intensity;
		initialStartWidth = GetComponent<TrailRenderer>().startWidth;
		gameController = GameObject.Find("Game").GetComponent<Game>();
	}
	
	// Update is called once per frame
	void Update () {

		//mouse
		mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		if (Input.GetMouseButtonDown(0) && Input.touchCount <= 0 && Vector2.Distance((Vector2)mousePos, (Vector2)transform.position) < renderer.bounds.size.x / 2f) {
			react ();
			hit ();
			gameController.hitDetected = true;
			
		}
		
		//touch
		int i = 0;
		while (i < Input.touchCount) {
			mousePos = Camera.main.ScreenToWorldPoint (Input.GetTouch(i).position);
			if (Input.GetTouch (i).phase == TouchPhase.Began && Vector2.Distance((Vector2)mousePos, (Vector2)transform.position) < renderer.bounds.size.x / 2f) {
				react ();
				hit ();
				gameController.hitDetected = true;
			}
			i++;
		}
		if (gameController.performMiss) { // Check if the game controller detected a miss, and if so perform my miss function
			miss ();
		}
		//death
		lifeLeft -= Time.deltaTime;
		if (lifeLeft <= 0) {
			Destroy(this.gameObject);
		}
	}
	
	void FixedUpdate () {
		if (rigidbody2D.velocity.magnitude < 30f) {
			rigidbody2D.drag = 20f;
		}
		else {
			rigidbody2D.drag = 3f;
		}
	}

	void react () {
		float newSpeed = 200f;
		float newAngle = Random.Range(0f,Mathf.PI * 2);
		rigidbody2D.velocity = (new Vector2(newSpeed * Mathf.Cos(newAngle), newSpeed * Mathf.Sin(newAngle)));
		float explosionSpeed = 50f;
		particleSystem.Emit(transform.position, (new Vector3(explosionSpeed * Mathf.Cos(Random.Range(0f,Mathf.PI * 2)), explosionSpeed * Mathf.Sin(Random.Range(0f,Mathf.PI * 2)), 0f)), 1f, 1f, new Color32(255,255,255,255));
		if (GetComponent<Stretch>().myScale > minScale) {
			GetComponent<Stretch>().myScale /= 2f;
			light.range /= 2f;
			//light.intensity /= 2f;
			GetComponent<TrailRenderer>().startWidth /= 2;
		}
		else {
			GetComponent<Stretch>().myScale = initialScale;
			light.range = initialRange;
			light.intensity = initialIntensity;
			GetComponent<TrailRenderer>().startWidth = initialStartWidth;
			
			GameObject newBall = (GameObject)Instantiate(Resources.Load("Prefabs/Ball"), transform.position, Quaternion.identity);
			newSpeed = 200f;
			newAngle = Random.Range(0f,Mathf.PI * 2);
			rigidbody2D.velocity = (new Vector2(newSpeed * Mathf.Cos(newAngle), newSpeed * Mathf.Sin(newAngle)));
			newBall.GetComponent<Rigidbody2D>().velocity = (new Vector2(newSpeed * Mathf.Cos(newAngle), newSpeed * Mathf.Sin(newAngle)));
		}
	}
	
	void hit() {	// This function is called by every object that is hit when a single or multiple hits are detected
		gameController.life += 0.2f;
		lifeLeft = 3f;
	}
	
	void miss() {	// Thie function is called by every object that has this script when the player misses all the balls
	}
}
