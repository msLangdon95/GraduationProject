using UnityEngine;
using System.Collections;
using UnityEngine.UI;    
using System;
using System.Linq;  
using System.IO;
using System.Text;

public class ManualInputSceneScripts : MonoBehaviour {
	GameObject x;
	Color Orange=new Color(1,0.27058823529f,0,1);
	string path = @"D:\ myColors3.txt";
	Color a;
	void start (){
		if (File.Exists(path));
		File.Delete(path);
		
	}
	String GetColor(Color G){
		Color color = G;
		
		if (color == Color.green)
			return "Green";
		if (color == Color.blue)
			return "Blue";
		if (color == Color.red)
			return "Red";
		if (color == Color.yellow)
			return "Yellow";
		if (color == Color.white)
			return "White";
		if (color == Orange)
			return "Orange";
		else 
			return "Gray" ;
	}
	
	public void ReClear(){ //clear button
		for(int i=0;i<48;i++){
			x=GameObject.Find(Globals.EdgesAndCorners[i]);
			x.GetComponent<Renderer>().material.color =Color.gray;
		}
		for(int i=0;i<6;i++){
			Globals.ColorsArray[i].ColorCounter=0;
			Globals.ColorsArray[i].GO.GetComponentInChildren<Text>().text="0";
		}
	}
	public void VerifyAndGo(){ // next scene button
		/*for(int i=0;i<6;i++){
			if(Globals.ColorsArray[i].ColorCounter!= 8){ //not all cubies are fully colored
				Globals.VerifyPanel.SetActive(true);
				return;
			}
		}*/
		//Accepted, store all colors

			using (StreamWriter sw = File.CreateText(path)) {
				for(int i=0;i<48;i++){
					
					x=GameObject.Find(Globals.EdgesAndCorners[i]);
					Globals.CurrentCubeColors[i]=x.GetComponent<Renderer>().material.color;
					a=x.GetComponent<Renderer>().material.color;
					a = x.GetComponent<Renderer> ().material.color;
					
					
					String w = GetColor (a);
					//sw.WriteLine("This is the text to store Cube's colors");
					sw.Write(w+",");
				}	
			sw.Close();
				
			}

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