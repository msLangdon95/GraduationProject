using UnityEngine;
using System.Collections;
using UnityEngine.UI;    
using System;
using System.Linq;  
using System.IO;
using System.Text;

public class RubikScene : MonoBehaviour {
	GameObject lastClicked,PrevGameObj;
	Ray ray;
	GameObject temp;
	RaycastHit rayHit;
     //Public Variables
     public GameObject rubix;
     //Private Variables
     private GameObject[] cubes;
     private GameObject[] face;
     private GameObject Pivot;
     private int i;
	 void Start (){
         //All cubes tagged as Cube
         cubes = GameObject.FindGameObjectsWithTag("Cube");
         //9 cubes per face
         face = new GameObject[9];
     }
	 
 
     void RotateUpper(){//alwats yellow
		 i = 0;
		 temp=GameObject.Find("YELLOW");
		 if(temp!=null){
			Pivot = new GameObject("upPivot");
			Pivot.transform.position = new Vector3(0,238,0);
			Pivot.transform.parent = rubix.transform;
			foreach(GameObject cube in cubes){
				if(cube.transform.position.y >=235 && cube.transform.position.y <=245){
					cube.transform.parent = Pivot.transform;
					face[i] = cube;
					i++;
				}
			}
			Pivot.transform.RotateAround(temp.transform.position, Vector3.up, 380);
			i=0;
			foreach(GameObject cube in face){
				face[i++].transform.parent=rubix.transform;
				}
			Destroy(Pivot);
		 }
		 else
			 print("it's null");
	 }
	 ////////////////////////////////////////////////////////////////////////////////////////////
	 void RotateDown(){
		 i = 0;
		 temp=GameObject.Find("GREEN");
		 if(temp!=null){
			Pivot = new GameObject("Pivot");
			Pivot.transform.position = new Vector3(0,150,0);
			Pivot.transform.parent = rubix.transform;
			foreach(GameObject cube in cubes){
				if(cube.transform.position.y >=150 && cube.transform.position.y <=155){
					cube.transform.parent = Pivot.transform;
					face[i] = cube;
					i++;
				}
			}
			Pivot.transform.RotateAround(temp.transform.position, Vector3.up, 380);
			i=0;
			foreach(GameObject cube in face){
				face[i++].transform.parent=rubix.transform;
				}
			Destroy(Pivot);
		 }
		 else
			 print("it's null");
	 }
	 
	 
	 
	 
     void Update(){
		 if(Input.GetMouseButtonDown (0)){
			 ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(ray, out rayHit))
				lastClicked = rayHit.collider.gameObject;
			if(lastClicked != null)
				print(lastClicked.transform.position.x + " ? "+lastClicked.transform.position.y+ " ? "+ lastClicked.transform.position.z);
			//if upper face
			RotateUpper();
			RotateDown();
		 }
     }
 }



