using UnityEngine;
using System.Collections;

public class color : MonoBehaviour {
	public GameObject txt;
	public GameObject g;
	// Use this for initialization
	void Start () {
		txt =GameObject.Find("txt1");
		g=GameObject.Find ("White3");
	}
	
	// Update is called once per frame
	void Update () {
		txt.transform.position = g.transform.position;
	}
}
