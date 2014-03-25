using UnityEngine;
using System.Collections;

public class Wall_Top : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.localScale = new Vector3 ((Camera.main.orthographicSize * Camera.main.aspect)  / 4f, 1, 1);
		transform.position = new Vector3 (0, Camera.main.orthographicSize, 0);
	}
}
