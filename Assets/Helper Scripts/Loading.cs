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
	int i;
	public static string[]m;
	string word;
	void Start () {
		 i=0;
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

	public void okButton(){
		Globals.LoadingMessagePanel.SetActive(false);
	}

	public void LoadMe(){
		if (!File.Exists (path)) {
			Globals.LoadingMessagePanel.SetActive (true);
			return;
		}
		Globals.LoadFlag=true;
		Globals.ManualInputFlag=false;
		Globals.RandomGeneratedFlag=false;
		Application.LoadLevel("rubik");
	}
}













