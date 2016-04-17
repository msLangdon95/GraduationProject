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

	GameObject w,lastClicked,Parent,temp,Center,rubix,blue,white,orange,red,yellow,green;
	bool GreenFaceFlag,BlueFaceFlag,OrangeFaceFlag,UpFaceFlagcw,UpFaceFlagccw,DownFaceFlagcw,DownFaceFlagccw,YellowFaceFlag;
	Ray ray;
	RaycastHit rayHit;
	 Vector2 firstPressPos;
	 Vector2 secondPressPos;
	 Vector2 currentSwipe;
	 int k,i;
	 float totalRotation = 0;
	 string[]UpperFace={"Corner7","Edge7","Corner3","Edge2","Corner1","Edge5","Corner6","Edge11"};
	 string[]DownFace={"Corner8","Edge8","Corner4","Edge3","Corner2","Edge6","Corner5","Edge10"};
	 string[]GreenFace={"Corner7","Edge7","Corner3","Edge12","GREEN", "Edge4","Corner8","Edge8","Corner4"};
	 string[]BlueFace={"Corner6","Edge11","Corner7","Edge9","BLUE","Edge12","Corner5","Edge10","Corner8"};
	 string[]OrangeFace={"Corner3","Edge2","Corner1","Edge4","ORANGE","Edge1","Corner4","Edge3","Corner2"};
	 string[]YellowFace={"Corner1","Edge5","Corner6","Edge1","YELLOW","Edge9","Corner2","Edge6","Corner5"};
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
		 GreenFaceFlag=BlueFaceFlag=OrangeFaceFlag=UpFaceFlagcw=UpFaceFlagccw=DownFaceFlagcw=DownFaceFlagccw=YellowFaceFlag=false;
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
	 void UpdateGreenFaceCCW(){
		 string[]ForCopy=new string[9];
		ForCopy[0]=GreenFace[6];
		ForCopy[1]=GreenFace[3];
		ForCopy[2]=GreenFace[0];
		ForCopy[3]=GreenFace[7];
		ForCopy[4]=GreenFace[4];
		ForCopy[5]=GreenFace[1];
		ForCopy[6]=GreenFace[8];
		ForCopy[7]=GreenFace[5];
		ForCopy[8]=GreenFace[2];
		for(int i=0;i<9;i++)
			GreenFace[i]=ForCopy[i];
	 } 
	 void UpdateGreenFaceCW(){
		 string[]ForCopy=new string[9];
		ForCopy[0]=GreenFace[2];
		ForCopy[1]=GreenFace[5];
		ForCopy[2]=GreenFace[8];
		ForCopy[3]=GreenFace[1];
		ForCopy[4]=GreenFace[4];
		ForCopy[5]=GreenFace[7];
		ForCopy[6]=GreenFace[0];
		ForCopy[7]=GreenFace[3];
		ForCopy[8]=GreenFace[6];
		for(int i=0;i<9;i++)
			GreenFace[i]=ForCopy[i];
	 }
	 void UpdateGreenFace(){
		DownFace[0]=GreenFace[6];
		DownFace[1]=GreenFace[7];
		DownFace[2]=GreenFace[8];
		
		UpperFace[0]=GreenFace[0];
		UpperFace[1]=GreenFace[1];
		UpperFace[2]=GreenFace[2];
		
		BlueFace[2]=GreenFace[0];
		BlueFace[5]=GreenFace[3];
		BlueFace[8]=GreenFace[6];
		
		OrangeFace[0]=GreenFace[2];
		OrangeFace[3]=GreenFace[5];
		OrangeFace[6]=GreenFace[8];
	 } 
	 void UpdateBlueFaceCW(){
		 string[]ForCopy=new string[9];
		 ForCopy[0]=BlueFace[2];
		ForCopy[1]=BlueFace[5];
		ForCopy[2]=BlueFace[8];
		ForCopy[3]=BlueFace[1];
		ForCopy[4]=BlueFace[4];
		ForCopy[5]=BlueFace[7];
		ForCopy[6]=BlueFace[0];
		ForCopy[7]=BlueFace[3];
		ForCopy[8]=BlueFace[6];
		for(int i=0;i<9;i++)
			BlueFace[i]=ForCopy[i];
	 }
	 void UpdateBlueFaceCCW(){
		 string[]ForCopy=new string[9];
		ForCopy[0]=BlueFace[6];
		ForCopy[1]=BlueFace[3];
		ForCopy[2]=BlueFace[0];
		ForCopy[3]=BlueFace[7];
		ForCopy[4]=BlueFace[4];
		ForCopy[5]=BlueFace[1];
		ForCopy[6]=BlueFace[8];
		ForCopy[7]=BlueFace[5];
		ForCopy[8]=BlueFace[2];
		for(int i=0;i<9;i++)
			BlueFace[i]=ForCopy[i];
	 }
	 void UpdateBlueFace(){
		YellowFace[2]=BlueFace[0];
		YellowFace[5]=BlueFace[3];
		YellowFace[8]=BlueFace[6];
		
		GreenFace[0]=BlueFace[2];
		GreenFace[3]=BlueFace[5];
		GreenFace[6]=BlueFace[8];
		
		DownFace[0]=BlueFace[8];
		DownFace[6]=BlueFace[6];
		DownFace[7]=BlueFace[7];
		
		UpperFace[0]=BlueFace[2];
		UpperFace[6]=BlueFace[0];
		UpperFace[7]=BlueFace[1];
	 }
	 void UpdateOrangeFaceCCW(){
		 string[]ForCopy=new string[9];
			ForCopy[0]=OrangeFace[6];
			ForCopy[1]=OrangeFace[3];
			ForCopy[2]=OrangeFace[0];
			ForCopy[3]=OrangeFace[7];
			ForCopy[4]=OrangeFace[4];
			ForCopy[5]=OrangeFace[1];
			ForCopy[6]=OrangeFace[8];
			ForCopy[7]=OrangeFace[5];
			ForCopy[8]=OrangeFace[2];
			for(int i=0;i<9;i++)
				OrangeFace[i]=ForCopy[i];
	 }
	 void UpdateOrangeFaceCW(){
		 string[]ForCopy=new string[9];
			ForCopy[0]=OrangeFace[2];
			ForCopy[1]=OrangeFace[5];
			ForCopy[2]=OrangeFace[8];
			ForCopy[3]=OrangeFace[1];
			ForCopy[4]=OrangeFace[4];
			ForCopy[5]=OrangeFace[7];
			ForCopy[6]=OrangeFace[0];
			ForCopy[7]=OrangeFace[3];
			ForCopy[8]=OrangeFace[6];
			for(int i=0;i<9;i++)
				OrangeFace[i]=ForCopy[i];
	 }
	 void UpdateOrangeFace(){
		 YellowFace[0]=OrangeFace[2];
		YellowFace[3]=OrangeFace[5];
		YellowFace[6]=OrangeFace[8];
		
		GreenFace[2]=OrangeFace[0];
		GreenFace[5]=OrangeFace[3];
		GreenFace[8]=OrangeFace[6];
		
		DownFace[2]=OrangeFace[6];
		DownFace[3]=OrangeFace[7];
		DownFace[4]=OrangeFace[8];
		
		UpperFace[2]=OrangeFace[0];
		UpperFace[3]=OrangeFace[1];
		UpperFace[4]=OrangeFace[2];
	 }
	 void UpdateYellowFaceCCW(){
		 string[]ForCopy=new string[9];
		ForCopy[0]=YellowFace[6];
		ForCopy[1]=YellowFace[3];
		ForCopy[2]=YellowFace[0];
		ForCopy[3]=YellowFace[7];
		ForCopy[4]=YellowFace[4];
		ForCopy[5]=YellowFace[1];
		ForCopy[6]=YellowFace[8];
		ForCopy[7]=YellowFace[5];
		ForCopy[8]=YellowFace[2];
		for(int i=0;i<9;i++)
			YellowFace[i]=ForCopy[i];
	 }
	 void UpdateYellowFaceCW(){
		string[]ForCopy=new string[9];
		ForCopy[0]=YellowFace[2];
		ForCopy[1]=YellowFace[5];
		ForCopy[2]=YellowFace[8];
		ForCopy[3]=YellowFace[1];
		ForCopy[4]=YellowFace[4];
		ForCopy[5]=YellowFace[7];
		ForCopy[6]=YellowFace[0];
		ForCopy[7]=YellowFace[3];
		ForCopy[8]=YellowFace[6];
		for(int i=0;i<9;i++)
			YellowFace[i]=ForCopy[i];
	 }
	 void UpdateYellowFace(){
		 DownFace[4]=YellowFace[6];
		DownFace[5]=YellowFace[7];
		DownFace[6]=YellowFace[8];
		
		UpperFace[4]=YellowFace[0];
		UpperFace[5]=YellowFace[1];
		UpperFace[6]=YellowFace[2];
		
		BlueFace[0]=YellowFace[2];
		BlueFace[3]=YellowFace[5];
		BlueFace[6]=YellowFace[8];
		
		OrangeFace[2]=YellowFace[0];
		OrangeFace[5]=YellowFace[3];
		OrangeFace[8]=YellowFace[6];
	 }
	void UpdateUpOrDownFaceCCW(string plane){
		string[] whatPlane=new string[8];
		string[] NewString=new string[8];
		if(plane=="upper")
			whatPlane=UpperFace;
		else if(plane=="down")
			whatPlane=DownFace;
		else return;
		for(int i=7;i>=2;i--)
			NewString[i-2]=whatPlane[i];
			NewString[6]=whatPlane[0];
			NewString[7]=whatPlane[1];
			for(int i=0;i<8;i++)
				whatPlane[i]=NewString[i];
	}
	void UpdateUpOrDownFaceCW(string plane){
		string[] whatPlane=new string[8];
		string[] NewString=new string[8];
		if(plane=="upper")
			whatPlane=UpperFace;
		else if(plane=="down")
			whatPlane=DownFace;
		else return;
		for(int i=0;i<8;i++)
			NewString[(i+2)%8]=whatPlane[i];
		for(int i=0;i<8;i++)
			whatPlane[i]=NewString[i];
	}
	void UpdateUpOrDownFace(string plane){
		string[] whatPlane=new string[8];
		if(plane=="upper")
			whatPlane=UpperFace;
		else if(plane=="down")
			whatPlane=DownFace;
		else return;
		k=findK(plane);
		for(int i=0;i<3;i++)
			GreenFace[k++]=whatPlane[i];
		k=findK(plane);
		for(int i=2;i<5;i++)
			OrangeFace[k++]=whatPlane[i];
		k=findK(plane);
		for(int i=4;i<7;i++)
			YellowFace[k++]=whatPlane[i];		
		k=findK(plane);
		for(int i=6;i<9;i++)
			BlueFace[k++]=whatPlane[i%8];
	}
	
	
	
	
	
	
	
	
	void FixedUpdate(){ 
		if(Input.GetMouseButtonDown(0)){
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(ray, out rayHit)){
				lastClicked = rayHit.collider.gameObject;
				print((int)lastClicked.transform.parent.position.x+" "+(int)lastClicked.transform.parent.position.y+" ");
			}
			firstPressPos = new Vector2(Input.mousePosition.x,Input.mousePosition.y);
		}
		if(Input.GetMouseButtonUp(0)){
			secondPressPos = new Vector2(Input.mousePosition.x,Input.mousePosition.y);
			currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
			currentSwipe.Normalize();

        if(currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f){
            print("up swipe");
        }
        if(currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f){
            print("down swipe");
        }
        if(currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f){
			if(lastClicked.transform.parent.position.y>=200f && lastClicked.transform.parent.position.y<= 206f){ // up face clock wise
				PutStuffInParent(UpperFace);
				UpFaceFlagcw=true;
				print("left swipe of up face");
			}
			if(lastClicked.transform.parent.position.y>=129f && lastClicked.transform.parent.position.y<= 132f){ // down face clock wise
				PutStuffInParent(DownFace);
				DownFaceFlagcw=true;
				print("left swipe of down face");
			}
			
        }
        if(currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f){
            if(lastClicked.transform.parent.position.y>=200f && lastClicked.transform.parent.position.y<= 206f){ // up face counter clock wise
				PutStuffInParent(UpperFace);
				UpFaceFlagccw=true;
				print("right swipe of up face");
			}
			
			if(lastClicked.transform.parent.position.y>=129f && lastClicked.transform.parent.position.y<= 132f){ // down face counter clock wise
				PutStuffInParent(DownFace);
				DownFaceFlagccw=true;
				print("right swipe of down face");
			}
			
        }
		}
	}

