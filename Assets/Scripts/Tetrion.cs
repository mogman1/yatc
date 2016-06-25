using UnityEngine;
using System.Collections;

public class Tetrion : MonoBehaviour {
	public static float bottom = -4.56f;
	private Object iBlock;
	private GameObject block;
	private I_tetromino script;
	// Use this for initialization
	void Start () {
		iBlock = Resources.Load ("Prefabs/I_tetromino");
		Instantiate (iBlock, new Vector3 (0, 3f, 0), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
