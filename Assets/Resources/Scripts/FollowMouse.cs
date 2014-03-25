using UnityEngine;
using System.Collections;

public class FollowMouse : MonoBehaviour {
	float easingAmount = 100f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		rigidbody2D.AddForce (easingAmount * new Vector2((mousePos.x - transform.position.x), (mousePos.y - transform.position.y)));
	}
}
