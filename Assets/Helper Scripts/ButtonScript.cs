using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour
{
	GameObject Button; 
	GameObject C1;
	void Start(){
		Button=GameObject.Find("Shot");
		C1=GameObject.Find("c1");
	}
	void Update(){
		if (Input.GetMouseButtonUp(0)){
			Button.GetComponent<UnityEngine.UI.Image>().color=CameraController.mCamera.GetPixel(50,50);
			print(C1.transform.position.x);
			print(C1.transform.position.y);
			//print(C1.transform.GetComponent<Renderer>().bounds.center.y);
		}
	}
}
