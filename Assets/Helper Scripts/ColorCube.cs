using UnityEngine;
using System.Collections;
using UnityEngine.UI;    
public class ColorCube : MonoBehaviour {
	GameObject x;
	void Start(){
		for(int i=0;i<48;i++){
			x=GameObject.Find(Globals.EdgesAndCorners[i]);
			x.GetComponent<Renderer>().material.color=Globals.CurrentCubeColors[i];
		}
	}
}