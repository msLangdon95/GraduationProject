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
	string path = @"C:\Users\Dania\AppData\LocalLow\Lolo\test\ myCubeColor.txt";
	GameObject w;
	int i=0;
	Color Orange = new Color(1,0.27058823529f,0,1);
	
	void Start () {
		Globals.LoadingMessagePanel=GameObject.Find("LoadingMessagePanel");
		Globals.LoadingMessagePanel.SetActive(false);
		
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
		return;
	}
	public void LoadMe(){
		if (!File.Exists (path)) {
			Globals.LoadingMessagePanel.SetActive(true);
			return;
		}
		else if (File.Exists (path))
			Application.LoadLevel("rubik");
		using (StreamReader sr= new StreamReader (path)){
			while( (a=sr.ReadLine())!= null){
				words = a.Split(',');
			}
			foreach ( string word in words ) {
				w=GameObject.Find(Globals.EdgesAndCorners[i]); 
				//	w.GetComponent<Renderer>().material.color=getColor(word); 
				
				i++;
				print (word);
			}
		}	
	}
	

}














