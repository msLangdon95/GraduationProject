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
	GameObject w,lastClicked,Parent,temp,Center,rubix,blue,white,orange,red,yellow,green,steps,UndoButton;
	public static GameObject PleaseWait;
	public static GameObject TooLong;
	GameObject GreenFaceZ,BlueFaceZ,OrangeFaceZ,YellowFaceZ;
	Ray ray;
	RaycastHit rayHit;
	 Vector2 firstPressPos;
	 Vector2 secondPressPos;
	 Vector2 currentSwipe;
	 int k,i,d1,d2,d3,d4,NoOfSteps=0;
	 string[]rightFace;
	 string[]leftFace;
	 float totalRotation = 0;
	 bool inFirst=false;
	 List<string>Moves=new List<string>();
	 public static string[]UpperFace={"Corner7","Edge7","Corner3","Edge2","Corner1","Edge5","Corner6","Edge11"};
	 public static string[]DownFace={"Corner8","Edge8","Corner4","Edge3","Corner2","Edge6","Corner5","Edge10"};
	 public static string[]GreenFace={"Corner7","Edge7","Corner3","Edge12","GREEN", "Edge4","Corner8","Edge8","Corner4"};
	 public static string[]BlueFace={"Corner6","Edge11","Corner7","Edge9","BLUE","Edge12","Corner5","Edge10","Corner8"};
	 public static string[]OrangeFace={"Corner3","Edge2","Corner1","Edge4","ORANGE","Edge1","Corner4","Edge3","Corner2"};
	 public static string[]YellowFace={"Corner1","Edge5","Corner6","Edge1","YELLOW","Edge9","Corner2","Edge6","Corner5"};
	public void WaitAgain(){
		TooLong.SetActive(false);
		OptimalSolution.timer=0f;
	}
	public void GoToHome(){
		TooLong.SetActive(false);
		//kill the process
		//go home again
	}
	public void ExitTooLong(){
		TooLong.SetActive(false);
		//stop the process
		OptimalSolution.paused=false;
	}
	
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
	 
	 IEnumerator RotateUpperFacecw(){
		 inFirst=true;
		 PutStuffInParent(UpperFace);
		 while(Mathf.Abs(totalRotation) < 90f){
			totalRotation += 10;
			Parent.transform.RotateAround(red.transform.position,Vector3.up,10);
			yield return 0;
		}
		if(Mathf.Abs(totalRotation)>=90f){
			totalRotation=0;
			PutStuffInRubix(UpperFace);
			AllInOneUpdateCW(UpperFace);
			AllInOneUpdateFace(UpperFace);
		}
		inFirst=false;
	 }	 
	 IEnumerator RotateUpperFaceccw(){
		 inFirst=true;
		 PutStuffInParent(UpperFace);
		 while(Mathf.Abs(totalRotation) < 90f){
			totalRotation += 10;
			Parent.transform.RotateAround(red.transform.position,-1*Vector3.up,10);
			yield return 0;
		}
		if(Mathf.Abs(totalRotation)>=90f){
			totalRotation=0;
			PutStuffInRubix(UpperFace);
			AllInOneUpdateCCW(UpperFace);
			AllInOneUpdateFace(UpperFace);
		}
		inFirst=false;
	 }
	 IEnumerator RotateDownFacecw(){
		 inFirst=true;
		PutStuffInParent(DownFace);
		while(Mathf.Abs(totalRotation) < 90f){
			totalRotation += 10;
			Parent.transform.RotateAround(white.transform.position,-1*Vector3.up,10);
			yield return 0;
		}
		if(Mathf.Abs(totalRotation)>=90f){
			PutStuffInRubix(DownFace);
			AllInOneUpdateCW(DownFace);
			AllInOneUpdateFace(DownFace);
			totalRotation=0;
		}
		inFirst=false;
	 }
	 IEnumerator RotateDownFaceccw(){
		 inFirst=true;
		 PutStuffInParent(DownFace);
		 while(Mathf.Abs(totalRotation) < 90f){
			totalRotation += 10;
			Parent.transform.RotateAround(white.transform.position,Vector3.up,10);
			yield return 0;
		}
		if(Mathf.Abs(totalRotation)>=90f){
			PutStuffInRubix(DownFace);
			AllInOneUpdateCCW(DownFace);
			AllInOneUpdateFace(DownFace);
			totalRotation=0;
		}
		inFirst=false;
	 }
	 IEnumerator RotateLeftFacecw(){
		 inFirst=true;
		 PutStuffInParent(OrangeFace);
		 while(Mathf.Abs(totalRotation) < 90){
			totalRotation += 10;
			Parent.transform.RotateAround(orange.transform.position,-1*Vector3.right,10);
			yield return 0;
		}
		if(Mathf.Abs(totalRotation)>=90){
			PutStuffInRubix(OrangeFace);
			AllInOneUpdateCW(OrangeFace);
			AllInOneUpdateFace(OrangeFace);
			totalRotation=0;
		}
		inFirst=false;
	 }
	 IEnumerator RotateLeftFaceccw(){
		 inFirst=true;
		 PutStuffInParent(OrangeFace);
		 while(Mathf.Abs(totalRotation) < 90f){
			totalRotation += 10;
			Parent.transform.RotateAround(orange.transform.position,Vector3.right,10);
			yield return 0;
		}
		if(Mathf.Abs(totalRotation)>=90f){
			PutStuffInRubix(OrangeFace);
			AllInOneUpdateCCW(OrangeFace);
			AllInOneUpdateFace(OrangeFace);
			totalRotation=0;
		}
		inFirst=false;
	 }
	 IEnumerator RotateRightFacecw(){
		 inFirst=true;
		 PutStuffInParent(BlueFace);
		 while(Mathf.Abs(totalRotation) < 90f){
			totalRotation += 10;
			Parent.transform.RotateAround(blue.transform.position,Vector3.right,10);
			yield return 0;
		}
		if(Mathf.Abs(totalRotation)>=90f){
			PutStuffInRubix(BlueFace);
			AllInOneUpdateCW(BlueFace);
			AllInOneUpdateFace(BlueFace);
			totalRotation=0;
		}
		inFirst=false;
	 }
	 IEnumerator RotateRightFaceccw(){
		 inFirst=true;
		 PutStuffInParent(BlueFace);
		 while(Mathf.Abs(totalRotation) < 90f){
			totalRotation += 10;
			Parent.transform.RotateAround(blue.transform.position,-1*Vector3.right,10);
			yield return 0;
		}
		if(Mathf.Abs(totalRotation)>=90f){
			PutStuffInRubix(BlueFace);
			AllInOneUpdateCCW(BlueFace);
			AllInOneUpdateFace(BlueFace);
			totalRotation=0;
		}
		inFirst=false;
	 }
	 IEnumerator RotateFrontFacecw(){
		 inFirst=true;
		 PutStuffInParent(GreenFace);
		 while(Mathf.Abs(totalRotation) < 90f){
			totalRotation += 10;
			Parent.transform.RotateAround(green.transform.position,-1*Vector3.forward,10);
			yield return 0;
		}
		if(Mathf.Abs(totalRotation)>=90f){
			PutStuffInRubix(GreenFace);
			AllInOneUpdateCW(GreenFace);
			AllInOneUpdateFace(GreenFace);
			totalRotation=0;
		}
		inFirst=false;
	 }
	 IEnumerator RotateFrontFaceccw(){
		 inFirst=true;
		 PutStuffInParent(GreenFace);
		 while(Mathf.Abs(totalRotation) < 90){
			totalRotation += 10;
			Parent.transform.RotateAround(green.transform.position,Vector3.forward,10);
			yield return 0;
		}
		if(Mathf.Abs(totalRotation)>=90){
			PutStuffInRubix(GreenFace);
			AllInOneUpdateCCW(GreenFace);
			AllInOneUpdateFace(GreenFace);
			totalRotation=0;
		}
		inFirst=false;
	 }
	  IEnumerator RotateBackFacecw(){
		  inFirst=true;
		  PutStuffInParent(YellowFace);
		   while(Mathf.Abs(totalRotation) < 90){
			totalRotation += 10;
			Parent.transform.RotateAround(yellow.transform.position,-1*Vector3.forward,10);
			yield return 0;
		}
		if(Mathf.Abs(totalRotation)>=90){
			PutStuffInRubix(YellowFace);
			AllInOneUpdateCW(YellowFace);
			AllInOneUpdateFace(YellowFace);
			totalRotation=0;
		}
		inFirst=false;
	 }
	 IEnumerator RotateBackFaceccw(){
		 inFirst=true;
		 PutStuffInParent(YellowFace);
		 while(Mathf.Abs(totalRotation) < 90){
			totalRotation += 10;
			Parent.transform.RotateAround(yellow.transform.position,Vector3.forward,10);
			yield return 0;
		}
		if(Mathf.Abs(totalRotation)>=90){
			PutStuffInRubix(YellowFace);
			AllInOneUpdateCCW(YellowFace);
			AllInOneUpdateFace(YellowFace);
			totalRotation=0;
		}
		inFirst=false;
	 }
	 
	IEnumerator Undo(){
		 if(Moves.Count>0){
			 UndoButton.GetComponent<Button>().interactable = false;
			 if(Moves[Moves.Count-1] == "UCW"){
				StartCoroutine(RotateUpperFaceccw());
				while(inFirst)       
					 yield return new WaitForSeconds(0.1f);
			 }
			 else if(Moves[Moves.Count-1] =="UCCW"){
				 StartCoroutine(RotateUpperFacecw());
				 while(inFirst)       
					 yield return new WaitForSeconds(0.1f);
			 }
			 else if(Moves[Moves.Count-1] =="DCW"){
				 StartCoroutine(RotateDownFaceccw());
				 while(inFirst)       
					 yield return new WaitForSeconds(0.1f);
			 }
			 else if(Moves[Moves.Count-1] =="DCCW"){
				  StartCoroutine(RotateDownFacecw());
				  while(inFirst)       
					 yield return new WaitForSeconds(0.1f);
			 }
			 else if(Moves[Moves.Count-1] =="RCW"){
				 StartCoroutine(RotateRightFaceccw());
				 while(inFirst)       
					 yield return new WaitForSeconds(0.1f);
			 }
			 else if(Moves[Moves.Count-1] =="RCCW"){
				 StartCoroutine(RotateRightFacecw());
				 while(inFirst)       
					 yield return new WaitForSeconds(0.1f);
			 }
			 else if(Moves[Moves.Count-1] =="LCW"){
				StartCoroutine(RotateLeftFaceccw());
				while(inFirst)       
					 yield return new WaitForSeconds(0.1f);
			 }
			 else if(Moves[Moves.Count-1] =="LCCW"){
				 StartCoroutine(RotateLeftFacecw());
				 while(inFirst)       
					 yield return new WaitForSeconds(0.1f);
			 }
			 else if(Moves[Moves.Count-1] =="BCW"){
				StartCoroutine(RotateBackFaceccw());
				while(inFirst)       
					 yield return new WaitForSeconds(0.1f);
			 }
			 else if(Moves[Moves.Count-1] =="BCCW"){
				StartCoroutine(RotateBackFacecw());
				while(inFirst)       
					 yield return new WaitForSeconds(0.1f);
			 }
			 else if(Moves[Moves.Count-1] =="FCW"){
				 StartCoroutine(RotateFrontFaceccw());
				 while(inFirst)       
					 yield return new WaitForSeconds(0.1f);
			 }
			 else if(Moves[Moves.Count-1] =="FCCW"){
				 StartCoroutine(RotateFrontFacecw());
				 while(inFirst)       
					 yield return new WaitForSeconds(0.1f);
			 }
			 Moves.RemoveAt(Moves.Count-1);
			 NoOfSteps--;
			 steps.transform.GetComponent<Text>().text=NoOfSteps.ToString();
		 }
		  UndoButton.GetComponent<Button>().interactable = true;
	 }
	
	public void UndoBut(){
		if(!OptimalSolution.paused){
			StartCoroutine(Undo());
		}
	}
	void Start (){
		PleaseWait=GameObject.Find("PleaseWait");
		TooLong=GameObject.Find("TooLong");
		PleaseWait.SetActive(false);
		TooLong.SetActive(false);
		UndoButton=GameObject.Find("tarajo3");
		 GreenFaceZ=GameObject.Find("Line084");
		 BlueFaceZ=GameObject.Find("Line026");
		 OrangeFaceZ=GameObject.Find("Line128");
		 YellowFaceZ=GameObject.Find("Line086");
		 steps=GameObject.Find("steps");
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
	void AllInOneUpdateCW(string []x){
		if(x==DownFace){
			string[] NewString=new string[8];
			for(int i=7;i>=2;i--)
				NewString[i-2]=DownFace[i];
			NewString[6]=DownFace[0];
			NewString[7]=DownFace[1];
			for(int i=0;i<8;i++)
				DownFace[i]=NewString[i];
		}
		else if(x==UpperFace){
			string[] NewString=new string[8];
			for(int i=0;i<8;i++)
				NewString[(i+2)%8]=UpperFace[i];
			for(int i=0;i<8;i++)
				UpperFace[i]=NewString[i];
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
		else if(x==GreenFace){
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
			
	}
	void AllInOneUpdateCCW(string []x){
		if(x==DownFace){
			string[] NewString=new string[8];
			for(int i=0;i<8;i++)
				NewString[(i+2)%8]=DownFace[i];
			for(int i=0;i<8;i++)
				DownFace[i]=NewString[i];
		}
		else if(x==UpperFace){
			string[] NewString=new string[8];
			for(int i=7;i>=2;i--)
				NewString[i-2]=UpperFace[i];
			NewString[6]=UpperFace[0];
			NewString[7]=UpperFace[1];
			for(int i=0;i<8;i++)
				UpperFace[i]=NewString[i];
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
		else if(x==GreenFace){
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
	}
	void AllInOneUpdateFace(string []x){
		if(x==DownFace){
			k=6;
		for(int i=0;i<3;i++)
			GreenFace[k++]=DownFace[i];
		k=6;
		for(int i=2;i<5;i++)
			OrangeFace[k++]=DownFace[i];
		k=6;
		for(int i=4;i<7;i++)
			YellowFace[k++]=DownFace[i];		
		k=6;
		for(int i=6;i<9;i++)
			BlueFace[k++]=DownFace[i%8];
		}
		else if(x==UpperFace){
			k=0;
		for(int i=0;i<3;i++)
			GreenFace[k++]=UpperFace[i];
		k=0;
		for(int i=2;i<5;i++)
			OrangeFace[k++]=UpperFace[i];
		k=0;
		for(int i=4;i<7;i++)
			YellowFace[k++]=UpperFace[i];		
		k=0;
		for(int i=6;i<9;i++)
			BlueFace[k++]=UpperFace[i%8];
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
		else if(x==GreenFace){
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
	 
	IEnumerator Scramble(){
		StartCoroutine(RotateUpperFacecw());
		while(inFirst)       
			yield return new WaitForSeconds(0.01f);
		StartCoroutine(RotateDownFacecw());
		while(inFirst)       
			yield return new WaitForSeconds(0.01f);
		StartCoroutine(RotateLeftFacecw());
		while(inFirst)       
			yield return new WaitForSeconds(0.01f);
		StartCoroutine(RotateRightFacecw());
		while(inFirst)       
			yield return new WaitForSeconds(0.01f);
		StartCoroutine(RotateFrontFacecw());
		while(inFirst)       
			yield return new WaitForSeconds(0.01f);
	} 
	 
	 public void ScrambleButton(){
		 if(!OptimalSolution.paused){
			 StartCoroutine(Scramble());
		 }
	 }
	 
	 
	void FixedUpdate(){ 
	if(!OptimalSolution.paused){
		if(Input.GetMouseButtonDown(0)){
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(ray, out rayHit)){
				lastClicked = rayHit.collider.gameObject;
				if(lastClicked==null )
					return;
			}
			firstPressPos = new Vector2(Input.mousePosition.x,Input.mousePosition.y);
		}
		if(Input.GetMouseButtonUp(0)){
			if(lastClicked==null )
					return;
			secondPressPos = new Vector2(Input.mousePosition.x,Input.mousePosition.y);
			currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
			currentSwipe.Normalize();
        if( currentSwipe.y > 0 && currentSwipe.x > -0.7f && currentSwipe.x < 0.7f){//UP
			if(lastClicked.transform.parent.name==GreenFace[6] && (int)lastClicked.transform.position.z==(int)GreenFaceZ.transform.position.z){
				Moves.Add("RCW");
				StartCoroutine(RotateRightFacecw());
				NoOfSteps++;
				steps.transform.GetComponent<Text>().text=NoOfSteps.ToString();
			}
			if(lastClicked.transform.parent.name==GreenFace[8] && (int)lastClicked.transform.position.z==(int)GreenFaceZ.transform.position.z){
				Moves.Add("LCCW");
				StartCoroutine(RotateLeftFaceccw());
				NoOfSteps++;
				steps.transform.GetComponent<Text>().text=NoOfSteps.ToString();
			}
			if(lastClicked.transform.parent.name==BlueFace[6] && (int)lastClicked.transform.position.x==(int)BlueFaceZ.transform.position.x){
				Moves.Add("BCCW");
				StartCoroutine(RotateBackFaceccw());
				NoOfSteps++;
				steps.transform.GetComponent<Text>().text=NoOfSteps.ToString();
			}
			if(lastClicked.transform.parent.name==BlueFace[8] && (int)lastClicked.transform.position.x==(int)BlueFaceZ.transform.position.x){
				Moves.Add("FCCW");
				StartCoroutine(RotateFrontFaceccw());
				NoOfSteps++;
				steps.transform.GetComponent<Text>().text=NoOfSteps.ToString();
			}
			if(lastClicked.transform.parent.name==OrangeFace[6] && (int)lastClicked.transform.position.x==(int)OrangeFaceZ.transform.position.x){
				Moves.Add("FCW");
				StartCoroutine(RotateFrontFacecw());
				NoOfSteps++;
				steps.transform.GetComponent<Text>().text=NoOfSteps.ToString();
			}
			if(lastClicked.transform.parent.name==OrangeFace[8] && (int)lastClicked.transform.position.x==(int)OrangeFaceZ.transform.position.x){
				Moves.Add("BCW");
				StartCoroutine(RotateBackFacecw());
				NoOfSteps++;
				steps.transform.GetComponent<Text>().text=NoOfSteps.ToString();
			}
			if(lastClicked.transform.parent.name==YellowFace[6] && (int)lastClicked.transform.position.z==(int)YellowFaceZ.transform.position.z){
				Moves.Add("LCW");
				StartCoroutine(RotateLeftFacecw());
				NoOfSteps++;
				steps.transform.GetComponent<Text>().text=NoOfSteps.ToString();
			}
			if(lastClicked.transform.parent.name==YellowFace[8] && (int)lastClicked.transform.position.z==(int)YellowFaceZ.transform.position.z){
				Moves.Add("RCCW");
				StartCoroutine(RotateRightFaceccw());
				NoOfSteps++;
				steps.transform.GetComponent<Text>().text=NoOfSteps.ToString();
			}
			
            print("up swipe");
        }
        if(currentSwipe.y < 0 && currentSwipe.x > -0.7f && currentSwipe.x < 0.7f){//DownSwipe
			if(lastClicked.transform.parent.name==GreenFace[0] && (int)lastClicked.transform.position.z==(int)GreenFaceZ.transform.position.z){
				Moves.Add("RCCW");
				StartCoroutine(RotateRightFaceccw());
				NoOfSteps++;
				steps.transform.GetComponent<Text>().text=NoOfSteps.ToString();
			}
			else if(lastClicked.transform.parent.name==GreenFace[2] && (int)lastClicked.transform.position.z==(int)GreenFaceZ.transform.position.z){
				Moves.Add("LCW");
				StartCoroutine(RotateLeftFacecw());
				NoOfSteps++;
				steps.transform.GetComponent<Text>().text=NoOfSteps.ToString();
			}
			if(lastClicked.transform.parent.name==BlueFace[0] && (int)lastClicked.transform.position.x==(int)BlueFaceZ.transform.position.x){
				Moves.Add("BCW");
				StartCoroutine(RotateBackFacecw());
				NoOfSteps++;
				steps.transform.GetComponent<Text>().text=NoOfSteps.ToString();
			}
			if(lastClicked.transform.parent.name==BlueFace[2] && (int)lastClicked.transform.position.x==(int)BlueFaceZ.transform.position.x){
				Moves.Add("FCW");
				StartCoroutine(RotateFrontFacecw());
				NoOfSteps++;
				steps.transform.GetComponent<Text>().text=NoOfSteps.ToString();
			}
			if(lastClicked.transform.parent.name==OrangeFace[0] && (int)lastClicked.transform.position.x==(int)OrangeFaceZ.transform.position.x){
				Moves.Add("FCCW");
				StartCoroutine(RotateFrontFaceccw());
				NoOfSteps++;
				steps.transform.GetComponent<Text>().text=NoOfSteps.ToString();
			}
			if(lastClicked.transform.parent.name==OrangeFace[2] && (int)lastClicked.transform.position.x==(int)OrangeFaceZ.transform.position.x){
				Moves.Add("BCCW");
				StartCoroutine(RotateBackFaceccw());
				NoOfSteps++;
				steps.transform.GetComponent<Text>().text=NoOfSteps.ToString();
			}
			if(lastClicked.transform.parent.name==YellowFace[0] && (int)lastClicked.transform.position.z==(int)YellowFaceZ.transform.position.z){
				Moves.Add("LCCW");
				StartCoroutine(RotateLeftFaceccw());
				NoOfSteps++;
				steps.transform.GetComponent<Text>().text=NoOfSteps.ToString();
			}
			if(lastClicked.transform.parent.name==YellowFace[2] && (int)lastClicked.transform.position.z==(int)YellowFaceZ.transform.position.z){
				Moves.Add("FCW");
				StartCoroutine(RotateFrontFacecw());
				NoOfSteps++;
				steps.transform.GetComponent<Text>().text=NoOfSteps.ToString();
			}
            print("down swipe");
        }
        if(currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f){ //leftSwipe
			if(Mathf.Abs(((int)Center.transform.position.y+(int)lastClicked.GetComponent<Collider>().bounds.size.y)-((int)lastClicked.transform.parent.position.y)) >=0
			&& Mathf.Abs(((int)Center.transform.position.y+(int)lastClicked.GetComponent<Collider>().bounds.size.y)-((int)lastClicked.transform.parent.position.y)) <=15){ // up face clock wise
				Moves.Add("UCW");
				StartCoroutine(RotateUpperFacecw());
				NoOfSteps++;
				steps.transform.GetComponent<Text>().text=NoOfSteps.ToString();
			}
			if(Mathf.Abs(((int)Center.transform.position.y-(int)lastClicked.GetComponent<Collider>().bounds.size.y)-((int)lastClicked.transform.parent.position.y)) >=0
			&& Mathf.Abs(((int)Center.transform.position.y-(int)lastClicked.GetComponent<Collider>().bounds.size.y)-((int)lastClicked.transform.parent.position.y)) <=15){ // down face clock wise
				StartCoroutine(RotateDownFaceccw());
				Moves.Add("DCCW");
				NoOfSteps++;
				steps.transform.GetComponent<Text>().text=NoOfSteps.ToString();
			}
        }
        if(currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f){ //rightSwipe
			 if(Mathf.Abs(((int)Center.transform.position.y+(int)lastClicked.GetComponent<Collider>().bounds.size.y)-((int)lastClicked.transform.parent.position.y)) >=0
			&& Mathf.Abs(((int)Center.transform.position.y+(int)lastClicked.GetComponent<Collider>().bounds.size.y)-((int)lastClicked.transform.parent.position.y)) <=15){ // up face counter clock wise
				StartCoroutine(RotateUpperFaceccw());
				NoOfSteps++;
				Moves.Add("UCCW");
				steps.transform.GetComponent<Text>().text=NoOfSteps.ToString();
			}
			
			if(Mathf.Abs(((int)Center.transform.position.y-(int)lastClicked.GetComponent<Collider>().bounds.size.y)-((int)lastClicked.transform.parent.position.y)) >=0
			&& Mathf.Abs(((int)Center.transform.position.y-(int)lastClicked.GetComponent<Collider>().bounds.size.y)-((int)lastClicked.transform.parent.position.y)) <=15){ // down face counter clock wise
				StartCoroutine(RotateDownFacecw());
				NoOfSteps++;
				Moves.Add("DCW");
				steps.transform.GetComponent<Text>().text=NoOfSteps.ToString();
			}
        }
	}
}

	}
}


