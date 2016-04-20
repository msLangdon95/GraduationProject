using UnityEngine;
using System.Collections;
using UnityEngine.UI;    
using System;
using System.Linq;  
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;
public class RubikScene : MonoBehaviour {
	GameObject w,lastClicked,Parent,temp,Center,rubix,blue,white,orange,red,yellow,green,steps;
	bool GreenFaceFlagcw,GreenFaceFlagccw,BlueFaceFlagcw,BlueFaceFlagccw,OrangeFaceFlagcw,OrangeFaceFlagccw,UpFaceFlagcw,
	UpFaceFlagccw,DownFaceFlagcw,DownFaceFlagccw,YellowFaceFlagcw,YellowFaceFlagccw;
	Ray ray;
	RaycastHit rayHit;
	 Vector2 firstPressPos;
	 Vector2 secondPressPos;
	 Vector2 currentSwipe;
	 int k,i,d1,d2,d3,d4,NoOfSteps=0;
	 string[]rightFace;
	 string[]leftFace;
	 float totalRotation = 0;
	 public static string[]UpperFace={"Corner7","Edge7","Corner3","Edge2","Corner1","Edge5","Corner6","Edge11"};
	 public static string[]DownFace={"Corner8","Edge8","Corner4","Edge3","Corner2","Edge6","Corner5","Edge10"};
	 public static string[]GreenFace={"Corner7","Edge7","Corner3","Edge12","GREEN", "Edge4","Corner8","Edge8","Corner4"};
	 public static string[]BlueFace={"Corner6","Edge11","Corner7","Edge9","BLUE","Edge12","Corner5","Edge10","Corner8"};
	 public static string[]OrangeFace={"Corner3","Edge2","Corner1","Edge4","ORANGE","Edge1","Corner4","Edge3","Corner2"};
	 public static string[]YellowFace={"Corner1","Edge5","Corner6","Edge1","YELLOW","Edge9","Corner2","Edge6","Corner5"};
	 Color returnColor(string s){
		 if(s=="RED")
			 return Color.red;
		 if(s=="GREEN")
			 return Color.green;
		 if(s=="WHITE")
			 return Color.white;
		 if(s=="BLUE")
			 return Color.blue;
		 if(s=="YELLOW")
			 return Color.yellow;
		 else
			 return Globals.Orange;
	 }
	 void Start (){
		 steps=GameObject.Find("steps");
		 GreenFaceFlagcw=GreenFaceFlagccw=BlueFaceFlagcw=BlueFaceFlagccw=OrangeFaceFlagcw=OrangeFaceFlagccw=UpFaceFlagcw=
		 UpFaceFlagccw=DownFaceFlagcw=DownFaceFlagccw=YellowFaceFlagcw=YellowFaceFlagccw=false;
		 i=0;
		 if(Globals.RandomGeneratedFlag){
			 if(RandomGeneration.RandomGeneratedColors.Count()==48){
				 for(i=0;i<48;i++){
					temp=GameObject.Find(Globals.EdgesAndCorners[i]);
					temp.GetComponent<Renderer>().material.color=returnColor(RandomGeneration.RandomGeneratedColors[i]);
				 }
			 }
			 else{
				 print("error!");
				 return;
			 }
			 Globals.RandomGeneratedFlag=false;
		 }
		 else if(Globals.ManualInputFlag){
			 for(i=0;i<48;i++){
				temp=GameObject.Find(Globals.EdgesAndCorners[i]);
				temp.GetComponent<Renderer>().material.color=Globals.CurrentCubeColors[i];
			}
			 Globals.ManualInputFlag=false;
		 }
		 else if(Globals.LoadFlag){
			 for ( i=0 ; i<48 ; i++){
				temp=GameObject.Find(Globals.EdgesAndCorners[i]); 
				temp.GetComponent<Renderer>().material.color=returnColor(Loading.m[i]); 	
				}
			 Globals.LoadFlag=false;
		 }
		 
		 blue=GameObject.Find("BLUE");
		 red=GameObject.Find("RED");
		 orange=GameObject.Find("ORANGE");
		 white=GameObject.Find("WHITE");
		 yellow=GameObject.Find("YELLOW");
		 green=GameObject.Find("GREEN");
		 Parent=GameObject.Find("Parent");
		 Center=GameObject.Find("CENTER");
		 rubix=GameObject.Find("RubiksCube");
     }  
	
	int findK(string x){
		 if(x=="upper")
			return 0;
		else if(x=="middle")
			return 3;
		else if(x=="down")
			return 6; 
		else
			return -1;
	 }
	 void PutStuffInParent(string[] face){
		 int until;
		 if(face==UpperFace || face==DownFace)
			 until=8;
		 else
			 until=9;
		 for(int i=0;i<until;i++){
			 temp=GameObject.Find(face[i]);
			 temp.transform.SetParent(Parent.transform);
		 }
	 }
	 void PutStuffInRubix(string[] face){
		 int until;
		 if(face==UpperFace || face==DownFace)
			 until=8;
		 else
			 until=9;
		 for(int i=0;i<until;i++){
			 temp=GameObject.Find(face[i]);
			 temp.transform.SetParent(rubix.transform);
		 }
	 }
	 
	void FixedUpdate(){ 
		if(Input.GetMouseButtonDown(0)){
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(ray, out rayHit)){
				lastClicked = rayHit.collider.gameObject;
				if(lastClicked==null)
					return;
				//print(lastClicked.transform.parent.GetChild(0).name+" "+(int)lastClicked.transform.parent.GetChild(0).position.x+" "+(int)lastClicked.transform.parent.GetChild(0).position.y+" "+(int)lastClicked.transform.parent.GetChild(0).position.z);
				//print(lastClicked.transform.parent.GetChild(1).name+" "+(int)lastClicked.transform.parent.GetChild(1).position.x+" "+(int)lastClicked.transform.parent.GetChild(1).position.y+" "+(int)lastClicked.transform.parent.GetChild(1).position.z);
				//print(lastClicked.transform.parent.GetChild(2).name+" "+(int)lastClicked.transform.parent.GetChild(2).position.x+" "+(int)lastClicked.transform.parent.GetChild(2).position.y+" "+(int)lastClicked.transform.parent.GetChild(2).position.z);
			}
			firstPressPos = new Vector2(Input.mousePosition.x,Input.mousePosition.y);
		}
		if(Input.GetMouseButtonUp(0)){
			secondPressPos = new Vector2(Input.mousePosition.x,Input.mousePosition.y);
			currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
			currentSwipe.Normalize();

        if(currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f){//UP
            print("up swipe");
        }
        if(currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f){//DownSwipe
            print("down swipe");
        }
        if(currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f){ //leftSwipe
        }
        if(currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f){ //rightSwipe
        }
	}
}

void Update(){
	if(UpFaceFlagcw){
		
	 } 
	 if(UpFaceFlagccw){
		
	 }
	 if(DownFaceFlagcw){
		
	 } 
	 if(DownFaceFlagccw){
		
	 }
	 if(BlueFaceFlagcw){
		
	 } 
	 if(BlueFaceFlagccw){
		
	 }
	 if(OrangeFaceFlagcw){
		
	 }
	 if(OrangeFaceFlagccw){
		
	 }	
	 if(GreenFaceFlagcw){
		
	 }
	 if(GreenFaceFlagccw){
		 
	 }
	 if(YellowFaceFlagcw){
		
	 }
	 if(YellowFaceFlagccw){
	 }
	}
}