void Update(){
	if(UpFaceFlagcw){
		if(Mathf.Abs(totalRotation) < 90f){
			totalRotation += 100*Time.deltaTime;
			Parent.transform.RotateAround(red.transform.position,red.transform.up,100*Time.deltaTime);
		}
		if(Mathf.Abs(totalRotation)>=90f){
			UpFaceFlagcw=false;
			totalRotation=0;
			PutStuffInRubix(UpperFace);
			UpdateUpOrDownFaceCW("upper");
			UpdateUpOrDownFace("upper");
		}
	 }
	 
	 if(UpFaceFlagccw){
		if(Mathf.Abs(totalRotation) < 90f){
			totalRotation += 100*Time.deltaTime;
			Parent.transform.RotateAround(red.transform.position,-1*red.transform.up,100*Time.deltaTime);
		}
		if(Mathf.Abs(totalRotation)>=90f){
			UpFaceFlagccw=false;
			totalRotation=0;
			PutStuffInRubix(UpperFace);
			UpdateUpOrDownFaceCCW("upper");
			UpdateUpOrDownFace("upper");
		}
	 }
	 if(DownFaceFlagcw){
		if(Mathf.Abs(totalRotation) < 90f){
			totalRotation += 100*Time.deltaTime;
			Parent.transform.RotateAround(white.transform.position,white.transform.up,100*Time.deltaTime);
		}
		if(Mathf.Abs(totalRotation)>=90f){
			DownFaceFlagcw=false;
			totalRotation=0;
			PutStuffInRubix(DownFace);
			UpdateUpOrDownFaceCW("down");
			UpdateUpOrDownFace("down");
		}
	 }
	 
	 if(DownFaceFlagccw){
		if(Mathf.Abs(totalRotation) < 90f){
			totalRotation += 100*Time.deltaTime;
			Parent.transform.RotateAround(white.transform.position,-1*white.transform.up,100*Time.deltaTime);
		}
		if(Mathf.Abs(totalRotation)>=90f){
			DownFaceFlagccw=false;
			totalRotation=0;
			PutStuffInRubix(DownFace);
			UpdateUpOrDownFaceCCW("down");
			UpdateUpOrDownFace("down");
		}
	 }
	 
	 
	}
}


