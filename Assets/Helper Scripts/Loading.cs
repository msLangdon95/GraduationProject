using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Timers;
using System.Text.RegularExpressions;

	public class Loading : MonoBehaviour {
	public string path = @"D:\ myColors3.txt";
	public	string a;
	public string[]words;
	GameObject w;
	int i=0;
	Color Orange = new Color(1,0.27058823529f,0,1);


	Color returnColor(string c){
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
			//	for(int i=0;i<48;i++){
			foreach ( string word in words ) {
					print (word);
				print (i);

      	//w=GameObject.Find(Globals.EdgesAndCorners[i]); 
		//w.GetComponent<Renderer>().material.color=returnColor(word); 
				i++;
			}

			
		
		}
			
		}

	
	}
	



		



		

		

		
		
		