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
	Ray ray;
	RaycastHit rayHit;
	Vector2 fp,lp;
	string referenceName;
	int referenceCount;
	int d1,d2,d3,d4,k,i;
	 Vector3 firstPressPos;
	 Vector3 secondPressPos;
	 Vector3 currentSwipe;
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
		 print("rubikSceneHasStarted");
		 i=0;
		 if(RandomGeneration.RandomGeneratedFlag){
			 if(RandomGeneration.RandomGeneratedColors.Count()==48){
				 while(i<48){
					temp=GameObject.Find(Globals.EdgesAndCorners[i]);
					temp.GetComponent<Renderer>().material.color=returnColor(RandomGeneration.RandomGeneratedColors[i]);
					i++;
				 }
			 }
			 else{
				 print("error!");
				 return;
			 }
			 RandomGeneration.RandomGeneratedFlag=false;
		 }
		 blue=GameObject.Find("BLUE");
		 d1=(int)blue.transform.position.z;
		 red=GameObject.Find("RED");
		 d2=(int)red.transform.position.z;
		 orange=GameObject.Find("ORANGE");
		 d3=(int)orange.transform.position.z;
		 white=GameObject.Find("WHITE");
		 d4=(int)white.transform.position.z;
		 yellow=GameObject.Find("YELLOW");
		 green=GameObject.Find("GREEN");
		 
		  Parent=GameObject.Find("Parent");
		  Center=GameObject.Find("CENTER");
		  rubix=GameObject.Find("RubiksCube");
		
     } 
	
	 int findK(string x){
		 if(x=="upper")
			return 0;
		if(x=="middle")
			return 3;
		else 
			return 6;
		 
	 }
	void RotateUpperOrDownFace(int flag,string plane){
		string[] NewString=new string[8];
		string[] whatPlane=new string[8];
		GameObject whatCenter=null;
		if(plane=="upper"){
			whatPlane=UpperFace;
			whatCenter=red;
		}

		else if(plane=="down"){
			whatPlane=DownFace;
			whatCenter=white;
		}
		else return;
		for(int i=0;i<8;i++){
			temp=GameObject.Find(whatPlane[i]);
			temp.transform.SetParent(Parent.transform);
		}
		Parent.transform.RotateAround(whatCenter.transform.position, whatCenter.transform.up,(-1 * flag)* 90f);
		for(int i=0;i<8;i++){
			temp=GameObject.Find(whatPlane[i]);
			temp.transform.SetParent(rubix.transform);
			}
		if(flag==-1){//left swipe
			for(int i=0;i<8;i++)
				NewString[(i+2)%8]=whatPlane[i];
			for(int i=0;i<8;i++)
				whatPlane[i]=NewString[i];
		}
		else if(flag==1){//right swipe
			for(int i=7;i>=2;i--)
				NewString[i-2]=whatPlane[i];
			NewString[6]=whatPlane[0];
			NewString[7]=whatPlane[1];
			
			for(int i=0;i<8;i++)
				whatPlane[i]=NewString[i];
		}
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
	
	void RotateOrangeFace(int flag){
		for(int i=0;i<9;i++){
			temp=GameObject.Find(OrangeFace[i]);
			temp.transform.SetParent(Parent.transform);
		}
		Parent.transform.RotateAround(orange.transform.position, orange.transform.right,flag*90f);
		for(int i=0;i<9;i++){
			temp=GameObject.Find(OrangeFace[i]);
			temp.transform.SetParent(rubix.transform);
		}
		if(flag==1){ //CCW
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
		else if(flag==-1){ //CW
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
	
	
	void RotateBlueFace(int flag){
		for(int i=0;i<9;i++){
			temp=GameObject.Find(BlueFace[i]);
			temp.transform.SetParent(Parent.transform);
		}
		Parent.transform.RotateAround(blue.transform.position, blue.transform.right,flag*90f);
		for(int i=0;i<9;i++){
			temp=GameObject.Find(BlueFace[i]);
			temp.transform.SetParent(rubix.transform);
		}
		
		if(flag==1){ //CW
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
		else if(flag==-1){ //CCW
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
	
	void RotateGreenFace(int flag){
		for(int i=0;i<9;i++){
			temp=GameObject.Find(GreenFace[i]);
			temp.transform.SetParent(Parent.transform);
		}
		Parent.transform.RotateAround(green.transform.position, green.transform.forward,flag*90f);
		for(int i=0;i<9;i++){
			temp=GameObject.Find(GreenFace[i]);
			temp.transform.SetParent(rubix.transform);
		}
		if(flag==1){ // CCW
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
		else if(flag==-1){ //CW
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
	
	void RotateYellowFace(int flag){
		for(int i=0;i<9;i++){
			temp=GameObject.Find(YellowFace[i]);
			temp.transform.SetParent(Parent.transform);
		}
		Parent.transform.RotateAround(yellow.transform.position, yellow.transform.forward,flag*90f);
		for(int i=0;i<9;i++){
			temp=GameObject.Find(YellowFace[i]);
			temp.transform.SetParent(rubix.transform);
		}
		if(flag==-1){
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
		else if(flag==1){
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
	 void FixedUpdate(){ 
	    if (Input.GetMouseButtonDown(0)){
		RotateUpperOrDownFace(-1,"upper");
		RotateUpperOrDownFace(1,"down");
		//RotateOrangeFace(1);
		RotateBlueFace(1);
		RotateYellowFace(1);
		RotateGreenFace(-1);
		RotateGreenFace(1);
		RotateYellowFace(-1);
		RotateBlueFace(-1);
		RotateUpperOrDownFace(-1,"down");
		RotateUpperOrDownFace(1,"upper");
		//RotateBlueFace (1);
		//RotateRedFace (1);
		//RotateWhiteFace(1);
		}
	 }
}