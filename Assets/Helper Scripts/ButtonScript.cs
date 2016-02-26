using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour
{
	GameObject Button; 
	GameObject C1,C2,C3,C4,C5,C6,C7,C8,C9;
	RectTransform rt1,rt2,rt3,rt4,rt5,rt6,rt7,rt8,rt9;
	 int counter;
	void Start(){
		Button=GameObject.Find("Shot");
		C1=GameObject.Find("c1");
		C2=GameObject.Find("c2");
		C3=GameObject.Find("c3");
		C4=GameObject.Find("c4");
		C5=GameObject.Find("c5");
		C6=GameObject.Find("c6");
		C7=GameObject.Find("c7");
		C8=GameObject.Find("c8");
		C9=GameObject.Find("c9");
		rt1 = (RectTransform)C1.transform;
		rt2 = (RectTransform)C2.transform;
		rt3 = (RectTransform)C3.transform;
		rt4 = (RectTransform)C4.transform;
		rt5 = (RectTransform)C5.transform;
		rt6 = (RectTransform)C6.transform;
		rt7 = (RectTransform)C7.transform;
		rt8 = (RectTransform)C8.transform;
		rt9 = (RectTransform)C9.transform;
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
				counter++;
				
			}
			else if(counter==3){
				Button.GetComponent<UnityEngine.UI.Image>().color=CameraController.mCamera.GetPixel((int)rt4.anchoredPosition.x,(int)rt4.anchoredPosition.y);
				counter++;
				
			}
			else if(counter==4){
				Button.GetComponent<UnityEngine.UI.Image>().color=CameraController.mCamera.GetPixel((int)rt5.anchoredPosition.x,(int)rt5.anchoredPosition.y);
				counter++;
				
			}
			else if(counter==5){
				Button.GetComponent<UnityEngine.UI.Image>().color=CameraController.mCamera.GetPixel((int)rt6.anchoredPosition.x,(int)rt6.anchoredPosition.y);
				counter++;
				
			}
			else if(counter==6){
				Button.GetComponent<UnityEngine.UI.Image>().color=CameraController.mCamera.GetPixel((int)rt7.anchoredPosition.x,(int)rt7.anchoredPosition.y);
				counter++;
				
			}
			else if(counter==7){
				Button.GetComponent<UnityEngine.UI.Image>().color=CameraController.mCamera.GetPixel((int)rt8.anchoredPosition.x,(int)rt8.anchoredPosition.y);
				counter++;
				
			}
			else if(counter==8){
				Button.GetComponent<UnityEngine.UI.Image>().color=CameraController.mCamera.GetPixel((int)rt9.anchoredPosition.x,(int)rt9.anchoredPosition.y);
				counter=0;
				
			}
			//print(rt.anchoredPosition.x);
			//print(rt.anchoredPosition.y);
		}
	}
}
