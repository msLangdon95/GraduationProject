using UnityEngine;
using System.Collections;
using UnityEngine.UI;    
using System;
using System.Linq;  
using System.IO;
using System.Text;
using System.Collections.Generic;

public class RubikScene : MonoBehaviour {
	GameObject lastClicked,Parent,temp,Center,rubix;
	Ray ray;
	RaycastHit rayHit;
	Vector2 fp,lp;
	string referenceName;
	int referenceCount;
     private GameObject[] cubes;
	 List<string> l1 = new List<string>();
	 List<string> l2 = new List<string>();
	 List<string> l3 = new List<string>();
	 Vector3 firstPressPos;
	 Vector3 secondPressPos;
	 Vector3 currentSwipe;
	 void Start (){
		  cubes = GameObject.FindGameObjectsWithTag("Cube");
		  Parent=GameObject.Find("Parent");
		  Center=GameObject.Find("CENTER");
		  rubix=GameObject.Find("RubiksCube");
     } 
	 
     void FixedUpdate(){
		 if(Input.GetMouseButtonDown (0)){
			 firstPressPos = new Vector3(Input.mousePosition.x,Input.mousePosition.y,Input.mousePosition.z);
			 ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(ray, out rayHit))
				lastClicked = rayHit.collider.gameObject;
			if(lastClicked == null)		
				return;
			foreach(GameObject cube in cubes){
				if(Mathf.Abs(lastClicked.transform.parent.position.x- cube.transform.position.x) >= 0 && Mathf.Abs(lastClicked.transform.parent.position.x- cube.transform.position.x)<=10){
					l1.Add(cube.name);
				}
				if(Mathf.Abs(lastClicked.transform.parent.position.y- cube.transform.position.y) >= 0 && Mathf.Abs(lastClicked.transform.parent.position.y- cube.transform.position.y)<=10){
					l2.Add(cube.name);
				}
				if(Mathf.Abs(lastClicked.transform.parent.position.z- cube.transform.position.z) >= 0 && Mathf.Abs(lastClicked.transform.parent.position.z- cube.transform.position.z)<=10){
					l3.Add(cube.name);
				}
			}
		 }
		 if(Input.GetMouseButtonUp(0)){
         //save ended touch
        secondPressPos = new Vector3(Input.mousePosition.x,Input.mousePosition.y,Input.mousePosition.z);
        currentSwipe = new Vector3(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y,secondPressPos.z - firstPressPos.z);
        currentSwipe.Normalize();
		 }
       
        if(currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f){//swipe upwards
            print("up swipe "+l1.Count);
			if(l1.Count==9){
				referenceCount=0;
				for(int i=0;i<9;i++){
					temp=GameObject.Find(l1[i]);
					temp.transform.parent=Parent.transform;
					if(l1[i][0] != 'E' && l1[i][0] != 'C'){
						referenceCount++;
						referenceName=l1[i];
					}
				}
				if(referenceCount==1){
					temp=GameObject.Find(referenceName);
					Parent.transform.RotateAround(temp.transform.position,Vector3.right,380);
				}
				else{
					Parent.transform.RotateAround(Center.transform.position,Vector3.right,380);
				}
				for(int i=0;i<9;i++){
					temp=GameObject.Find(l1[i]);
					temp.transform.parent=rubix.transform;
				}
			}
			currentSwipe.y=currentSwipe.x=0;
			l1.Clear();
        }
        else if(currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f){//swipe down
            print("down swipe");
        }
        else if(currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f){//swipe left
            print("left swipe");
        }
        else if(currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f){//swipe right
            print("right swipe");
        }
     }
 }