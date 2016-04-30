using UnityEngine;
using System.Collections;

public class CameraResolution : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Camera.main.aspect = 400f / 800f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
