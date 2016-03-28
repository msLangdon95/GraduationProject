using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Timers;
using System.Text.RegularExpressions;

public class Loading : MonoBehaviour {
	string path = @"D:\ myColor3.txt";
	public	string a;
	public string[]words;
	GameObject w;
	int i=0;
	Color Orange = new Color(1,0.27058823529f,0,1);
	
	void Start () {
		
	}
	
	public Color getColor(string c){
		if (c == "Red")
			return Color.red;
		if (c == "Blue")
			return Color.blue;
		if (c == "Yellow")
			return Color.yellow;
		if (c == "Green")
			return Color.green;
		if (c == "White")
			return Color.white;
		if (c == "Orange")
			return Orange;
		else 
			return Color.gray;
	}
	
	public void LoadMe(){
		Application.LoadLevel("rubik");
		
		using (StreamReader sr= new StreamReader (path)){
			while( (a=sr.ReadLine())!= null){
				words = a.Split(',');
			}
			foreach ( string word in words ) {
				w=GameObject.Find(Globals.EdgesAndCorners[i]); 
				w.GetComponent<Renderer>().material.color=getColor(word); 
				i++;
			}
		}	
	}
	
	public void onMouseDown(){
		LoadMe ();
	}
}














