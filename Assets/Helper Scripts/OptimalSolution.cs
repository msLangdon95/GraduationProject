using UnityEngine;
using System.Collections;
using UnityEngine.UI;    
using System;
using System.Linq;  
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;
public class OptimalSolution : MonoBehaviour {
	public static int StepsOfSolution=0;
	Process myProcess;
	string InputToAlgo="";
	int d1,d2,d3,result;
	string path=(System.Environment.CurrentDirectory )+Path.DirectorySeparatorChar+"input.txt";
	public static List<Color> GoToSolve=new List<Color>();
	float timer = 0f;
	float fiveMinutes = 300; //300 seconds = 5minutes
	bool badExit = false;
	void blahleasty(GameObject x,string number){
		if(number=="2"){
			if(x.transform.GetChild(0).position.y > x.transform.GetChild(1).position.y){
				InputToAlgo+=Saving.GetColor(x.transform.GetChild(1).GetComponent<Renderer>().material.color);
				GoToSolve.Add(x.transform.GetChild(1).GetComponent<Renderer>().material.color);
				InputToAlgo+=" ";
			}
			else{
				InputToAlgo+=Saving.GetColor(x.transform.GetChild(0).GetComponent<Renderer>().material.color);
				GoToSolve.Add(x.transform.GetChild(0).GetComponent<Renderer>().material.color);
				InputToAlgo+=" ";
			}
		}
		else{
			d1=d2=d3=0;
			d1=(int)x.transform.GetChild(0).position.y;
			d2=(int)x.transform.GetChild(1).position.y;
			d3=(int)x.transform.GetChild(2).position.y;
			result=Mathf.Min(d1,d2,d3);
			if(result==d1){
				InputToAlgo+=Saving.GetColor(x.transform.GetChild(0).GetComponent<Renderer>().material.color);
				GoToSolve.Add(x.transform.GetChild(0).GetComponent<Renderer>().material.color);
				InputToAlgo+=" ";
			}
			else if(result==d2){
				InputToAlgo+=Saving.GetColor(x.transform.GetChild(1).GetComponent<Renderer>().material.color);
				GoToSolve.Add(x.transform.GetChild(1).GetComponent<Renderer>().material.color);
				InputToAlgo+=" ";
			}
			else if(result==d3){
				InputToAlgo+=Saving.GetColor(x.transform.GetChild(2).GetComponent<Renderer>().material.color);
				GoToSolve.Add(x.transform.GetChild(2).GetComponent<Renderer>().material.color);
				InputToAlgo+=" ";
			}
		}
	}
	void blah(GameObject x,string number){
		if(number=="2"){
			if(x.transform.GetChild(0).position.y < x.transform.GetChild(1).position.y){
				InputToAlgo+=Saving.GetColor(x.transform.GetChild(1).GetComponent<Renderer>().material.color);
				GoToSolve.Add(x.transform.GetChild(1).GetComponent<Renderer>().material.color);
				InputToAlgo+=" ";
			}
			else{
				InputToAlgo+=Saving.GetColor(x.transform.GetChild(0).GetComponent<Renderer>().material.color);
				GoToSolve.Add(x.transform.GetChild(0).GetComponent<Renderer>().material.color);
				InputToAlgo+=" ";
			}
		}
		else{
			d1=d2=d3=0;
			d1=(int)x.transform.GetChild(0).position.y;
			d2=(int)x.transform.GetChild(1).position.y;
			d3=(int)x.transform.GetChild(2).position.y;
			result=Mathf.Max(d1,d2,d3);
			if(result==d1){
				InputToAlgo+=Saving.GetColor(x.transform.GetChild(0).GetComponent<Renderer>().material.color);
				GoToSolve.Add(x.transform.GetChild(0).GetComponent<Renderer>().material.color);
				InputToAlgo+=" ";
			}
			else if(result==d2){
				InputToAlgo+=Saving.GetColor(x.transform.GetChild(1).GetComponent<Renderer>().material.color);
				GoToSolve.Add(x.transform.GetChild(1).GetComponent<Renderer>().material.color);
				InputToAlgo+=" ";
			}
			else if(result==d3){
				InputToAlgo+=Saving.GetColor(x.transform.GetChild(2).GetComponent<Renderer>().material.color);
				GoToSolve.Add(x.transform.GetChild(2).GetComponent<Renderer>().material.color);
				InputToAlgo+=" ";
			}
		}
	}
	void blahblah(GameObject x,string number){
		if(number=="2"){
			if(x.transform.GetChild(0).position.z > x.transform.GetChild(1).position.z){
				InputToAlgo+=Saving.GetColor(x.transform.GetChild(1).GetComponent<Renderer>().material.color);
				GoToSolve.Add(x.transform.GetChild(1).GetComponent<Renderer>().material.color);
				InputToAlgo+=" ";
			}
			else{
				InputToAlgo+=Saving.GetColor(x.transform.GetChild(0).GetComponent<Renderer>().material.color);
				GoToSolve.Add(x.transform.GetChild(0).GetComponent<Renderer>().material.color);
				InputToAlgo+=" ";
			}
		}
		else{
			d1=d2=d3=0;
			d1=(int)x.transform.GetChild(0).position.z;
			d2=(int)x.transform.GetChild(1).position.z;
			d3=(int)x.transform.GetChild(2).position.z;
			result=Mathf.Min(d1,d2,d3);
			if(result==d1){
				InputToAlgo+=Saving.GetColor(x.transform.GetChild(0).GetComponent<Renderer>().material.color);
				GoToSolve.Add(x.transform.GetChild(0).GetComponent<Renderer>().material.color);
				InputToAlgo+=" ";
			}
			else if(result==d2){
				InputToAlgo+=Saving.GetColor(x.transform.GetChild(1).GetComponent<Renderer>().material.color);
				GoToSolve.Add(x.transform.GetChild(1).GetComponent<Renderer>().material.color);
				InputToAlgo+=" ";
			}
			else if(result==d3){
				InputToAlgo+=Saving.GetColor(x.transform.GetChild(2).GetComponent<Renderer>().material.color);
				GoToSolve.Add(x.transform.GetChild(2).GetComponent<Renderer>().material.color);
				InputToAlgo+=" ";
			}
		}
	}
	void blahbigz(GameObject x,string number){
		if(number=="2"){
			if(x.transform.GetChild(0).position.z < x.transform.GetChild(1).position.z){
				InputToAlgo+=Saving.GetColor(x.transform.GetChild(1).GetComponent<Renderer>().material.color);
				GoToSolve.Add(x.transform.GetChild(1).GetComponent<Renderer>().material.color);
			}
			
			else{
				InputToAlgo+=Saving.GetColor(x.transform.GetChild(0).GetComponent<Renderer>().material.color);
				GoToSolve.Add(x.transform.GetChild(0).GetComponent<Renderer>().material.color);
			}
			InputToAlgo+=" ";
		}
		else{
			d1=d2=d3=0;
			d1=(int)x.transform.GetChild(0).position.z;
			d2=(int)x.transform.GetChild(1).position.z;
			d3=(int)x.transform.GetChild(2).position.z;
			result=Mathf.Max(d1,d2,d3);
			if(result==d1){
				InputToAlgo+=Saving.GetColor(x.transform.GetChild(0).GetComponent<Renderer>().material.color);
				GoToSolve.Add(x.transform.GetChild(0).GetComponent<Renderer>().material.color);
			}
			else if(result==d2){
				InputToAlgo+=Saving.GetColor(x.transform.GetChild(1).GetComponent<Renderer>().material.color);
				GoToSolve.Add(x.transform.GetChild(1).GetComponent<Renderer>().material.color);
			}
			else if(result==d3){
				InputToAlgo+=Saving.GetColor(x.transform.GetChild(2).GetComponent<Renderer>().material.color);
				GoToSolve.Add(x.transform.GetChild(2).GetComponent<Renderer>().material.color);
			}
			InputToAlgo+=" ";
		}
	}
	void blahbigx(GameObject x,string number){
		if(number=="2"){
			if(x.transform.GetChild(0).position.x < x.transform.GetChild(1).position.x){
				InputToAlgo+=Saving.GetColor(x.transform.GetChild(1).GetComponent<Renderer>().material.color);
				GoToSolve.Add(x.transform.GetChild(1).GetComponent<Renderer>().material.color);
			}
			else{
				InputToAlgo+=Saving.GetColor(x.transform.GetChild(0).GetComponent<Renderer>().material.color);
				GoToSolve.Add(x.transform.GetChild(0).GetComponent<Renderer>().material.color);
			}
			InputToAlgo+=" ";
		}
		else{
			d1=d2=d3=0;
			d1=(int)x.transform.GetChild(0).position.x;
			d2=(int)x.transform.GetChild(1).position.x;
			d3=(int)x.transform.GetChild(2).position.x;
			result=Mathf.Max(d1,d2,d3);
			if(result==d1){
				InputToAlgo+=Saving.GetColor(x.transform.GetChild(0).GetComponent<Renderer>().material.color);
				GoToSolve.Add(x.transform.GetChild(0).GetComponent<Renderer>().material.color);
			}
			else if(result==d2){
				InputToAlgo+=Saving.GetColor(x.transform.GetChild(1).GetComponent<Renderer>().material.color);
				GoToSolve.Add(x.transform.GetChild(1).GetComponent<Renderer>().material.color);
			}
			else if(result==d3){
				InputToAlgo+=Saving.GetColor(x.transform.GetChild(2).GetComponent<Renderer>().material.color);
				GoToSolve.Add(x.transform.GetChild(2).GetComponent<Renderer>().material.color);
			}
			InputToAlgo+=" ";
		}
	}
	void blahsmallx(GameObject x,string number){
		if(number=="2"){
			if(x.transform.GetChild(0).position.x > x.transform.GetChild(1).position.x){
				InputToAlgo+=Saving.GetColor(x.transform.GetChild(1).GetComponent<Renderer>().material.color);
				GoToSolve.Add(x.transform.GetChild(1).GetComponent<Renderer>().material.color);
			}
			else{
				InputToAlgo+=Saving.GetColor(x.transform.GetChild(0).GetComponent<Renderer>().material.color);
				GoToSolve.Add(x.transform.GetChild(0).GetComponent<Renderer>().material.color);
			}	
			InputToAlgo+=" ";
		}
		else{
			d1=d2=d3=0;
			d1=(int)x.transform.GetChild(0).position.x;
			d2=(int)x.transform.GetChild(1).position.x;
			d3=(int)x.transform.GetChild(2).position.x;
			result=Mathf.Min(d1,d2,d3);
			if(result==d1){
				InputToAlgo+=Saving.GetColor(x.transform.GetChild(0).GetComponent<Renderer>().material.color);
				GoToSolve.Add(x.transform.GetChild(0).GetComponent<Renderer>().material.color);
			}
			else if(result==d2){
				InputToAlgo+=Saving.GetColor(x.transform.GetChild(1).GetComponent<Renderer>().material.color);
				GoToSolve.Add(x.transform.GetChild(1).GetComponent<Renderer>().material.color);
			}
			else if(result==d3){
				InputToAlgo+=Saving.GetColor(x.transform.GetChild(2).GetComponent<Renderer>().material.color);
				GoToSolve.Add(x.transform.GetChild(2).GetComponent<Renderer>().material.color);
			}
			InputToAlgo+=" ";
		}
	}
	void ReadBlueFace(){
		blahbigx(GameObject.Find(RubikScene.BlueFace[1]),GameObject.Find(RubikScene.BlueFace[1]).tag);
		blahbigx(GameObject.Find(RubikScene.BlueFace[0]),GameObject.Find(RubikScene.BlueFace[0]).tag);
		blahbigx(GameObject.Find(RubikScene.BlueFace[3]),GameObject.Find(RubikScene.BlueFace[3]).tag);
		blahbigx(GameObject.Find(RubikScene.BlueFace[6]),GameObject.Find(RubikScene.BlueFace[6]).tag);
		blahbigx(GameObject.Find(RubikScene.BlueFace[7]),GameObject.Find(RubikScene.BlueFace[7]).tag);
		blahbigx(GameObject.Find(RubikScene.BlueFace[8]),GameObject.Find(RubikScene.BlueFace[8]).tag);
		blahbigx(GameObject.Find(RubikScene.BlueFace[5]),GameObject.Find(RubikScene.BlueFace[5]).tag);
		blahbigx(GameObject.Find(RubikScene.BlueFace[2]),GameObject.Find(RubikScene.BlueFace[2]).tag);
	}
	void ReadOrangeFace(){
		blahsmallx(GameObject.Find(RubikScene.OrangeFace[1]),GameObject.Find(RubikScene.OrangeFace[1]).tag);
		blahsmallx(GameObject.Find(RubikScene.OrangeFace[0]),GameObject.Find(RubikScene.OrangeFace[0]).tag);
		blahsmallx(GameObject.Find(RubikScene.OrangeFace[3]),GameObject.Find(RubikScene.OrangeFace[3]).tag);
		blahsmallx(GameObject.Find(RubikScene.OrangeFace[6]),GameObject.Find(RubikScene.OrangeFace[6]).tag);
		blahsmallx(GameObject.Find(RubikScene.OrangeFace[7]),GameObject.Find(RubikScene.OrangeFace[7]).tag);
		blahsmallx(GameObject.Find(RubikScene.OrangeFace[8]),GameObject.Find(RubikScene.OrangeFace[8]).tag);
		blahsmallx(GameObject.Find(RubikScene.OrangeFace[5]),GameObject.Find(RubikScene.OrangeFace[5]).tag);
		blahsmallx(GameObject.Find(RubikScene.OrangeFace[2]),GameObject.Find(RubikScene.OrangeFace[2]).tag);
	}
	void ReadWhiteFace(){
		for(int i=1;i>=0;i--){
			blahleasty(GameObject.Find(RubikScene.DownFace[i]),GameObject.Find(RubikScene.DownFace[i]).tag);
		}
		for(int i=7;i>=2;i--){
			blahleasty(GameObject.Find(RubikScene.DownFace[i]),GameObject.Find(RubikScene.DownFace[i]).tag);
		}
	}
	void ReadRedFace(){
		for(int i=5;i<8;i++){
			blah(GameObject.Find(RubikScene.UpperFace[i]),GameObject.Find(RubikScene.UpperFace[i]).tag);
		}
		for(int i=0;i<5;i++){
			blah(GameObject.Find(RubikScene.UpperFace[i]),GameObject.Find(RubikScene.UpperFace[i]).tag);
		}
	}
	void ReadGreenFace(){
		// 1 0 3 6 7 8 5 2
		blahblah(GameObject.Find(RubikScene.GreenFace[1]),GameObject.Find(RubikScene.GreenFace[1]).tag);
		blahblah(GameObject.Find(RubikScene.GreenFace[0]),GameObject.Find(RubikScene.GreenFace[0]).tag);
		blahblah(GameObject.Find(RubikScene.GreenFace[3]),GameObject.Find(RubikScene.GreenFace[3]).tag);
		blahblah(GameObject.Find(RubikScene.GreenFace[6]),GameObject.Find(RubikScene.GreenFace[6]).tag);
		blahblah(GameObject.Find(RubikScene.GreenFace[7]),GameObject.Find(RubikScene.GreenFace[7]).tag);
		blahblah(GameObject.Find(RubikScene.GreenFace[8]),GameObject.Find(RubikScene.GreenFace[8]).tag);
		blahblah(GameObject.Find(RubikScene.GreenFace[5]),GameObject.Find(RubikScene.GreenFace[5]).tag);
		blahblah(GameObject.Find(RubikScene.GreenFace[2]),GameObject.Find(RubikScene.GreenFace[2]).tag);
	}
	void ReadYellowFace(){
		blahbigz(GameObject.Find(RubikScene.YellowFace[1]),GameObject.Find(RubikScene.YellowFace[1]).tag);
		blahbigz(GameObject.Find(RubikScene.YellowFace[0]),GameObject.Find(RubikScene.YellowFace[0]).tag);
		blahbigz(GameObject.Find(RubikScene.YellowFace[3]),GameObject.Find(RubikScene.YellowFace[3]).tag);
		blahbigz(GameObject.Find(RubikScene.YellowFace[6]),GameObject.Find(RubikScene.YellowFace[6]).tag);
		blahbigz(GameObject.Find(RubikScene.YellowFace[7]),GameObject.Find(RubikScene.YellowFace[7]).tag);
		blahbigz(GameObject.Find(RubikScene.YellowFace[8]),GameObject.Find(RubikScene.YellowFace[8]).tag);
		blahbigz(GameObject.Find(RubikScene.YellowFace[5]),GameObject.Find(RubikScene.YellowFace[5]).tag);
		blahbigz(GameObject.Find(RubikScene.YellowFace[2]),GameObject.Find(RubikScene.YellowFace[2]).tag);
	}
	public void onClickFindSol(){
		ReadRedFace();
		ReadGreenFace();
		ReadBlueFace();
		ReadYellowFace();
		ReadOrangeFace();
		ReadWhiteFace();
		if (File.Exists (path))
			File.Delete (path);
		System.IO.File.WriteAllText(path,InputToAlgo);		
		myProcess = new Process();
		myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
		myProcess.StartInfo.CreateNoWindow = true;
		myProcess.StartInfo.UseShellExecute = false;
		myProcess.StartInfo.RedirectStandardOutput = true;
		myProcess.StartInfo.FileName = (System.Environment.CurrentDirectory )+Path.DirectorySeparatorChar+"rubik3Sticker.ida2";
		myProcess.EnableRaisingEvents = true;
		myProcess.StartInfo.WorkingDirectory = (System.Environment.CurrentDirectory )+Path.DirectorySeparatorChar;
		myProcess.StartInfo.Arguments = "corner.bin edge1.bin edge2.bin";
		myProcess.OutputDataReceived += new DataReceivedEventHandler((sender, e) =>
		{
			if (!String.IsNullOrEmpty(e.Data)){
				timer = 0f;
				StepsOfSolution++;
				print(e.Data);
				solution.output.Add(e.Data);
			}
		});
		myProcess.Start();
		myProcess.BeginOutputReadLine();
		//myProcess.WaitForExit(1000 * 60 * 5); //waits for 5 minutes
		//Application.LoadLevel("solution");
	}
	void Update(){
		if (myProcess != null){
			if(timer>fiveMinutes){
				myProcess.Kill();
				myProcess.Close();
				badExit=true;
				return;
			}
			timer += Time.deltaTime;
			if (!myProcess.HasExited){
				//GameObject.Find("PleaseWait").SetActive(true);
				print("NOT YET");
			}
			else{
				if(badExit){
					print("TimeOut!");
				}else{
					Application.LoadLevel("solution");
				}
			}
		}
	}
}