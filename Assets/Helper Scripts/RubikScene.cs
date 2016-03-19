using UnityEngine;
using System.Collections;
using UnityEngine.UI;    
using System;
using System.Linq;  
using System.IO;
using System.Text;
  
public class RubikScene : MonoBehaviour {
	string [] UpperFace={"RED","Edge1","Edge3","Edge4","Edge12","Corner1","Corner2","Corner7","Corner8"};
	/*string[] one = {"WHITE","Edge7","Edge8","Edge9","Edge12","Corner1","Corner4","Corner6","Corner7"};
	string[] two = {"CENTER","ORANGE","RED","GREEN","BLUE","Edge1","Edge4","Edge6","Edge10"};
	string[] three = {"YELLOW","Edge2","Edge3","Edge5","Edge11","Corner2","Corner3","Corner5","Corner8"};
	string[] four = {"ORANGE","Edge6","Edge7","Edge10","Edge11","Corner3","Corner7","Corner4","Corner5"};
	string[] five = {"CENTER","Edge8","Edge9","Edge5","Edge2","WHITE","BLUE","GREEN","YELLOW","RED"};
	string[] six = {"RED","Edge1","Edge3","Edge4","Edge12","Corner1","Corner2","Corner7","Corner8"};
	string[] seven = {"CENTER","ORANGE","YELLOW","RED","WHITE","Edge3","Edge7","Edge11","Edge12"};
	string[] eight = {"Corner1","Corner2","Corner3","Corner4","Edge8","Edge6","Edge5","Edge4","GREEN"};
	string[] nine = {"BLUE","Edge1","Edge2","Edge9","Edge10","Corner5","Corner6","Corner7","Corner8"};*/
	public Vector3 p;
	Vector2 fp,lp;
	GameObject x,RubiksCube,Parent;
	string path = @"D:\ myColors3.txt";
	Color a;
	void Start(){
		if (File.Exists(path))
			File.Delete(path);
		RubiksCube=GameObject.Find("RubiksCube");
		Parent=GameObject.Find("Parent");
		/*for(int i=0;i<48;i++){
			x=GameObject.Find(Globals.EdgesAndCorners[i]);
			x.GetComponent<Renderer>().material.color=Globals.CurrentCubeColors[i];
		}*/
	}
	
	void Update(){
		if (Input.touchCount > 0){
			Touch touch = Input.touches[0];
			 if (touch.phase == TouchPhase.Began){
                fp = touch.position;
                lp = touch.position;
          }
		   if (touch.phase == TouchPhase.Moved ){
                lp = touch.position;
          }
		   if(touch.phase == TouchPhase.Ended){ 
                if((fp.x - lp.x) > 80) // left swipe
				{
					RotateUpper(Parent.transform,1);
					//player.Rotate(0,-90,0);
					//print("left");
				}
				else if((fp.x - lp.x) < -80) // right swipe
				{
					RotateUpper(Parent.transform,-1);
					//player.Rotate(0,90,0);
					//print("right");
				}
				else if((fp.y - lp.y) < -80 ) // up swipe
				{
				 print("up");
				}
			}
		}
	}
	
	
	public void RotateUpper(Transform T,int flag){
		for(int i=0;i<9;i++){
			x=GameObject.Find(UpperFace[i]);
			x.transform.SetParent(T);
		}
		p=GameObject.Find("Orange5").transform.position;
		T.RotateAround(p, flag*Vector3.up, 380 );
		
		for(int i=0;i<9;i++){
			x=GameObject.Find(UpperFace[i]);
			x.transform.SetParent(RubiksCube.transform);
		}
		
	}
	
	
	
	//DANIA
	string GetColor(Color G){
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
		if (color == Globals.Orange)
			return "Orange";
		else 
			return "Gray" ;
	}
	public void Save(){
		using (StreamWriter sw = File.CreateText(path)) {
				for(int i=0;i<48;i++){
					x=GameObject.Find(Globals.EdgesAndCorners[i]);
					a=x.GetComponent<Renderer>().material.color;
					String w = GetColor (a);
					sw.Write(w+",");
				}	
			sw.Close();
			}
		print("game is saved");
	}
	
}