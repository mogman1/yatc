using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class I_tetromino : MonoBehaviour {
	private Vector2 spawnPoint = new Vector2 (1.26f, 3.86f);
	private float speed = -2f;
	private float shift = .6f;
	private Object prefab;
	private List<Object> blocks = new List<Object>();
	private Vector3[] offsets = new Vector3[4];
	private bool hitSomething = false;
	private static ILogger logger = Debug.logger;

	// Use this for initialization
	void Start () {
		transform.position = spawnPoint;
		offsets [0] = this.transform.position + new Vector3 (0.9f, 0, 0);
		offsets [1] = this.transform.position + new Vector3 (0.3f, 0, 0);
		offsets [2] = this.transform.position + new Vector3 (-0.3f, 0, 0);
		offsets [3] = this.transform.position + new Vector3 (-0.9f, 0, 0);

		prefab = Resources.Load ("Prefabs/Block");

		for (int i = 0; i < offsets.Length; i++) {
			blocks.Add (Instantiate (prefab, offsets[i], Quaternion.identity));
		}

		// Set parent to allow group transform
		foreach (Object block in blocks) {
			GameObject blockObject = block as GameObject;
			blockObject.transform.parent = this.transform;
		}
	}
		
	void OnTriggerEnter2D(Collider2D other) {
		logger.Log ("Hit something.");
	}

	void OnTriggerStay2D(Collider2D other) {
		logger.Log ("Trigger Stay");
	}

	void OnTriggerExit2D(Collider2D other) {
		logger.Log ("Trigger Exit");
	}

	void OnCollisionEnter2D(Collision2D other) {
		logger.Log ("Collision Enter");
	}

	void OnCollisionStay2D(Collision2D other) {
		logger.Log ("Collision Stay");
	}

	void OnCollisionExit2D(Collision2D other) {
		logger.Log ("Collision Exit");
	}

	// Update is called once per frame
	void Update () {
		if (!hitSomething) {
			//transform.Translate (Vector3.down * speed * Time.deltaTime);
			transform.position += new Vector3 (0, speed * Time.deltaTime, 0);
		}
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			transform.Rotate (0, 0, 90);
		}
		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			transform.Rotate (0, 0, -90);
		}
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			transform.position += new Vector3 (shift * -1, 0, 0);
		}
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			transform.position += new Vector3 (shift, 0, 0);
		}
	}
}
