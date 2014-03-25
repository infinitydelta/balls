using UnityEngine;
using System.Collections;

public class HueShift : MonoBehaviour {

	float myHueCounter = 0;
	float myHueShiftSpeed = 0.006f;
	float baseHaloWhiteness = 0f;
	float baseParticleWhiteness = 0.6f;
	float particleSystemOnSpeed = 4f;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (rigidbody2D.velocity.magnitude > particleSystemOnSpeed) {
			particleSystem.Play();
		}
		else {
			particleSystem.Stop();
		}
		baseParticleWhiteness = 0.01f * rigidbody2D.velocity.magnitude;
		light.color = new Color (baseHaloWhiteness + (Mathf.Sin (myHueCounter) + 1f) / 2f, baseHaloWhiteness + (Mathf.Sin ((2f/3f) * Mathf.PI + myHueCounter) + 1f) / 2f, baseHaloWhiteness + (Mathf.Sin ((4f/3f) * Mathf.PI +myHueCounter) + 1f) / 2f, 1f);
		particleSystem.startColor = new Color (baseParticleWhiteness + (Mathf.Sin (myHueCounter) + 1f) / 2f, baseParticleWhiteness + (Mathf.Sin ((2f/3f) * Mathf.PI + myHueCounter) + 1f) / 2f, baseParticleWhiteness + (Mathf.Sin ((4f/3f) * Mathf.PI +myHueCounter) + 1f) / 2f, 1f);
		myHueCounter += myHueShiftSpeed * rigidbody2D.velocity.magnitude;
	}
}
