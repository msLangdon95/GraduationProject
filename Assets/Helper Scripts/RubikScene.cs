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
	bool GreenFaceFlagcw,GreenFaceFlagccw,BlueFaceFlagcw,BlueFaceFlagccw,OrangeFaceFlagcw,OrangeFaceFlagccw,UpFaceFlagcw,UpFaceFlagccw,DownFaceFlagcw,DownFaceFlagccw,YellowFaceFlagcw,YellowFaceFlagccw;
	Ray ray;
	RaycastHit rayHit;
	 Vector2 firstPressPos;
	 Vector2 secondPressPos;
	 Vector2 currentSwipe;
	 int k,i,d1,d2,d3,d4;
	 string[]rightFace;
	 string[]leftFace;
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
		 GreenFaceFlagcw=GreenFaceFlagccw=BlueFaceFlagcw=BlueFaceFlagccw=OrangeFaceFlagcw=OrangeFaceFlagccw=UpFaceFlagcw=UpFaceFlagccw=DownFaceFlagcw=DownFaceFlagccw=YellowFaceFlagcw=YellowFaceFlagccw=false;
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
	 string[] findFrontCenter(){
		 d1=(int)blue.transform.position.z;
		 d2=(int)green.transform.position.z;
		 d3=(int)orange.transform.position.z;
		 d4=(int)yellow.transform.position.z;
		 int result=Mathf.Min(d1,d2,d3,d4);
		 if(result==d1) return BlueFace;
		 if(result==d2) return GreenFace;
		 if(result==d3) return OrangeFace;
		 if(result==d4) return YellowFace;
		 else return null;
	 }
	 string[] findRightFace(){
		 string[] whatsoever=findFrontCenter();
		 if(whatsoever==OrangeFace) return GreenFace;
		 if(whatsoever==GreenFace) return BlueFace;
		 if(whatsoever==BlueFace) return YellowFace;
		 if(whatsoever==YellowFace) return OrangeFace;
		 else return null;
	 }
	 string[]findLeftFace(){
		  string[] whatsoever=findFrontCenter();
		 if(whatsoever==OrangeFace) return YellowFace;
		 if(whatsoever==GreenFace) return OrangeFace;
		 if(whatsoever==BlueFace) return GreenFace;
		 if(whatsoever==YellowFace) return BlueFace;
		 else return null;
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
	void AllInOneUpdateCW(string []x){
		if(x==GreenFace){
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
		else if(x==BlueFace){
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
		else if(x==YellowFace){
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
		else if(x==OrangeFace){
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
	}
	void AllInOneUpdateCCW(string []x){
		if(x==GreenFace){
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
		else if(x==BlueFace){
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
		else if(x==YellowFace){
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
		else if(x==OrangeFace){
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
	}
	void AllInOneUpdateFace(string []x){
		if(x==GreenFace){
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
		else if(x==BlueFace){
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
		else if(x==YellowFace){
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
		else if(x==OrangeFace){
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
	}	
	void SetFlagcw(string []x,bool b){
		if(x==GreenFace){
			GreenFaceFlagcw=b;
		}
		else if(x==BlueFace){
			BlueFaceFlagcw=b;
		}
		else if(x==YellowFace){
			YellowFaceFlagcw=b;
		}
		else if(x==OrangeFace){
			OrangeFaceFlagcw=b;
		}
	}
	void SetFlagccw(string []x,bool b){
		if(x==GreenFace){
			GreenFaceFlagccw=b;
		}
		else if(x==BlueFace){
			BlueFaceFlagccw=b;
		}
		else if(x==YellowFace){
			YellowFaceFlagccw=b;
		}
		else if(x==OrangeFace){
			OrangeFaceFlagccw=b;
		}
	}
	
	void PrintGreen(){
		print(GreenFace[0]+" "+GreenFace[1]+" "+GreenFace[2]+" "+GreenFace[3]+" "+GreenFace[4]+" "+GreenFace[5]+" "+GreenFace[6]+" "+GreenFace[7]+" "+GreenFace[8]);
	}
	void FixedUpdate(){ 
		if(Input.GetMouseButtonDown(0)){
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(ray, out rayHit)){
				lastClicked = rayHit.collider.gameObject;
			}
			firstPressPos = new Vector2(Input.mousePosition.x,Input.mousePosition.y);
		}
		if(Input.GetMouseButtonUp(0)){
			secondPressPos = new Vector2(Input.mousePosition.x,Input.mousePosition.y);
			currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
			currentSwipe.Normalize();

        if(currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f){//UP
			string[]whatFace=findFrontCenter();
			rightFace=findRightFace();
			if(lastClicked.transform.parent.name==whatFace[6]){ //rotate right face cw  OR FRONT small x rotate right big x rotate front
				if(
				((lastClicked.transform.parent.GetChild(0)==lastClicked.transform) && 
				((int)lastClicked.transform.position.x < (int)lastClicked.transform.parent.GetChild(1).position.x) 
				&&((int)lastClicked.transform.position.x < (int)lastClicked.transform.parent.GetChild(2).position.x) )
				||
				((lastClicked.transform.parent.GetChild(1)==lastClicked.transform) && 
				((int)lastClicked.transform.position.x < (int)lastClicked.transform.parent.GetChild(0).position.x)&& 
				((int)lastClicked.transform.position.x < (int)lastClicked.transform.parent.GetChild(2).position.x))
				||
				((lastClicked.transform.parent.GetChild(2)==lastClicked.transform) && 
				((int)lastClicked.transform.position.x < (int)lastClicked.transform.parent.GetChild(0).position.x)&& 
				((int)lastClicked.transform.position.x < (int)lastClicked.transform.parent.GetChild(1).position.x))
				)	
				{
						rightFace=findRightFace();
						PutStuffInParent(rightFace);
						SetFlagcw(rightFace,true);
						print("rotate right face cw");
						return;
				}
				else{
					PutStuffInParent(whatFace);
					SetFlagccw(whatFace,true);
					return;
				}
			
			}
			else if(lastClicked.transform.parent.name==whatFace[8]){ //rotate left face ccw
				leftFace=findLeftFace();
				PutStuffInParent(leftFace);
				SetFlagccw(leftFace,true);
				print("rotate left face ccw");	
				return;
			}
            print("up swipe");
        }
        if(currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f){//DownSwipe
			string[]whatFace=findFrontCenter();
			if(lastClicked.transform.parent.name==whatFace[0]){ //rotate right face ccw OR FRONT
				if(
				((lastClicked.transform.parent.GetChild(0)==lastClicked.transform) && 
				((int)lastClicked.transform.position.x < (int)lastClicked.transform.parent.GetChild(1).position.x) 
				&&((int)lastClicked.transform.position.x < (int)lastClicked.transform.parent.GetChild(2).position.x) )
				||
				((lastClicked.transform.parent.GetChild(1)==lastClicked.transform) && 
				((int)lastClicked.transform.position.x < (int)lastClicked.transform.parent.GetChild(0).position.x)&& 
				((int)lastClicked.transform.position.x < (int)lastClicked.transform.parent.GetChild(2).position.x))
				||
				((lastClicked.transform.parent.GetChild(2)==lastClicked.transform) && 
				((int)lastClicked.transform.position.x < (int)lastClicked.transform.parent.GetChild(0).position.x)&& 
				((int)lastClicked.transform.position.x < (int)lastClicked.transform.parent.GetChild(1).position.x))
				)	
				{
					rightFace=findRightFace();
					PutStuffInParent(rightFace);
					SetFlagccw(rightFace,true);
					print("rotate right face ccw");
					return;
					}
					else{
						PutStuffInParent(whatFace);
						SetFlagcw(whatFace,true);
						return;
					}
			}
			else if(lastClicked.transform.parent.name==whatFace[2]){ //rotate left face cw
				leftFace=findLeftFace();
				PutStuffInParent(leftFace);
				SetFlagcw(leftFace,true);
				print("rotate left face cw");	
				return;
			}
            print("down swipe");
        }
        if(currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f){ //leftSwipe
			if(Mathf.Abs(((int)Center.transform.position.y+(int)lastClicked.GetComponent<Collider>().bounds.size.y)-((int)lastClicked.transform.parent.position.y)) >=0
			&& Mathf.Abs(((int)Center.transform.position.y+(int)lastClicked.GetComponent<Collider>().bounds.size.y)-((int)lastClicked.transform.parent.position.y)) <=15){ // up face clock wise
				PutStuffInParent(UpperFace);
				UpFaceFlagcw=true;
				print("left swipe of up face");
			}
			if(Mathf.Abs(((int)Center.transform.position.y-(int)lastClicked.GetComponent<Collider>().bounds.size.y)-((int)lastClicked.transform.parent.position.y)) >=0
			&& Mathf.Abs(((int)Center.transform.position.y-(int)lastClicked.GetComponent<Collider>().bounds.size.y)-((int)lastClicked.transform.parent.position.y)) <=15){ // down face clock wise
				PutStuffInParent(DownFace);
				DownFaceFlagcw=true;
				print("left swipe of down face");
				return;
			}
			
        }
        if(currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f){ //rightSwipe
            if(Mathf.Abs(((int)Center.transform.position.y+(int)lastClicked.GetComponent<Collider>().bounds.size.y)-((int)lastClicked.transform.parent.position.y)) >=0
			&& Mathf.Abs(((int)Center.transform.position.y+(int)lastClicked.GetComponent<Collider>().bounds.size.y)-((int)lastClicked.transform.parent.position.y)) <=15){ // up face counter clock wise
				PutStuffInParent(UpperFace);
				UpFaceFlagccw=true;
				print("right swipe of up face");
				return;
			}
			
			if(Mathf.Abs(((int)Center.transform.position.y-(int)lastClicked.GetComponent<Collider>().bounds.size.y)-((int)lastClicked.transform.parent.position.y)) >=0
			&& Mathf.Abs(((int)Center.transform.position.y-(int)lastClicked.GetComponent<Collider>().bounds.size.y)-((int)lastClicked.transform.parent.position.y)) <=15){ // down face counter clock wise
				PutStuffInParent(DownFace);
				DownFaceFlagccw=true;
				print("right swipe of down face");
				return;
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
			//PrintGreen();
		}
	 }
	 if(BlueFaceFlagcw){
		if(Mathf.Abs(totalRotation) < 90f){
			totalRotation += 100*Time.deltaTime;
			Parent.transform.RotateAround(blue.transform.position,blue.transform.right,100*Time.deltaTime);
		}
		if(Mathf.Abs(totalRotation)>=90f){
			BlueFaceFlagcw=false;
			totalRotation=0;
			PutStuffInRubix(BlueFace);
			UpdateBlueFaceCW();
			UpdateBlueFace();
			//PrintGreen();
		}
	 } 
	 if(BlueFaceFlagccw){
		if(Mathf.Abs(totalRotation) < 90f){
			totalRotation += 100*Time.deltaTime;
			Parent.transform.RotateAround(blue.transform.position,-1*blue.transform.right,100*Time.deltaTime);
		}
		if(Mathf.Abs(totalRotation)>=90f){
			BlueFaceFlagccw=false;
			totalRotation=0;
			PutStuffInRubix(BlueFace);
			UpdateBlueFaceCCW();
			UpdateBlueFace();
			//PrintGreen();
		}
	 }
	 if(OrangeFaceFlagcw){
		if(Mathf.Abs(totalRotation) < 90f){
			totalRotation += 100*Time.deltaTime;
			Parent.transform.RotateAround(orange.transform.position,-1*orange.transform.right,100*Time.deltaTime);
		}
		if(Mathf.Abs(totalRotation)>=90f){
			OrangeFaceFlagcw=false;
			totalRotation=0;
			PutStuffInRubix(OrangeFace);
			UpdateOrangeFaceCW();
			UpdateOrangeFace();
			//PrintGreen();
		}
	 }
	 if(OrangeFaceFlagccw){
		if(Mathf.Abs(totalRotation) < 90f){
			totalRotation += 100*Time.deltaTime;
			Parent.transform.RotateAround(orange.transform.position,orange.transform.right,100*Time.deltaTime);
		}
		if(Mathf.Abs(totalRotation)>=90f){
			OrangeFaceFlagccw=false;
			totalRotation=0;
			PutStuffInRubix(OrangeFace);
			UpdateOrangeFaceCCW();
			UpdateOrangeFace();
			//PrintGreen();
		}
	 }	
	 if(GreenFaceFlagcw){
		 if(Mathf.Abs(totalRotation) < 90f){
			totalRotation += 100*Time.deltaTime;
			Parent.transform.RotateAround(green.transform.position,-1*green.transform.forward,100*Time.deltaTime);
		}
		if(Mathf.Abs(totalRotation)>=90f){
			GreenFaceFlagcw=false;
			totalRotation=0;
			PutStuffInRubix(GreenFace);
			UpdateGreenFaceCW();
			UpdateGreenFace();
			//PrintGreen();
		}
	 }
	 if(GreenFaceFlagccw){
		 if(Mathf.Abs(totalRotation) < 90f){
			totalRotation += 100*Time.deltaTime;
			Parent.transform.RotateAround(green.transform.position,green.transform.forward,100*Time.deltaTime);
		}
		if(Mathf.Abs(totalRotation)>=90f){
			GreenFaceFlagccw=false;
			totalRotation=0;
			PutStuffInRubix(GreenFace);
			UpdateGreenFaceCCW();
			UpdateGreenFace();
			//PrintGreen();
		}
	 }
	 if(YellowFaceFlagcw){
		 if(Mathf.Abs(totalRotation) < 90f){
			totalRotation += 100*Time.deltaTime;
			Parent.transform.RotateAround(yellow.transform.position,yellow.transform.forward,100*Time.deltaTime);
		}
		if(Mathf.Abs(totalRotation)>=90f){
			YellowFaceFlagcw=false;
			totalRotation=0;
			PutStuffInRubix(YellowFace);
			UpdateYellowFaceCW();
			UpdateYellowFace();
			//PrintGreen();
		}
	 }
	 if(YellowFaceFlagccw){
		 if(Mathf.Abs(totalRotation) < 90f){
			totalRotation += 100*Time.deltaTime;
			Parent.transform.RotateAround(yellow.transform.position,-1*yellow.transform.forward,100*Time.deltaTime);
		}
		if(Mathf.Abs(totalRotation)>=90f){
			YellowFaceFlagccw=false;
			totalRotation=0;
			PutStuffInRubix(YellowFace);
			UpdateYellowFaceCCW();
			UpdateYellowFace();
			//PrintGreen();
		}
	 }
	
	
	}
}


