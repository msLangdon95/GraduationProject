using UnityEngine;
using System.Collections;
using UnityEngine.UI;    
using System;
using System.Linq;  
public class ManualInputSceneScripts : MonoBehaviour {
	GameObject x;
	public void ReClear(){ //clear button
		for(int i=0;i<48;i++){
			x=GameObject.Find(Globals.EdgesAndCorners[i]);
			x.GetComponent<Renderer>().material.color =Color.gray;
		}
		for(int i=0;i<6;i++){
			Globals.ColorsArray[i].ColorCounter=0;
			Globals.ColorsArray[i].GO.GetComponentInChildren<Text>().text="0";
		}
	}
	public void VerifyAndGo(){ // next scene button
		for(int i=0;i<6;i++){
			if(Globals.ColorsArray[i].ColorCounter!= 8){ //not all cubies are fully colored
				print("error");
				return;
			}
		}

		for(int i=0;i<48;i++){
			x=GameObject.Find(Globals.EdgesAndCorners[i]);
			if(x.GetComponentInChildren<TextMesh>().text=="X"){//not all cubies are colored correctly
				print("error");
				return;
			}
		}
		
		//Accepted, store all colors
		for(int i=0;i<48;i++){
			x=GameObject.Find(Globals.EdgesAndCorners[i]);
			Globals.CurrentCubeColors[i]=x.GetComponent<Renderer>().material.color;
		}
		Application.LoadLevel("rubik");
	}
	
}