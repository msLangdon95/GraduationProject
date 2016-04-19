using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;    
using System.Linq;  
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;

public class solution : MonoBehaviour {
	public static List<string> output=new List<string>();
	float totalRotation=0;
	int i=0; 
	string solMsgs;
	GameObject myMSG,EndOfSolution,Parent,temp,blue,white,orange,red,yellow,green;
	bool GreenFaceFlagcw,GreenFaceFlagccw,BlueFaceFlagcw,BlueFaceFlagccw,OrangeFaceFlagcw,OrangeFaceFlagccw,UpFaceFlagcw,
	UpFaceFlagccw,DownFaceFlagcw,DownFaceFlagccw,YellowFaceFlagcw,YellowFaceFlagccw;
	void Start () {
		 blue=GameObject.Find("BLUE");
		 red=GameObject.Find("RED");
		 orange=GameObject.Find("ORANGE");
		 white=GameObject.Find("WHITE");
		 yellow=GameObject.Find("YELLOW");
		 green=GameObject.Find("GREEN");
		GreenFaceFlagcw=GreenFaceFlagccw=BlueFaceFlagcw=BlueFaceFlagccw=OrangeFaceFlagcw=OrangeFaceFlagccw=UpFaceFlagcw=
		 UpFaceFlagccw=DownFaceFlagcw=DownFaceFlagccw=YellowFaceFlagcw=YellowFaceFlagccw=false;
		Parent=GameObject.Find("Parent");
		for(int i=0;i<48;i++){
			GameObject.Find(Globals.EdgesAndCorners[i]).GetComponent<Renderer>().material.color=OptimalSolution.GoToSolve[i];
		}

		EndOfSolution = GameObject.Find ("EndOfSolution");
		EndOfSolution.SetActive (false);
		myMSG = GameObject.Find ("Mymsg");
	}
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	void UpdateUpOrDownFaceCW(string plane){
		string[] whatPlane=new string[8];
		string[] NewString=new string[8];
		if(plane=="upper")
			whatPlane=RubikScene.UpperFace;
		else if(plane=="down")
			whatPlane=RubikScene.DownFace;
		else return;
		for(int i=0;i<8;i++)
			NewString[(i+2)%8]=whatPlane[i];
		for(int i=0;i<8;i++)
			whatPlane[i]=NewString[i];
	}
	 void PutStuffInParent(string[] face){
		 int until;
		 if(face==RubikScene.UpperFace || face==RubikScene.DownFace)
			 until=8;
		 else
			 until=9;
		 for(int i=0;i<until;i++){
			 temp=GameObject.Find(face[i]);
			 temp.transform.SetParent(Parent.transform);
		 }
	 }
	public void nextStep() {
		if(i<output.Count){
		if (output[i]=="UCW"){
				solMsgs="Rotate upper face clock wise";
				UpFaceFlagcw=true;
				PutStuffInParent(RubikScene.UpperFace);
			}
			if (output[i]=="UCCW"){
				solMsgs="Rotate upper face counter clock wise";
				UpFaceFlagccw=true;
			}
			if (output[i]=="U180"){
				solMsgs="Rotate upper face 180 degree";
			}
			if (output[i]=="BCW"){
				solMsgs="Rotate back face clock wise";
			}
			if (output[i]=="BCCW"){
				solMsgs="Rotate back face counter clock wise";
			}
			if (output[i]=="B180"){
				solMsgs="Rotate back face 180 degree";
			}
			if (output[i]=="FCW"){
				solMsgs="Rotate front face clock wise";
			}
			if (output[i]=="FCCW"){
				solMsgs="Rotate front face counter  clock wise";
			}
			if (output[i]=="F180"){
				solMsgs="Rotate front face 180 degree";
			}
			if (output[i]=="RCW"){
				solMsgs="Rotate right face clock wise";
			}
			if (output[i]=="RCCW"){
				solMsgs="Rotate right face counter clock wise";
			}
			if (output[i]=="R180"){
				solMsgs="Rotate right face counter 180 degree";
			}
			if (output[i]=="LCW"){
				solMsgs="Rotate left face clock wise";
			}
			if (output[i]=="LCCW"){
				solMsgs="Rotate left face counter clock wise";
			}
			if (output[i]=="L180"){
				solMsgs="Rotate left face 180 degree";
			}
			if (output[i]=="DCW"){
				solMsgs="Rotate down face clock wise";
			}
			if (output[i]=="DCCW"){
				solMsgs="Rotate down face counter clock wise";
			}
			if (output[i]=="D180"){
				solMsgs="Rotate down face 180 degree";
			}
		
		myMSG.GetComponent<Text> ().text = solMsgs;
		i++;
		}
		if (i == output.Count) {
			EndOfSolution.SetActive (true);
			i=0;
			myMSG.GetComponent<Text> ().text = " ";
		}
	}
	
	public void hideMessage(){
		EndOfSolution.SetActive(false);
		myMSG.GetComponent<Text> ().text = " ";
	}
	
	void Update(){
		if(UpFaceFlagcw){
			print("ho");
		if(Mathf.Abs(totalRotation) < 90f){
			totalRotation += 100*Time.deltaTime;
			Parent.transform.RotateAround(red.transform.position,Vector3.up,100*Time.deltaTime);
		}
		if(Mathf.Abs(totalRotation)>=90f){
			UpFaceFlagcw=false;
			totalRotation=0;
			//PutStuffInRubix(UpperFace);
			UpdateUpOrDownFaceCW("upper");
			//UpdateUpOrDownFace("upper");
		}
	 }
	}
}
