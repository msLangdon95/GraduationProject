﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;    
using System;
using System.Linq;  
using System.IO;
using System.Text;

public class SaveBeforeExit : MonoBehaviour {
	GameObject x;
	Color Orange=new Color(1,0.27058823529f,0,1);
	string path = @"C:\Users\Dania\AppData\LocalLow\Lolo\test\ myCubeColor.txt";
	GameObject w;
	
	Color a;
	int i=0;
	
	
	void Start (){
		if (File.Exists (path))
			File.Delete (path);
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
	
	
	public void saveMe () {
		using (StreamWriter sw = File.CreateText(path)) {
			for( i=0;i<48;i++){
				x=GameObject.Find(Globals.EdgesAndCorners[i]);
				a=x.GetComponent<Renderer>().material.color;
				String w = GetColor (a);
				sw.Write(w);
				if ( i!=47){
					sw.Write(",");
				}
			}	
			
			sw.Close();
		}
		Application.Quit ();
		
	}


	
}