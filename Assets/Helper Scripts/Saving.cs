using UnityEngine;
using System.Collections;
using UnityEngine.UI;    
using System;
using System.Linq;  
using System.IO;
using System.Text;

public class Saving : MonoBehaviour {
	GameObject x;
	Color ORANGE=new Color(1,0.27058823529f,0,1);
	string path = (System.Environment.CurrentDirectory )+Path.DirectorySeparatorChar +"myCubeColor.txt";
	GameObject w;
	
	Color a;
	int i=0;
	
	
	void Start (){
		Debug.Log (Application.persistentDataPath);
		if (File.Exists (path))
			File.Delete (path);
	}
	
	String GetColor(Color G){
		Color color = G;
		if (color == Color.green)
			return "GREEN";
		if (color == Color.blue)
			return "BLUE";
		if (color == Color.red)
			return "RED";
		if (color == Color.yellow)
			return "YELLOW";
		if (color == Color.white)
			return "WHITE";
		if (color == ORANGE)
			return "ORANGE";
		else 
			return "GRAY" ;
	}
	
	
	public void saveMe () {
		using (StreamWriter sw = File.CreateText(path)) {
			for( i=0;i<48;i++){
				x=GameObject.Find(Globals.EdgesAndCorners[i]);
				a=x.GetComponent<Renderer>().material.color;
				String w = GetColor (a);
				sw.Write(w);
				if ( i!=47){
					sw.Write(" ");
				}
			}	
			
			sw.Close();
		}
		
	}

}
