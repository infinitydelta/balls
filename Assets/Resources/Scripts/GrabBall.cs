using UnityEngine;
using System.Collections;

public class GrabBall : MonoBehaviour {
	bool grabbed = false;
	bool shooting = false;
	Vector3 mousePos;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		if (Input.GetMouseButtonDown(0) && Vector2.Distance((Vector2)mousePos, (Vector2)transform.position) < renderer.bounds.size.x / 2f) {
			grabbed = true;
		}
		if (!Input.GetMouseButton(0)) {
			grabbed = false;
		}

		if (Input.GetMouseButtonDown(1) && Vector2.Distance((Vector2)mousePos, (Vector2)transform.position) < renderer.bounds.size.x / 2f) {
			shooting = true;
		}
		if (!Input.GetMouseButton(1) && shooting) {
			rigidbody2D.velocity = 50f * ((Vector2)mousePos - (Vector2)transform.position);
			shooting = false;
		}

		if (shooting) {
			particleSystem.Play();
		}
	}
	void FixedUpdate () {
		mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		if (grabbed) {
			rigidbody2D.velocity = 50f * ((Vector2)mousePos - (Vector2)transform.position);
		}
	}
}
