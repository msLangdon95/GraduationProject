using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Timers;
using System.Text.RegularExpressions;

public class Loading : MonoBehaviour {
	//GameObject s=GameObject.Find("LoadingMessagePanel");
	public	string a;
	public string[]words;
	//string path = (Application.persistentDataPath )+"\myCubeColor.txt";
	string path = @"C:\Users\Dania\AppData\LocalLow\Lolo\test\myCubeColor.txt";
	GameObject w;
	int i,j;
	string[]m;
	string word;
	Color Orange = new Color(1,0.27058823529f,0,1);
	
	void Start () {
		 i=0;
		j = 0;
		m = new string[48];
		Globals.LoadingMessagePanel=GameObject.Find("LoadingMessagePanel");
		Globals.LoadingMessagePanel.SetActive(false);
		if (File.Exists (path))
		using (StreamReader sr= new StreamReader (path)){
			while( (a=sr.ReadLine())!= null){
				words = a.Split(' ');
			}
			sr.Close();
		}	
		foreach ( string word in words) {
			w = GameObject.Find (Globals.EdgesAndCorners [i]); 
			m[i]=word;
			i++;
		}
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

	public void okButton(){
		Globals.LoadingMessagePanel.SetActive(false);
	}

	public void LoadMe(){
		if (!File.Exists (path)) {
			Globals.LoadingMessagePanel.SetActive (true);
			return;
		}

		Application.LoadLevel("rubik");
		//foreach ( string word in words ) {
		//	w=GameObject.Find(Globals.EdgesAndCorners[i]); 
		for ( j=0 ; j<48 ; j++)
			w.GetComponent<Renderer>().material.color=getColor(m[i]); 
			
			print (m[j]);
		}




}













