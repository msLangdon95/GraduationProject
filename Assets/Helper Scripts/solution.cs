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
	public Transform camera;
	GameObject look;
	public static List<string> output=new List<string>();
	List<Color> doItAgain=new List<Color>();
	float totalRotation=0;
	int i,k,NextStepCounter=0; 
	string solMsgs;
	GameObject myMSG,EndOfSolution,Parent,temp,blue,white,orange,red,yellow,green,rubix,nextButton,Moves;
	string[]UpperFaceSol={"Corner7","Edge7","Corner3","Edge2","Corner1","Edge5","Corner6","Edge11"};
	string[]DownFaceSol={"Corner8","Edge8","Corner4","Edge3","Corner2","Edge6","Corner5","Edge10"};
	string[]GreenFaceSol={"Corner7","Edge7","Corner3","Edge12","GREEN", "Edge4","Corner8","Edge8","Corner4"};
	string[]BlueFaceSol={"Corner6","Edge11","Corner7","Edge9","BLUE","Edge12","Corner5","Edge10","Corner8"};
	string[]OrangeFaceSol={"Corner3","Edge2","Corner1","Edge4","ORANGE","Edge1","Corner4","Edge3","Corner2"};
	string[]YellowFaceSol={"Corner1","Edge5","Corner6","Edge1","YELLOW","Edge9","Corner2","Edge6","Corner5"};
	bool inFirst=false;
	void Start () {
		nextButton=GameObject.Find("NextStepButton");
		Moves=GameObject.Find("Moves");
		rubix=GameObject.Find("RubiksCube");
		 blue=GameObject.Find("BLUE");
		 red=GameObject.Find("RED");
		 orange=GameObject.Find("ORANGE");
		 white=GameObject.Find("WHITE");
		 yellow=GameObject.Find("YELLOW");
		 green=GameObject.Find("GREEN");
		Parent=GameObject.Find("Parent");
		//Color it
		for(int i=0;i<48;i++){
			GameObject.Find(Globals.EdgesAndCorners[i]).GetComponent<Renderer>().material.color=OptimalSolution.GoToSolve[i];
			doItAgain.Add(OptimalSolution.GoToSolve[i]);
		}
		EndOfSolution = GameObject.Find ("EndOfSolution");
		EndOfSolution.SetActive (false);
		myMSG = GameObject.Find ("Mymsg");
		Moves.transform.GetComponent<Text>().text=OptimalSolution.StepsOfSolution.ToString()+" Steps ";
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
	
	IEnumerator RotateUpperFacecw(){
		 inFirst = true;
		 nextButton.GetComponent<Button>().interactable = false;
		 PutStuffInParent(UpperFaceSol);
		 while(Mathf.Abs(totalRotation) < 90f){
			totalRotation += 10;
			Parent.transform.RotateAround(red.transform.position,Vector3.up,10);
			yield return 0;
		}
		if(Mathf.Abs(totalRotation)>=90f){
			totalRotation=0;
			PutStuffInRubix(UpperFaceSol);
			AllInOneUpdateCW(UpperFaceSol);
			AllInOneUpdateFace(UpperFaceSol);
		}
		 inFirst = false;
		 nextButton.GetComponent<Button>().interactable = true;
	 }	 
	 IEnumerator RotateUpperFaceccw(){
		  inFirst = true;
		  nextButton.GetComponent<Button>().interactable = false;
		 PutStuffInParent(UpperFaceSol);
		 while(Mathf.Abs(totalRotation) < 90f){
			totalRotation += 10;
			Parent.transform.RotateAround(red.transform.position,-1*Vector3.up,10);
			yield return 0;
		}
		if(Mathf.Abs(totalRotation)>=90f){
			totalRotation=0;
			PutStuffInRubix(UpperFaceSol);
			AllInOneUpdateCCW(UpperFaceSol);
			AllInOneUpdateFace(UpperFaceSol);
		}
		 inFirst = false;
		 nextButton.GetComponent<Button>().interactable = true;
	 }
	
	IEnumerator RotateDownFacecw(){
		inFirst = true;
		nextButton.GetComponent<Button>().interactable = false;
		PutStuffInParent(DownFaceSol);
		while(Mathf.Abs(totalRotation) < 90f){
			totalRotation += 10;
			Parent.transform.RotateAround(white.transform.position,-1*Vector3.up,10);
			yield return 0;
		}
		if(Mathf.Abs(totalRotation)>=90f){
			PutStuffInRubix(DownFaceSol);
			AllInOneUpdateCW(DownFaceSol);
			AllInOneUpdateFace(DownFaceSol);
			totalRotation=0;
			yield return 0;
		}
		inFirst = false;
		nextButton.GetComponent<Button>().interactable = true;
	 }
	 IEnumerator RotateDownFaceccw(){
		 inFirst = true;
		 nextButton.GetComponent<Button>().interactable = false;
		 PutStuffInParent(DownFaceSol);
		 while(Mathf.Abs(totalRotation) < 90f){
			totalRotation += 10;
			Parent.transform.RotateAround(white.transform.position,Vector3.up,10);
			yield return 0;
		}
		if(Mathf.Abs(totalRotation)>=90f){
			PutStuffInRubix(DownFaceSol);
			AllInOneUpdateCCW(DownFaceSol);
			AllInOneUpdateFace(DownFaceSol);
			totalRotation=0;
			yield return 0;
		}
		inFirst = false;
		nextButton.GetComponent<Button>().interactable = true;
	 }
	
	IEnumerator RotateLeftFacecw(){
		inFirst = true;
		nextButton.GetComponent<Button>().interactable = false;
		 PutStuffInParent(OrangeFaceSol);
		 while(Mathf.Abs(totalRotation) < 90){
			totalRotation += 10;
			Parent.transform.RotateAround(orange.transform.position,-1*Vector3.right,10);
			yield return 0;
		}
		if(Mathf.Abs(totalRotation)>=90){
			PutStuffInRubix(OrangeFaceSol);
			AllInOneUpdateCW(OrangeFaceSol);
			AllInOneUpdateFace(OrangeFaceSol);
			totalRotation=0;
			yield return 0;
		}
		inFirst = false;
		nextButton.GetComponent<Button>().interactable = true;
	 }
	 IEnumerator RotateLeftFaceccw(){
		 inFirst = true;
		 nextButton.GetComponent<Button>().interactable = false;
		 PutStuffInParent(OrangeFaceSol);
		 while(Mathf.Abs(totalRotation) < 90f){
			totalRotation += 10;
			Parent.transform.RotateAround(orange.transform.position,Vector3.right,10);
			yield return 0;
		}
		if(Mathf.Abs(totalRotation)>=90f){
			PutStuffInRubix(OrangeFaceSol);
			AllInOneUpdateCCW(OrangeFaceSol);
			AllInOneUpdateFace(OrangeFaceSol);
			totalRotation=0;
			yield return 0;
		}
		inFirst = false;
		nextButton.GetComponent<Button>().interactable = true;
	 }
	IEnumerator RotateRightFacecw(){
		inFirst = true;
		nextButton.GetComponent<Button>().interactable = false;
		 PutStuffInParent(BlueFaceSol);
		 while(Mathf.Abs(totalRotation) < 90f){
			totalRotation += 10;
			Parent.transform.RotateAround(blue.transform.position,Vector3.right,10);
			yield return 0;
		}
		if(Mathf.Abs(totalRotation)>=90f){
			PutStuffInRubix(BlueFaceSol);
			AllInOneUpdateCW(BlueFaceSol);
			AllInOneUpdateFace(BlueFaceSol);
			totalRotation=0;
			yield return 0;
		}
		inFirst = false;
		nextButton.GetComponent<Button>().interactable = true;
	 }
	 IEnumerator RotateRightFaceccw(){
		 inFirst = true;
		 nextButton.GetComponent<Button>().interactable = false;
		 PutStuffInParent(BlueFaceSol);
		 while(Mathf.Abs(totalRotation) < 90f){
			totalRotation += 10;
			Parent.transform.RotateAround(blue.transform.position,-1*Vector3.right,10);
			yield return 0;
		}
		if(Mathf.Abs(totalRotation)>=90f){
			PutStuffInRubix(BlueFaceSol);
			AllInOneUpdateCCW(BlueFaceSol);
			AllInOneUpdateFace(BlueFaceSol);
			totalRotation=0;
			yield return 0;
		}
		inFirst = false;
		nextButton.GetComponent<Button>().interactable = true;
	 }
	 IEnumerator RotateFrontFacecw(){
		 inFirst = true;
		 nextButton.GetComponent<Button>().interactable = false;
		 PutStuffInParent(GreenFaceSol);
		 while(Mathf.Abs(totalRotation) < 90f){
			totalRotation += 10;
			Parent.transform.RotateAround(green.transform.position,-1*Vector3.forward,10);
			yield return 0;
		}
		if(Mathf.Abs(totalRotation)>=90f){
			PutStuffInRubix(GreenFaceSol);
			AllInOneUpdateCW(GreenFaceSol);
			AllInOneUpdateFace(GreenFaceSol);
			totalRotation=0;
		}
		inFirst = false;
		nextButton.GetComponent<Button>().interactable = true;
	 }
	 IEnumerator RotateFrontFaceccw(){
		 inFirst = true;
		 nextButton.GetComponent<Button>().interactable = false;
		 PutStuffInParent(GreenFaceSol);
		 while(Mathf.Abs(totalRotation) < 90){
			totalRotation += 10;
			Parent.transform.RotateAround(green.transform.position,Vector3.forward,10);
			yield return 0;
		}
		if(Mathf.Abs(totalRotation)>=90){
			PutStuffInRubix(GreenFaceSol);
			AllInOneUpdateCCW(GreenFaceSol);
			AllInOneUpdateFace(GreenFaceSol);
			totalRotation=0;
		}
		inFirst = false;
		nextButton.GetComponent<Button>().interactable = true;
	 }
	 IEnumerator RotateBackFacecw(){
		 inFirst = true;
		 nextButton.GetComponent<Button>().interactable = false;
		  PutStuffInParent(YellowFaceSol);
		   while(Mathf.Abs(totalRotation) < 90){
			totalRotation += 10;
			Parent.transform.RotateAround(yellow.transform.position,-1*Vector3.forward,10);
			yield return 0;
		}
		if(Mathf.Abs(totalRotation)>=90){
			PutStuffInRubix(YellowFaceSol);
			AllInOneUpdateCW(YellowFaceSol);
			AllInOneUpdateFace(YellowFaceSol);
			totalRotation=0;
			yield return 0;
		}
		inFirst = false;
		nextButton.GetComponent<Button>().interactable = true;
	 }
	 IEnumerator RotateBackFaceccw(){
		 inFirst = true;
		 nextButton.GetComponent<Button>().interactable = false;
		 PutStuffInParent(YellowFaceSol);
		 while(Mathf.Abs(totalRotation) < 90){
			totalRotation += 10;
			Parent.transform.RotateAround(yellow.transform.position,Vector3.forward,10);
			yield return 0;
		}
		if(Mathf.Abs(totalRotation)>=90){
			PutStuffInRubix(YellowFaceSol);
			AllInOneUpdateCCW(YellowFaceSol);
			AllInOneUpdateFace(YellowFaceSol);
			totalRotation=0;
			yield return 0;
		}
		inFirst = false;
		nextButton.GetComponent<Button>().interactable = true;
	 }
	IEnumerator nextStep(int index) {
		if(index<output.Count){
			nextButton.GetComponentInChildren<Text>().text="Next Step";
		if (output[index]=="UCW"){
				solMsgs="Rotate upper face clock wise";
				StartCoroutine(RotateUpperFacecw());
				 while(inFirst)       
					 yield return new WaitForSeconds(0.1f);
			}
			if (output[index]=="UCCW"){
				solMsgs="Rotate upper face counter clock wise";
				StartCoroutine(RotateUpperFaceccw());
				 while(inFirst)       
					 yield return new WaitForSeconds(0.1f);
			}
			if (output[index]=="U180"){
				solMsgs="Rotate upper face 180 degree";
				StartCoroutine(RotateUpperFacecw());
				 while(inFirst)       
					 yield return new WaitForSeconds(0.1f);
				StartCoroutine(RotateUpperFacecw());
				 while(inFirst)       
					 yield return new WaitForSeconds(0.1f);
			}
			if (output[index]=="BCW"){
				solMsgs="Rotate back face clock wise";
				StartCoroutine(RotateBackFacecw());
				 while(inFirst)       
					 yield return new WaitForSeconds(0.1f);
			}
			if (output[index]=="BCCW"){
				solMsgs="Rotate back face counter clock wise";
				StartCoroutine(RotateBackFaceccw());
				 while(inFirst)       
					 yield return new WaitForSeconds(0.1f);
			}
			if (output[index]=="B180"){
				solMsgs="Rotate back face 180 degree";
				StartCoroutine(RotateBackFacecw());
				 while(inFirst)       
					 yield return new WaitForSeconds(0.1f);
				StartCoroutine(RotateBackFacecw());
				 while(inFirst)       
					 yield return new WaitForSeconds(0.1f);
			}
			if (output[index]=="FCW"){
				solMsgs="Rotate front face clock wise";
				StartCoroutine(RotateFrontFacecw());
				 while(inFirst)       
					 yield return new WaitForSeconds(0.1f);
			}
			if (output[index]=="FCCW"){
				solMsgs="Rotate front face counter  clock wise";
				StartCoroutine(RotateFrontFaceccw());
				 while(inFirst)       
					 yield return new WaitForSeconds(0.1f);
			}
			if (output[index]=="F180"){
				solMsgs="Rotate front face 180 degree";
				StartCoroutine(RotateFrontFacecw());
				 while(inFirst)       
					 yield return new WaitForSeconds(0.1f);
				StartCoroutine(RotateFrontFacecw());
				 while(inFirst)       
					 yield return new WaitForSeconds(0.1f);
			}
			if (output[index]=="RCW"){
				solMsgs="Rotate right face clock wise";
				StartCoroutine(RotateRightFacecw());
				 while(inFirst)       
					 yield return new WaitForSeconds(0.1f);
			}
			if (output[index]=="RCCW"){
				solMsgs="Rotate right face counter clock wise";
				StartCoroutine(RotateRightFaceccw());
				 while(inFirst)       
					 yield return new WaitForSeconds(0.1f);
			}
			if (output[index]=="R180"){
				solMsgs="Rotate right face counter 180 degree";
				StartCoroutine(RotateRightFacecw());
				 while(inFirst)       
					 yield return new WaitForSeconds(0.1f);
				StartCoroutine(RotateRightFacecw());
				 while(inFirst)       
					 yield return new WaitForSeconds(0.1f);
			}
			if (output[index]=="LCW"){
				solMsgs="Rotate left face clock wise";
				StartCoroutine(RotateLeftFacecw());
				 while(inFirst)       
					 yield return new WaitForSeconds(0.1f);
			}
			if (output[index]=="LCCW"){
				solMsgs="Rotate left face counter clock wise";
				StartCoroutine(RotateLeftFaceccw());
				 while(inFirst)       
					 yield return new WaitForSeconds(0.1f);
			}
			if (output[index]=="L180"){
				solMsgs="Rotate left face 180 degree";
				StartCoroutine(RotateLeftFacecw());
				 while(inFirst)       
					 yield return new WaitForSeconds(0.1f);
				StartCoroutine(RotateLeftFacecw());
				 while(inFirst)       
					 yield return new WaitForSeconds(0.1f);
			}
			if (output[index]=="DCW"){
				solMsgs="Rotate down face clock wise";
				StartCoroutine(RotateDownFacecw());
				 while(inFirst)       
					 yield return new WaitForSeconds(0.1f);
			}
			if (output[index]=="DCCW"){
				solMsgs="Rotate down face counter clock wise";
				StartCoroutine(RotateDownFaceccw());
				 while(inFirst)       
					 yield return new WaitForSeconds(0.1f);
			}
			if (output[index]=="D180"){
				solMsgs="Rotate down face 180 degree";
				StartCoroutine(RotateDownFacecw());
				 while(inFirst)       
					 yield return new WaitForSeconds(0.1f);
				StartCoroutine(RotateDownFacecw());
				 while(inFirst)       
					 yield return new WaitForSeconds(0.1f);
			}
		
		myMSG.GetComponent<Text> ().text = solMsgs;
		}
		else{
			EndOfSolution.SetActive (true);
			myMSG.GetComponent<Text> ().text = " ";
			nextButton.GetComponentInChildren<Text>().text="Show Steps";
			nextButton.GetComponent<Button>().interactable = false;
		}
	}
	
	public void beb(){
		StartCoroutine(nextStep(NextStepCounter++));
	}
	public void hideMessage(){
		EndOfSolution.SetActive(false);
		myMSG.GetComponent<Text> ().text = " ";
		nextButton.GetComponent<Button>().interactable = true;
	}
	public void ShowStepsAgain(){
		nextButton.GetComponent<Button>().interactable = true;
		/*UpperFaceSol=preUp;
		DownFaceSol=preDown;
		GreenFaceSol=preGreen;
		BlueFaceSol=preBlue;
		OrangeFaceSol=preOrange;
		YellowFaceSol=preYellow;
		for(int i=0;i<48;i++){
			GameObject.Find(Globals.EdgesAndCorners[i]).GetComponent<Renderer>().material.color=doItAgain[i];
		}*/
		NextStepCounter=0;
		EndOfSolution.SetActive(false);
	}
	
	public void ShowWholeSol(){
	/*	i=0;
		GameObject.Find("ShowAll").GetComponent<Button>().interactable = false;
		//for(i=0;i<output.Count;i++){
			while(i<output.Count){
			if(output[i]=="UCW"){
				PutStuffInParent(UpperFaceSol);
				UpFaceFlagcw=true;
			}
			else if(output[i]=="UCCW"){
				PutStuffInParent(UpperFaceSol);
				UpFaceFlagccw=true;
			}
			else if(output[i]=="U180"){
				U180=true;
			}
			else if(output[i]=="DCW"){
				PutStuffInParent(DownFaceSol);
				DownFaceFlagcw=true;
			}
			else if(output[i]=="DCCW"){
				PutStuffInParent(DownFaceSol);
				DownFaceFlagccw=true;
			}
			else if(output[i]=="D180"){
				D180=true;
			}
			else if(output[i]=="LCW"){
				PutStuffInParent(OrangeFaceSol);
				OrangeFaceFlagcw=true;
			}
			else if(output[i]=="LCCW"){
				PutStuffInParent(OrangeFaceSol);
				OrangeFaceFlagccw=true;
			}
			else if(output[i]=="L180"){
				L180=true;
			}
			else if(output[i]=="RCW"){
				PutStuffInParent(BlueFaceSol);
				BlueFaceFlagcw=true;
			}
			else if(output[i]=="RCCW"){
				PutStuffInParent(BlueFaceSol);
				BlueFaceFlagccw=true;
			}
			else if(output[i]=="R180"){
				R180=true;
			}
			else if(output[i]=="FCW"){
				PutStuffInParent(GreenFaceSol);
				GreenFaceFlagcw=true;
			}
			else if(output[i]=="FCCW"){
				PutStuffInParent(GreenFaceSol);
				GreenFaceFlagccw=true;
			}
			else if(output[i]=="F180"){
				F180=true;
			}
			else if(output[i]=="BCW"){
				PutStuffInParent(YellowFaceSol);
				YellowFaceFlagcw=true;
			}
			else if(output[i]=="BCCW"){
				PutStuffInParent(YellowFaceSol);
				YellowFaceFlagccw=true;
			}
			else if(output[i]=="B180"){
				B180=true;
			}
			if(UpFaceFlagcw==UpFaceFlagccw==U180==DownFaceFlagcw==DownFaceFlagccw==D180==OrangeFaceFlagcw==OrangeFaceFlagccw==L180==
			BlueFaceFlagcw==BlueFaceFlagccw==B180==GreenFaceFlagcw==GreenFaceFlagccw==F180==YellowFaceFlagcw==YellowFaceFlagccw==B180)
				i++;
		}
		GameObject.Find("ShowAll").GetComponent<Button>().interactable = true;*/
	}
	
}