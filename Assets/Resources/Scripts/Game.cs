using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {
	float time = 0;
	float life = 1000;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		print (life);
		time += Time.deltaTime;
		life -= 10 * Time.deltaTime;
	}
}
