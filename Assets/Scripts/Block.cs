using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {
	private static ILogger logger = Debug.logger;

	// Use this for initialization
	void Start () {

	}


	void OnCollisionEnter2D(Collision2D other) {
		logger.Log ("Collision");
	}

	// Update is called once per frame
	void Update () {

	}
}
