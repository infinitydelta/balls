using UnityEngine;
using System.Collections;

public class Stretch : MonoBehaviour {

	float stretchScale = 0.01f;
	public float myScale = 1f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.localScale = myScale * Vector3.one + stretchScale * Vector3.forward * rigidbody2D.velocity.magnitude;
		transform.LookAt (transform.position + new Vector3(rigidbody2D.velocity.x, rigidbody2D.velocity.y, 0).normalized);

	}
}
