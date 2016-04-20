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
	int i=0,k; 
	string solMsgs;
	GameObject myMSG,EndOfSolution,Parent,temp,blue,white,orange,red,yellow,green,rubix;
	bool GreenFaceFlagcw,GreenFaceFlagccw,BlueFaceFlagcw,BlueFaceFlagccw,OrangeFaceFlagcw,OrangeFaceFlagccw,UpFaceFlagcw,
	UpFaceFlagccw,DownFaceFlagcw,DownFaceFlagccw,YellowFaceFlagcw,YellowFaceFlagccw,L180,R180,U180,D180,F180,B180,Uagain,Dagain,Lagain,Ragain,Fagain,Bagain;
	string[]UpperFaceSol={"Corner7","Edge7","Corner3","Edge2","Corner1","Edge5","Corner6","Edge11"};
	string[]DownFaceSol={"Corner8","Edge8","Corner4","Edge3","Corner2","Edge6","Corner5","Edge10"};
	string[]GreenFaceSol={"Corner7","Edge7","Corner3","Edge12","GREEN", "Edge4","Corner8","Edge8","Corner4"};
	string[]BlueFaceSol={"Corner6","Edge11","Corner7","Edge9","BLUE","Edge12","Corner5","Edge10","Corner8"};
	string[]OrangeFaceSol={"Corner3","Edge2","Corner1","Edge4","ORANGE","Edge1","Corner4","Edge3","Corner2"};
	string[]YellowFaceSol={"Corner1","Edge5","Corner6","Edge1","YELLOW","Edge9","Corner2","Edge6","Corner5"};
	void Start () {
		rubix=GameObject.Find("RubiksCube");
		 blue=GameObject.Find("BLUE");
		 red=GameObject.Find("RED");
		 orange=GameObject.Find("ORANGE");
		 white=GameObject.Find("WHITE");
		 yellow=GameObject.Find("YELLOW");
		 green=GameObject.Find("GREEN");
		GreenFaceFlagcw=GreenFaceFlagccw=BlueFaceFlagcw=BlueFaceFlagccw=OrangeFaceFlagcw=OrangeFaceFlagccw=UpFaceFlagcw=
		 UpFaceFlagccw=DownFaceFlagcw=DownFaceFlagccw=YellowFaceFlagcw=YellowFaceFlagccw=L180=R180=F180=B180=U180=D180=Uagain=Dagain=Lagain=Ragain=Fagain=Bagain=false;
		Parent=GameObject.Find("Parent");
		for(int i=0;i<8;i++){
			UpperFaceSol[i]=RubikScene.UpperFace[i];
			DownFaceSol[i]=RubikScene.DownFace[i];
			//print(UpperFaceSol[0]+" "+UpperFaceSol[1]+" "+UpperFaceSol[2]+" "+UpperFaceSol[3]+" "+UpperFaceSol[4]+" "+UpperFaceSol[5]+" "+UpperFaceSol[6]+" "+UpperFaceSol[7]);
		}
		for(int i=0;i<9;i++){
			GreenFaceSol[i]=RubikScene.GreenFace[i];
			BlueFaceSol[i]=RubikScene.BlueFace[i];
			OrangeFaceSol[i]=RubikScene.OrangeFace[i];
			YellowFaceSol[i]=RubikScene.YellowFace[i];
		}
		
		//Color it
		for(int i=0;i<48;i++){
			GameObject.Find(Globals.EdgesAndCorners[i]).GetComponent<Renderer>().material.color=OptimalSolution.GoToSolve[i];
		}

		EndOfSolution = GameObject.Find ("EndOfSolution");
		EndOfSolution.SetActive (false);
		myMSG = GameObject.Find ("Mymsg");
	}
	 void PutStuffInParent(string[] face){
		 int until;
		 if(face==UpperFaceSol || face==DownFaceSol)
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
		 if(face==UpperFaceSol || face==DownFaceSol)
			 until=8;
		 else
			 until=9;
		 for(int i=0;i<until;i++){
			 temp=GameObject.Find(face[i]);
			 temp.transform.SetParent(rubix.transform);
		 }
	 }
	void AllInOneUpdateCW(string []x){
		if(x==DownFaceSol){
			string[] NewString=new string[8];
			for(int i=7;i>=2;i--)
				NewString[i-2]=DownFaceSol[i];
			NewString[6]=DownFaceSol[0];
			NewString[7]=DownFaceSol[1];
			for(int i=0;i<8;i++)
				DownFaceSol[i]=NewString[i];
		}
		else if(x==UpperFaceSol){
			string[] NewString=new string[8];
			for(int i=0;i<8;i++)
				NewString[(i+2)%8]=UpperFaceSol[i];
			for(int i=0;i<8;i++)
				UpperFaceSol[i]=NewString[i];
		}
		else if(x==OrangeFaceSol){
			 string[]ForCopy=new string[9];
			ForCopy[0]=OrangeFaceSol[2];
			ForCopy[1]=OrangeFaceSol[5];
			ForCopy[2]=OrangeFaceSol[8];
			ForCopy[3]=OrangeFaceSol[1];
			ForCopy[4]=OrangeFaceSol[4];
			ForCopy[5]=OrangeFaceSol[7];
			ForCopy[6]=OrangeFaceSol[0];
			ForCopy[7]=OrangeFaceSol[3];
			ForCopy[8]=OrangeFaceSol[6];
			for(int i=0;i<9;i++)
				OrangeFaceSol[i]=ForCopy[i];
		}
		else if(x==BlueFaceSol){
			 string[]ForCopy=new string[9];
		 ForCopy[0]=BlueFaceSol[2];
		ForCopy[1]=BlueFaceSol[5];
		ForCopy[2]=BlueFaceSol[8];
		ForCopy[3]=BlueFaceSol[1];
		ForCopy[4]=BlueFaceSol[4];
		ForCopy[5]=BlueFaceSol[7];
		ForCopy[6]=BlueFaceSol[0];
		ForCopy[7]=BlueFaceSol[3];
		ForCopy[8]=BlueFaceSol[6];
		for(int i=0;i<9;i++)
			BlueFaceSol[i]=ForCopy[i];
		}
		else if(x==GreenFaceSol){
			 string[]ForCopy=new string[9];
			ForCopy[0]=GreenFaceSol[2];
			ForCopy[1]=GreenFaceSol[5];
			ForCopy[2]=GreenFaceSol[8];
			ForCopy[3]=GreenFaceSol[1];
			ForCopy[4]=GreenFaceSol[4];
			ForCopy[5]=GreenFaceSol[7];
			ForCopy[6]=GreenFaceSol[0];
			ForCopy[7]=GreenFaceSol[3];
			ForCopy[8]=GreenFaceSol[6];
			for(int i=0;i<9;i++)
				GreenFaceSol[i]=ForCopy[i];
		}
		else if(x==YellowFaceSol){
			string[]ForCopy=new string[9];
		ForCopy[0]=YellowFaceSol[6];
		ForCopy[1]=YellowFaceSol[3];
		ForCopy[2]=YellowFaceSol[0];
		ForCopy[3]=YellowFaceSol[7];
		ForCopy[4]=YellowFaceSol[4];
		ForCopy[5]=YellowFaceSol[1];
		ForCopy[6]=YellowFaceSol[8];
		ForCopy[7]=YellowFaceSol[5];
		ForCopy[8]=YellowFaceSol[2];
		for(int i=0;i<9;i++)
			YellowFaceSol[i]=ForCopy[i];
		}
			
	}
	void AllInOneUpdateCCW(string []x){
		if(x==DownFaceSol){
			string[] NewString=new string[8];
			for(int i=0;i<8;i++)
				NewString[(i+2)%8]=DownFaceSol[i];
			for(int i=0;i<8;i++)
				DownFaceSol[i]=NewString[i];
		}
		else if(x==UpperFaceSol){
			string[] NewString=new string[8];
			for(int i=7;i>=2;i--)
				NewString[i-2]=UpperFaceSol[i];
			NewString[6]=UpperFaceSol[0];
			NewString[7]=UpperFaceSol[1];
			for(int i=0;i<8;i++)
				UpperFaceSol[i]=NewString[i];
		}
		else if(x==OrangeFaceSol){
			string[]ForCopy=new string[9];
			ForCopy[0]=OrangeFaceSol[6];
			ForCopy[1]=OrangeFaceSol[3];
			ForCopy[2]=OrangeFaceSol[0];
			ForCopy[3]=OrangeFaceSol[7];
			ForCopy[4]=OrangeFaceSol[4];
			ForCopy[5]=OrangeFaceSol[1];
			ForCopy[6]=OrangeFaceSol[8];
			ForCopy[7]=OrangeFaceSol[5];
			ForCopy[8]=OrangeFaceSol[2];
			for(int i=0;i<9;i++)
				OrangeFaceSol[i]=ForCopy[i];
		}
		else if(x==BlueFaceSol){
			 string[]ForCopy=new string[9];
		ForCopy[0]=BlueFaceSol[6];
		ForCopy[1]=BlueFaceSol[3];
		ForCopy[2]=BlueFaceSol[0];
		ForCopy[3]=BlueFaceSol[7];
		ForCopy[4]=BlueFaceSol[4];
		ForCopy[5]=BlueFaceSol[1];
		ForCopy[6]=BlueFaceSol[8];
		ForCopy[7]=BlueFaceSol[5];
		ForCopy[8]=BlueFaceSol[2];
		for(int i=0;i<9;i++)
			BlueFaceSol[i]=ForCopy[i];
		}
		else if(x==GreenFaceSol){
			 string[]ForCopy=new string[9];
		ForCopy[0]=GreenFaceSol[6];
		ForCopy[1]=GreenFaceSol[3];
		ForCopy[2]=GreenFaceSol[0];
		ForCopy[3]=GreenFaceSol[7];
		ForCopy[4]=GreenFaceSol[4];
		ForCopy[5]=GreenFaceSol[1];
		ForCopy[6]=GreenFaceSol[8];
		ForCopy[7]=GreenFaceSol[5];
		ForCopy[8]=GreenFaceSol[2];
		for(int i=0;i<9;i++)
			GreenFaceSol[i]=ForCopy[i];
		}
		else if(x==YellowFaceSol){
			string[]ForCopy=new string[9];
		ForCopy[0]=YellowFaceSol[2];
		ForCopy[1]=YellowFaceSol[5];
		ForCopy[2]=YellowFaceSol[8];
		ForCopy[3]=YellowFaceSol[1];
		ForCopy[4]=YellowFaceSol[4];
		ForCopy[5]=YellowFaceSol[7];
		ForCopy[6]=YellowFaceSol[0];
		ForCopy[7]=YellowFaceSol[3];
		ForCopy[8]=YellowFaceSol[6];
		for(int i=0;i<9;i++)
			YellowFaceSol[i]=ForCopy[i];
		}
	}
	void AllInOneUpdateFace(string []x){
		if(x==DownFaceSol){
			k=6;
		for(int i=0;i<3;i++)
			GreenFaceSol[k++]=DownFaceSol[i];
		k=6;
		for(int i=2;i<5;i++)
			OrangeFaceSol[k++]=DownFaceSol[i];
		k=6;
		for(int i=4;i<7;i++)
			YellowFaceSol[k++]=DownFaceSol[i];		
		k=6;
		for(int i=6;i<9;i++)
			BlueFaceSol[k++]=DownFaceSol[i%8];
		}
		else if(x==UpperFaceSol){
			k=0;
		for(int i=0;i<3;i++)
			GreenFaceSol[k++]=UpperFaceSol[i];
		k=0;
		for(int i=2;i<5;i++)
			OrangeFaceSol[k++]=UpperFaceSol[i];
		k=0;
		for(int i=4;i<7;i++)
			YellowFaceSol[k++]=UpperFaceSol[i];		
		k=0;
		for(int i=6;i<9;i++)
			BlueFaceSol[k++]=UpperFaceSol[i%8];
		}
		else if(x==OrangeFaceSol){
		YellowFaceSol[0]=OrangeFaceSol[2];
		YellowFaceSol[3]=OrangeFaceSol[5];
		YellowFaceSol[6]=OrangeFaceSol[8];
		
		GreenFaceSol[2]=OrangeFaceSol[0];
		GreenFaceSol[5]=OrangeFaceSol[3];
		GreenFaceSol[8]=OrangeFaceSol[6];
		
		DownFaceSol[2]=OrangeFaceSol[6];
		DownFaceSol[3]=OrangeFaceSol[7];
		DownFaceSol[4]=OrangeFaceSol[8];
		
		UpperFaceSol[2]=OrangeFaceSol[0];
		UpperFaceSol[3]=OrangeFaceSol[1];
		UpperFaceSol[4]=OrangeFaceSol[2];
		}
		else if(x==BlueFaceSol){
		YellowFaceSol[2]=BlueFaceSol[0];
		YellowFaceSol[5]=BlueFaceSol[3];
		YellowFaceSol[8]=BlueFaceSol[6];
		
		GreenFaceSol[0]=BlueFaceSol[2];
		GreenFaceSol[3]=BlueFaceSol[5];
		GreenFaceSol[6]=BlueFaceSol[8];
		
		DownFaceSol[0]=BlueFaceSol[8];
		DownFaceSol[6]=BlueFaceSol[6];
		DownFaceSol[7]=BlueFaceSol[7];
		
		UpperFaceSol[0]=BlueFaceSol[2];
		UpperFaceSol[6]=BlueFaceSol[0];
		UpperFaceSol[7]=BlueFaceSol[1];
		}
		else if(x==GreenFaceSol){
			DownFaceSol[0]=GreenFaceSol[6];
		DownFaceSol[1]=GreenFaceSol[7];
		DownFaceSol[2]=GreenFaceSol[8];
		
		UpperFaceSol[0]=GreenFaceSol[0];
		UpperFaceSol[1]=GreenFaceSol[1];
		UpperFaceSol[2]=GreenFaceSol[2];
		
		BlueFaceSol[2]=GreenFaceSol[0];
		BlueFaceSol[5]=GreenFaceSol[3];
		BlueFaceSol[8]=GreenFaceSol[6];
		
		OrangeFaceSol[0]=GreenFaceSol[2];
		OrangeFaceSol[3]=GreenFaceSol[5];
		OrangeFaceSol[6]=GreenFaceSol[8];
		}
		else if(x==YellowFaceSol){
			 DownFaceSol[4]=YellowFaceSol[6];
		DownFaceSol[5]=YellowFaceSol[7];
		DownFaceSol[6]=YellowFaceSol[8];
		
		UpperFaceSol[4]=YellowFaceSol[0];
		UpperFaceSol[5]=YellowFaceSol[1];
		UpperFaceSol[6]=YellowFaceSol[2];
		
		BlueFaceSol[0]=YellowFaceSol[2];
		BlueFaceSol[3]=YellowFaceSol[5];
		BlueFaceSol[6]=YellowFaceSol[8];
		
		OrangeFaceSol[2]=YellowFaceSol[0];
		OrangeFaceSol[5]=YellowFaceSol[3];
		OrangeFaceSol[8]=YellowFaceSol[6];
		}
	}	
	
	public void nextStep() {
		if(i<output.Count){
		if (output[i]=="UCW"){
				solMsgs="Rotate upper face clock wise";
				PutStuffInParent(UpperFaceSol);
				UpFaceFlagcw=true;
			}
			if (output[i]=="UCCW"){
				solMsgs="Rotate upper face counter clock wise";
				PutStuffInParent(UpperFaceSol);
				UpFaceFlagccw=true;
			}
			if (output[i]=="U180"){
				solMsgs="Rotate upper face 180 degree";
				U180=true;
			}
			if (output[i]=="BCW"){
				solMsgs="Rotate back face clock wise";
				YellowFaceFlagcw=true;
				PutStuffInParent(YellowFaceSol);
			}
			if (output[i]=="BCCW"){
				solMsgs="Rotate back face counter clock wise";
				YellowFaceFlagccw=true;
				PutStuffInParent(YellowFaceSol);
			}
			if (output[i]=="B180"){
				solMsgs="Rotate back face 180 degree";
				B180=true;
			}
			if (output[i]=="FCW"){
				solMsgs="Rotate front face clock wise";
				GreenFaceFlagcw=true;
				PutStuffInParent(GreenFaceSol);
			}
			if (output[i]=="FCCW"){
				solMsgs="Rotate front face counter  clock wise";
				GreenFaceFlagccw=true;
				PutStuffInParent(GreenFaceSol);
			}
			if (output[i]=="F180"){
				solMsgs="Rotate front face 180 degree";
				F180=true;
			}
			if (output[i]=="RCW"){
				solMsgs="Rotate right face clock wise";
				PutStuffInParent(BlueFaceSol);
				BlueFaceFlagcw=true;
			}
			if (output[i]=="RCCW"){
				solMsgs="Rotate right face counter clock wise";
				PutStuffInParent(BlueFaceSol);
				BlueFaceFlagccw=true;
			}
			if (output[i]=="R180"){
				solMsgs="Rotate right face counter 180 degree";
				R180=true;
			}
			if (output[i]=="LCW"){
				solMsgs="Rotate left face clock wise";
				PutStuffInParent(OrangeFaceSol);
				OrangeFaceFlagcw=true;
			}
			if (output[i]=="LCCW"){
				solMsgs="Rotate left face counter clock wise";
				PutStuffInParent(OrangeFaceSol);
				OrangeFaceFlagccw=true;
			}
			if (output[i]=="L180"){
				solMsgs="Rotate left face 180 degree";
				L180=true;
			}
			if (output[i]=="DCW"){
				solMsgs="Rotate down face clock wise";
				PutStuffInParent(DownFaceSol);
				DownFaceFlagcw=true;
			}
			if (output[i]=="DCCW"){
				solMsgs="Rotate down face counter clock wise";
				PutStuffInParent(DownFaceSol);
				DownFaceFlagccw=true;
			}
			if (output[i]=="D180"){
				solMsgs="Rotate down face 180 degree";
				D180=true;
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
		if(Mathf.Abs(totalRotation) < 90f){
			totalRotation += 10;
			Parent.transform.RotateAround(red.transform.position,Vector3.up,10);
		}
		if(Mathf.Abs(totalRotation)>=90f){
			totalRotation=0;
			PutStuffInRubix(UpperFaceSol);
			AllInOneUpdateCW(UpperFaceSol);
			AllInOneUpdateFace(UpperFaceSol);
			UpFaceFlagcw=false;
		}
	 }
	 if(UpFaceFlagccw){
		if(Mathf.Abs(totalRotation) < 90f){
			totalRotation += 10;
			Parent.transform.RotateAround(red.transform.position,-1*Vector3.up,10);
		}
		if(Mathf.Abs(totalRotation)>=90f){
			totalRotation=0;
			PutStuffInRubix(UpperFaceSol);
			AllInOneUpdateCCW(UpperFaceSol);
			AllInOneUpdateFace(UpperFaceSol);
			UpFaceFlagccw=false;
		}
	 }
	 if(U180){
		PutStuffInParent(UpperFaceSol);
		if(Mathf.Abs(totalRotation) < 90){
			totalRotation += 10;
			Parent.transform.RotateAround(red.transform.position,-1*Vector3.up,10);
		}
		if(Mathf.Abs(totalRotation)>=90){
			PutStuffInRubix(UpperFaceSol);
			AllInOneUpdateCCW(UpperFaceSol);
			AllInOneUpdateFace(UpperFaceSol);
			totalRotation=0;
			U180=false;
			Uagain=true;
		}
	 }
	 if(Uagain){
		 PutStuffInParent(UpperFaceSol);
		if(Mathf.Abs(totalRotation) < 90){
			totalRotation += 10;
			Parent.transform.RotateAround(red.transform.position,-1*Vector3.up,10);
		}
		if(Mathf.Abs(totalRotation)>=90){
			PutStuffInRubix(UpperFaceSol);
			AllInOneUpdateCCW(UpperFaceSol);
			AllInOneUpdateFace(UpperFaceSol);
			totalRotation=0;
			Uagain=false;
		}
	 }
	 if(OrangeFaceFlagcw){
		if(Mathf.Abs(totalRotation) < 90){
			totalRotation += 10;
			Parent.transform.RotateAround(orange.transform.position,-1*orange.transform.right,10);
		}
		if(Mathf.Abs(totalRotation)>=90){
			PutStuffInRubix(OrangeFaceSol);
			AllInOneUpdateCW(OrangeFaceSol);
			AllInOneUpdateFace(OrangeFaceSol);
			OrangeFaceFlagcw=false;
			totalRotation=0;
		}
	 }
	 if(OrangeFaceFlagccw){
		if(Mathf.Abs(totalRotation) < 90f){
			totalRotation += 10;
			Parent.transform.RotateAround(orange.transform.position,orange.transform.right,10);
		}
		if(Mathf.Abs(totalRotation)>=90f){
			PutStuffInRubix(OrangeFaceSol);
			AllInOneUpdateCCW(OrangeFaceSol);
			AllInOneUpdateFace(OrangeFaceSol);
			OrangeFaceFlagccw=false;
			totalRotation=0;
		}
	 }
	 if(L180){
		PutStuffInParent(OrangeFaceSol);
		if(Mathf.Abs(totalRotation) < 90){
			totalRotation += 10;
			Parent.transform.RotateAround(orange.transform.position,orange.transform.right,10);
		}
		if(Mathf.Abs(totalRotation)>=90){
			PutStuffInRubix(OrangeFaceSol);
			AllInOneUpdateCCW(OrangeFaceSol);
			AllInOneUpdateFace(OrangeFaceSol);
			totalRotation=0;
			L180=false;
			Lagain=true;
			}
	 }
	 if(Lagain){
		 PutStuffInParent(OrangeFaceSol);
		if(Mathf.Abs(totalRotation) < 90){
			totalRotation += 10;
			Parent.transform.RotateAround(orange.transform.position,orange.transform.right,10);
		}
		if(Mathf.Abs(totalRotation)>=90){
			PutStuffInRubix(OrangeFaceSol);
			AllInOneUpdateCCW(OrangeFaceSol);
			AllInOneUpdateFace(OrangeFaceSol);
			totalRotation=0;
			Lagain=false;	
		}
	 }	
	 if(BlueFaceFlagcw){
		if(Mathf.Abs(totalRotation) < 90f){
			totalRotation += 10;
			Parent.transform.RotateAround(blue.transform.position,blue.transform.right,10);
		}
		if(Mathf.Abs(totalRotation)>=90f){
			PutStuffInRubix(BlueFaceSol);
			AllInOneUpdateCW(BlueFaceSol);
			AllInOneUpdateFace(BlueFaceSol);
			BlueFaceFlagcw=false;
			totalRotation=0;
		}
	 } 
	 if(BlueFaceFlagccw){
		if(Mathf.Abs(totalRotation) < 90f){
			totalRotation += 10;
			Parent.transform.RotateAround(blue.transform.position,-1*blue.transform.right,10);
		}
		if(Mathf.Abs(totalRotation)>=90f){
			PutStuffInRubix(BlueFaceSol);
			AllInOneUpdateCCW(BlueFaceSol);
			AllInOneUpdateFace(BlueFaceSol);
			BlueFaceFlagccw=false;
			totalRotation=0;
		}
	 }
	 if(R180){
		PutStuffInParent(BlueFaceSol);
		if(Mathf.Abs(totalRotation) < 90){
			totalRotation += 10;
			Parent.transform.RotateAround(blue.transform.position,-1*blue.transform.right,10);
			}
		if(Mathf.Abs(totalRotation)>=90){
			PutStuffInRubix(BlueFaceSol);
			AllInOneUpdateCCW(BlueFaceSol);
			AllInOneUpdateFace(BlueFaceSol);
			totalRotation=0;
			R180=false;
			Ragain=true;
		}
	 }
	 if(Ragain){
		PutStuffInParent(BlueFaceSol);
		if(Mathf.Abs(totalRotation) < 90){
			totalRotation += 10;
			Parent.transform.RotateAround(blue.transform.position,-1*blue.transform.right,10);
		}
		if(Mathf.Abs(totalRotation)>=90){
			PutStuffInRubix(BlueFaceSol);
			AllInOneUpdateCCW(BlueFaceSol);
			AllInOneUpdateFace(BlueFaceSol);
			totalRotation=0;
			Ragain=false;
		}
	 }
	 if(DownFaceFlagcw){
		if(Mathf.Abs(totalRotation) < 90f){
			totalRotation += 10;
			Parent.transform.RotateAround(white.transform.position,-1*white.transform.up,10);
		}
		if(Mathf.Abs(totalRotation)>=90f){
			PutStuffInRubix(DownFaceSol);
			AllInOneUpdateCW(DownFaceSol);
			AllInOneUpdateFace(DownFaceSol);
			DownFaceFlagcw=false;
			totalRotation=0;
		}
	 } 
	 if(DownFaceFlagccw){
		if(Mathf.Abs(totalRotation) < 90f){
			totalRotation += 10;
			Parent.transform.RotateAround(white.transform.position,white.transform.up,10);
		}
		if(Mathf.Abs(totalRotation)>=90f){
			PutStuffInRubix(DownFaceSol);
			AllInOneUpdateCCW(DownFaceSol);
			AllInOneUpdateFace(DownFaceSol);
			DownFaceFlagccw=false;
			totalRotation=0;
		}
	 }
	if(D180){
		PutStuffInParent(DownFaceSol);
		if(Mathf.Abs(totalRotation) < 90){
			totalRotation += 10;
			Parent.transform.RotateAround(white.transform.position,white.transform.up,10);
		}
		if(Mathf.Abs(totalRotation)>=90){
			PutStuffInRubix(DownFaceSol);
			AllInOneUpdateCCW(DownFaceSol);
			AllInOneUpdateFace(DownFaceSol);
			totalRotation=0;
			D180=false;
			Dagain=true;
			}
	}
	if(Dagain){
		PutStuffInParent(DownFaceSol);
		if(Mathf.Abs(totalRotation) < 90){
			totalRotation += 10;
			Parent.transform.RotateAround(white.transform.position,white.transform.up,10);
		}
		if(Mathf.Abs(totalRotation)>=90){
			PutStuffInRubix(DownFaceSol);
			AllInOneUpdateCCW(DownFaceSol);
			AllInOneUpdateFace(DownFaceSol);
			totalRotation=0;
			Dagain=false;
		}
	}
		
	 if(GreenFaceFlagcw){
		 if(Mathf.Abs(totalRotation) < 90f){
			totalRotation += 10;
			Parent.transform.RotateAround(green.transform.position,-1*green.transform.forward,10);
		}
		if(Mathf.Abs(totalRotation)>=90f){
			PutStuffInRubix(GreenFaceSol);
			AllInOneUpdateCW(GreenFaceSol);
			AllInOneUpdateFace(GreenFaceSol);
			GreenFaceFlagcw=false;
			totalRotation=0;
		}
	 }
	 if(GreenFaceFlagccw){
		 if(Mathf.Abs(totalRotation) < 90f){
			totalRotation += 10;
			Parent.transform.RotateAround(green.transform.position,green.transform.forward,10);
		}
		if(Mathf.Abs(totalRotation)>=90f){
			PutStuffInRubix(GreenFaceSol);
			AllInOneUpdateCCW(GreenFaceSol);
			AllInOneUpdateFace(GreenFaceSol);
			GreenFaceFlagccw=false;
			totalRotation=0;
		}
	 } 
	 if(YellowFaceFlagcw){
		 if(Mathf.Abs(totalRotation) < 90f){
			totalRotation += 10;
			Parent.transform.RotateAround(yellow.transform.position,-1*yellow.transform.forward,10);
		}
		if(Mathf.Abs(totalRotation)>=90f){
			PutStuffInRubix(YellowFaceSol);
			AllInOneUpdateCW(YellowFaceSol);
			AllInOneUpdateFace(YellowFaceSol);
			YellowFaceFlagcw=false;
			totalRotation=0;
		}
	 }
	 if(YellowFaceFlagccw){
		 if(Mathf.Abs(totalRotation) < 90f){
			totalRotation += 10;
			Parent.transform.RotateAround(yellow.transform.position,yellow.transform.forward,10);
		}
		if(Mathf.Abs(totalRotation)>=90f){
			PutStuffInRubix(YellowFaceSol);
			AllInOneUpdateCCW(YellowFaceSol);
			AllInOneUpdateFace(YellowFaceSol);
			YellowFaceFlagccw=false;
			totalRotation=0;
		}
	 }
	 if(B180){
		PutStuffInParent(YellowFaceSol);
		if(Mathf.Abs(totalRotation) < 90){
			totalRotation += 10;
			Parent.transform.RotateAround(yellow.transform.position,yellow.transform.forward,10);
		}
		if(Mathf.Abs(totalRotation)>=90){
			PutStuffInRubix(YellowFaceSol);
			AllInOneUpdateCCW(YellowFaceSol);
			AllInOneUpdateFace(YellowFaceSol);
			totalRotation=0;
			B180=false;
			Bagain=true;
			}
	 }
	 if(Bagain){
		 PutStuffInParent(YellowFaceSol);
		if(Mathf.Abs(totalRotation) < 90){
			totalRotation += 10;
			Parent.transform.RotateAround(yellow.transform.position,yellow.transform.forward,10);
		}
		if(Mathf.Abs(totalRotation)>=90){
			PutStuffInRubix(YellowFaceSol);
			AllInOneUpdateCCW(YellowFaceSol);
			AllInOneUpdateFace(YellowFaceSol);
			totalRotation=0;
			Bagain=false;
		}
	 }
	 if(F180){
		PutStuffInParent(GreenFaceSol);
		if(Mathf.Abs(totalRotation) < 90){
			totalRotation += 10;
			Parent.transform.RotateAround(green.transform.position,green.transform.forward,10);
		}
		if(Mathf.Abs(totalRotation)>=90){
			PutStuffInRubix(GreenFaceSol);
			AllInOneUpdateCCW(GreenFaceSol);
			AllInOneUpdateFace(GreenFaceSol);	
			totalRotation=0;
			F180=false;
			Fagain=true;
		 }
	 }
	 if(Fagain){
		 PutStuffInParent(GreenFaceSol);
		if(Mathf.Abs(totalRotation) < 90){
			totalRotation += 10;
			Parent.transform.RotateAround(green.transform.position,green.transform.forward,10);
		}
		if(Mathf.Abs(totalRotation)>=90){
			PutStuffInRubix(GreenFaceSol);
			AllInOneUpdateCCW(GreenFaceSol);
			AllInOneUpdateFace(GreenFaceSol);	
			totalRotation=0;
			Fagain=false;
		 }
	 }
	 
	}
}