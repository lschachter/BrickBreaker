using UnityEngine;
using System.Collections;

public class Instantiation : MonoBehaviour {
	public Transform Brick;
	// Use this for initialization

	//this script is a part of the brick prefab
	void Start () {
		int y,x;
		for (y = 0; y < 4; y++) {
			for (x = -6; x < 8; x = x+2) {
				Instantiate (Brick, new Vector3 (x, y, 0), Quaternion.identity);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
