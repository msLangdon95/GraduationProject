using UnityEngine;
using System.Collections;
using UnityEngine.UI;    
using System;
using System.Linq;  
using System.IO;
using System.Text;
using System.Collections.Generic;
public class RubikScene : MonoBehaviour {
	public int noOfSteps;
	GameObject lastClicked,Parent,temp,Center,rubix,steps;
	Ray ray;
	RaycastHit rayHit;
	Vector2 fp,lp;
	string referenceName;
	int referenceCount;
	int i;
     private GameObject[] cubes;
	 List<string> l1 = new List<string>();
	 List<string> l2 = new List<string>();
	 Vector2 firstPressPos;
	 Vector2 secondPressPos;
	 Vector2 currentSwipe;
	 void Start (){
		 noOfSteps=0;
		 steps=GameObject.Find("steps");
		  cubes = GameObject.FindGameObjectsWithTag("Cube");
		  Parent=GameObject.Find("Parent");
		  Center=GameObject.Find("CENTER");
		  rubix=GameObject.Find("RubiksCube");
     } 
	 void UpOrDown(int flag){
		 if(l1.Count==9){
				referenceCount=0;
				for(int i=0;i<9;i++){
					temp=GameObject.Find(l1[i]);
					temp.transform.SetParent(Parent.transform);
					if(l1[i][0] != 'E' && l1[i][0] != 'C'){
						referenceCount++;
						referenceName=l1[i];
					}
				}
				if(referenceCount==1){
					temp=GameObject.Find(referenceName);
					float totalRotation = 0;
					 while (Mathf.Abs(totalRotation) < 90){
						totalRotation += Time.deltaTime;
						Parent.transform.RotateAround(temp.transform.position, flag*Vector3.right, Time.deltaTime);
					}
				}
				else{
					float totalRotation = 0;
					 while (Mathf.Abs(totalRotation) < 90){
						totalRotation += Time.deltaTime;
						Parent.transform.RotateAround(Center.transform.position, flag*Vector3.right, Time.deltaTime);
					}
				}
				for(int i=0;i<9;i++){
					temp=GameObject.Find(l1[i]);
					temp.transform.SetParent(rubix.transform);
				}
				noOfSteps++;
				steps.GetComponent<Text>().text=noOfSteps.ToString();
			}
	 }
	 
	 void LeftOrRight(int flag){
		 if(l2.Count==9){
				referenceCount=0;
				for(int i=0;i<9;i++){
					temp=GameObject.Find(l2[i]);
					temp.transform.SetParent(Parent.transform);
					if(l2[i][0] != 'E' && l2[i][0] != 'C'){
						referenceCount++;
						referenceName=l2[i];
					}
				}
				if(referenceCount==1){
					temp=GameObject.Find(referenceName);
					float totalRotation = 0;
					 while (Mathf.Abs(totalRotation) < 90){
						totalRotation += Time.deltaTime;
						Parent.transform.RotateAround(temp.transform.position, flag*Vector3.up, Time.deltaTime);
					}
				}
				else{
					float totalRotation = 0;
					 while (Mathf.Abs(totalRotation) < 90){
						totalRotation += Time.deltaTime;
						Parent.transform.RotateAround(Center.transform.position, flag*Vector3.up, Time.deltaTime);
					}
				}
				for(int i=0;i<9;i++){
					temp=GameObject.Find(l2[i]);
					temp.transform.SetParent(rubix.transform);
				}
				noOfSteps++;
				steps.GetComponent<Text>().text=noOfSteps.ToString();
			}
	 }
	 void ClearLists(){
		 l1.Clear();
		 l2.Clear();
	 }

     void Update(){
		currentSwipe.x=currentSwipe.y=firstPressPos.x=firstPressPos.y=0;
		if (Input.GetMouseButtonDown (0)) {
			ClearLists();
			ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out rayHit)) {
				lastClicked = rayHit.collider.gameObject;
				if(lastClicked==null)
					return;
				print(lastClicked.name+" "+(int)lastClicked.transform.position.x+ " " +(int)lastClicked.transform.position.x+ " "+
				(int)lastClicked.transform.position.z);
			}
			firstPressPos = new Vector3(Input.mousePosition.x,Input.mousePosition.y);
		}
		if(Input.GetMouseButtonUp(0)){
			//save ended touch
			secondPressPos = new Vector3(Input.mousePosition.x,Input.mousePosition.y);
			currentSwipe = new Vector3(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
			currentSwipe.Normalize();
		 }
        if(currentSwipe.y > 0 && currentSwipe.x > -0.7f && currentSwipe.x < 0.7f){//swipe upwards
			foreach(GameObject cube in cubes){
				if(Mathf.Abs(lastClicked.transform.parent.position.x- cube.transform.position.x) >= 0 && Mathf.Abs(lastClicked.transform.parent.position.x- cube.transform.position.x)<=5f){
					l1.Add(cube.name);
				}
			}
			print("up swipe "+l1.Count);
			UpOrDown(1);
			ClearLists();
        }
        else if(currentSwipe.y < 0 && currentSwipe.x > -0.7f && currentSwipe.x < 0.7f){//swipe down
		   foreach(GameObject cube in cubes){
				if(Mathf.Abs(lastClicked.transform.parent.position.x- cube.transform.position.x) >= 0 && Mathf.Abs(lastClicked.transform.parent.position.x- cube.transform.position.x)<=5f){
					l1.Add(cube.name);
				}
			}
			print("down swipe "+l1.Count);
			UpOrDown(-1);
			ClearLists();
        }
        else if(currentSwipe.x < 0 && currentSwipe.y > -0.7f && currentSwipe.y < 0.7f){//swipe left
			foreach(GameObject cube in cubes){
				
			}
            print("left swipe" + l2.Count);
			LeftOrRight(1);
			ClearLists();
        }
        else if(currentSwipe.x > 0 && currentSwipe.y > -0.7f && currentSwipe.y < 0.7f){//swipe right
			foreach(GameObject cube in cubes){
				if(Mathf.Abs(lastClicked.transform.parent.position.y- cube.transform.position.y) >= 0 && Mathf.Abs(lastClicked.transform.parent.position.y- cube.transform.position.y)<=7f){
					l2.Add(cube.name);
				}
			}
            print("right swipe "+l2.Count);
			LeftOrRight(-1);
			ClearLists();
        }
     }
 }