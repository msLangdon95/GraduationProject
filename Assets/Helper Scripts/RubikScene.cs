using UnityEngine;
using System.Collections;
using UnityEngine.UI;    
using System;
using System.Linq;  
using System.IO;
using System.Text;

public class RubikScene : MonoBehaviour {
	GameObject lastClicked,PrevGameObj;
	public Transform c;
	Ray ray;
	RaycastHit rayHit;
	
	string[] yellowFace = {"Corner1","Edge5","Corner6","Edge2","YELLOW","Edge11","Corner3","Edge7","Corner7"};
	string[] blueFace = {"Corner3","Edge7","Corner7","Edge4","BLUE","Edge12","Corner4","Edge8","Corner8"};
	string[] redFace = {"Corner7","Edge11","Corner6","Edge12","RED","Edge9","Corner8","Edge10","Corner5"};
	string[] orangeFace = {"Corner6","Edge5","Corner1","Edge9","ORANGE","Edge1","Corner5","Edge6","Corner2"};
	string[] whiteFace = {"Corner1","Edge2","Corner3","Edge1","WHITE","Edge4","Corner2","Edge3","Corner4"};
	//string[] greenFace = {""};
	
	Vector2 fp,lp;
	GameObject RubiksCube,Parent;
	GameObject x;
	Transform p;
	void Start(){
		RubiksCube=GameObject.Find("RubiksCube");
		Parent=GameObject.Find("Parent");
	}
	void FixedUpdate(){
		if (Input.GetMouseButtonDown (0)) {
			ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out rayHit)) {
				lastClicked = rayHit.collider.gameObject;
				print(lastClicked.transform.parent.name);
			}
		}
	}
	
	bool isInPlane(string[]plane, string gameObjName){
		for(int i=0;i<9;i++){
			if(plane[i]==gameObjName)
				return true;
		}
		return false;
	}
	
	void Update(){ 
	//if yellow face is clicked+ to the right: 
		if (lastClicked != null && Input.touchCount > 0){
			Touch touch = Input.touches[0];
			 if (touch.phase == TouchPhase.Began){
                fp = touch.position;
                lp = touch.position;
			}
		   if (touch.phase == TouchPhase.Moved ){
                lp = touch.position;
			}
		   if(touch.phase == TouchPhase.Ended){ 
                if((fp.x - lp.x) > 80 && isInPlane(yellowFace,lastClicked.transform.parent.name)) // left swipe of yellow face
				{
					Rotate(yellowFace,1,"up");
					//edit right face
					redFace[0]=yellowFace[2];
					redFace[1]=yellowFace[1];
					redFace[2]=yellowFace[0];
					//edit left face
					whiteFace[0]=yellowFace[6];
					whiteFace[1]=yellowFace[7];
					whiteFace[2]=yellowFace[8];
					//edit front face
					blueFace[0]=yellowFace[8];
					blueFace[1]=yellowFace[5];
					blueFace[2]=yellowFace[2];
					//edit back face
					orangeFace[0]=yellowFace[0];
					orangeFace[1]=yellowFace[3];
					orangeFace[2]=yellowFace[6];
					//edit yellowFace itself
					string[]newArr={yellowFace[6],yellowFace[3],yellowFace[0],yellowFace[7],yellowFace[4],yellowFace[1],yellowFace[8],yellowFace[5],yellowFace[2]};
					for(int i=0;i<9;i++)
						yellowFace[i]=newArr[i];
				}
				else if((fp.x - lp.x) < -80) // right swipe
				{
					
				}
				else if((fp.y - lp.y) < -80 && isInPlane(blueFace,lastClicked.transform.parent.name)) // up swipe of blue face
				{
					Rotate(blueFace,1,"right");
					
					whiteFace[8]=yellowFace[0];
					whiteFace[5]=yellowFace[1];
					whiteFace[2]=yellowFace[2];
					
					redFace[0]=yellowFace[8];
					redFace[3]=yellowFace[7];
					redFace[6]=yellowFace[6];
					
					yellowFace[6]=yellowFace[2];
					yellowFace[2]=yellowFace[5];
					yellowFace[8]=yellowFace[8];
					
					/*greenFace[0]=yellowFace[0];
					greenFace[1]=yellowFace[3];
					greenFace[3]=yellowFace[6];*/
					
					string[]newArr={blueFace[2],blueFace[5],blueFace[8],blueFace[1],blueFace[4],blueFace[7],blueFace[0],blueFace[3],blueFace[6]};
					for(int i=0;i<9;i++)
						blueFace[i]=newArr[i];
				}
			}
		}
	}
	
	
	public void Rotate(string[]plane,int flag,string str){
		for(int i=0;i<9;i++){
			x=GameObject.Find(plane[i]);
			x.transform.SetParent(Parent.transform);
		}
		p=GameObject.Find(plane[4]).transform;
		if(str=="up")
			Parent.transform.RotateAround(p.position, flag*p.up, 380 );
		else if(str=="right")
			Parent.transform.RotateAround(p.position, flag*Parent.transform.up, 380 );
		
		for(int i=0;i<9;i++){
			x=GameObject.Find(plane[i]);
			x.transform.SetParent(RubiksCube.transform);
		}
		
	}
	
}



