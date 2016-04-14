using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Timers;
using System.Text.RegularExpressions;

public class Loading : MonoBehaviour {
	public	string a;
	public string[]words;
	string path = (System.Environment.CurrentDirectory )+Path.DirectorySeparatorChar +"myCubeColor.txt";
	GameObject w;
	int i,j;
	string[]m;
	string word;
	Color ORANGE = new Color(1,0.27058823529f,0,1);
	
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
			//w = GameObject.Find (Globals.EdgesAndCorners [i]); 
			m[i]=word;
			i++;
		}
	}


	
	public Color getColor(string c){
		if (c == "RED")
			return Color.red;
		if (c == "BLUE")
			return Color.blue;
		if (c == "YELLOW")
			return Color.yellow;
		if (c == "GREEN")
			return Color.green;
		if (c == "WHITE")
			return Color.white;
		if (c == "ORANGE")
			return ORANGE;
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
			//w=GameObject.Find(Globals.EdgesAndCorners[i]); 
		for ( j=0 ; j<48 ; j++){
			print (m[j]);
			w=GameObject.Find(Globals.EdgesAndCorners[j]); 
			w.GetComponent<Renderer>().material.color=getColor(m[j]); 
			
			
		}




}
}













