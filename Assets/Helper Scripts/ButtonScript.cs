using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour
{
	GameObject Button; 
	GameObject C1,C2,C3;
	RectTransform rt1,rt2,rt3;
	 int counter;
	void Start(){
		Button=GameObject.Find("Shot");
		C1=GameObject.Find("c1");
		C2=GameObject.Find("c2");
		C3=GameObject.Find("c3");
		rt1 = (RectTransform)C1.transform;
		rt2 = (RectTransform)C2.transform;
		rt3 = (RectTransform)C3.transform;
		counter=0;
	}
	void Update(){
		if (Input.GetMouseButtonUp(0)){
			if(counter==0){
				Button.GetComponent<UnityEngine.UI.Image>().color=CameraController.mCamera.GetPixel((int)rt1.anchoredPosition.x,(int)rt1.anchoredPosition.y);
				counter++;
			}
			else if(counter==1){
				Button.GetComponent<UnityEngine.UI.Image>().color=CameraController.mCamera.GetPixel((int)rt2.anchoredPosition.x,(int)rt2.anchoredPosition.y);
				counter++;
			}
			else if(counter==2){
				Button.GetComponent<UnityEngine.UI.Image>().color=CameraController.mCamera.GetPixel((int)rt3.anchoredPosition.x,(int)rt3.anchoredPosition.y);
				counter=0;
				
			}
			//print(rt.anchoredPosition.x);
			//print(rt.anchoredPosition.y);
		}
	}
}
