using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {
	float time = 0;
	public float life = 2f;
	public bool hitDetected = false;
	bool checkTouch = false;
	public bool performMiss = false;
	
	int oldTouchCount = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//print (life);
		time += Time.deltaTime;
		life -=  Time.deltaTime;
		
		if (performMiss) {	// If the performMiss variable has been true for the last frame, reset it to false
			performMiss = false;
		}
		
		if (checkTouch) {	// If the checkTouch variable has been true for the last frame, that means that the user tapped the screen in the last frame, so check if a hit has been reported...
			if (hitDetected) {	// If a hit was reported, execute the hit() function
				hit ();
			}
			else {	// Otherwise it must have been a miss...
				miss ();	// So perform the miss() function
				performMiss = true;	// Make it publicly readible (with the performMiss variable) that a miss was detected, to be reset in the next frame (line 23)
			}
			checkTouch = false;	// Checks have been complete, so stop checking
		}
		
		if (Input.GetMouseButtonDown(0) || Input.touchCount > oldTouchCount) {	// If the player taps on the screen...
			hitDetected = false;	// Reset the hitDetected variable so it can be overridden
			checkTouch = true;	// Check to see if there actually was a hit in the next frame (line 27)
		}
		oldTouchCount = Input.touchCount;
	}
	
	public void hit () {	// This function is called only once when single or multiple hits are detected
		print("HITler!");
	}
	
	public void miss () {	// This function is called only once when a miss occurs
		print("You are biggest noob ever!");
	}
}
