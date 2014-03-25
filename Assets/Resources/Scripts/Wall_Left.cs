using UnityEngine;
using System.Collections;

public class Wall_Left : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.localScale = new Vector3 (1, (Camera.main.orthographicSize / 4f), 1);
		transform.position = new Vector3 (-Camera.main.orthographicSize * Camera.main.aspect, 0, 0);
	}
}
