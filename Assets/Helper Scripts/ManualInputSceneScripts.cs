using UnityEngine;
using System.Collections;
using UnityEngine.UI;    
using System;
using System.Linq;  
using System.IO;
using System.Text;

public class ManualInputSceneScripts : MonoBehaviour {
	GameObject x;	
	public void ReClear(){ //clear button
		for(int i=0;i<48;i++){
			x=GameObject.Find(Globals.EdgesAndCorners[i]);
			x.GetComponent<Renderer>().material.color =Color.gray;
		}
		for(int i=0;i<6;i++){
			RayCaster.ColorsArray[i].ColorCounter=0;
			RayCaster.ColorsArray[i].ColorFlag=true;
			RayCaster.ColorsArray[i].GO.GetComponentInChildren<Text>().text="0";
		}
	}
	public void VerifyAndGo(){ // next scene button
		for(int i=0;i<6;i++){
			if(RayCaster.ColorsArray[i].ColorCounter!= 8){ //not all cubies are fully colored
				Globals.VerifyPanel.SetActive(true);
				return;
			}
		}
		//Accepted, store all colors
		for(int i=0;i<48;i++){
			x=GameObject.Find(Globals.EdgesAndCorners[i]);
			Globals.CurrentCubeColors[i]=x.GetComponent<Renderer>().material.color;
		}
		Globals.ManualInputFlag=true;
		Globals.RandomGeneratedFlag=false;
		Globals.LoadFlag=false;
		Application.LoadLevel("rubik");
	}

	public void Close(GameObject P){
		P.SetActive(false);
	}
	
	public void DontShowThisMessageAgain(GameObject P){
		Globals.dontShowAgain=true;
		P.SetActive(false);
	}
	public void onMouseDown(){
		VerifyAndGo ();
	}
}