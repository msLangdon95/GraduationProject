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
	
	//string [] UpperFace={"RED","Edge1","Edge3","Edge4","Edge12","Corner1","Corner2","Corner7","Corner8"};
	string[] one = {"YELLOW","Edge7","Edge11","Edge5","Edge2","Corner7","Corner6","Corner3","Corner1"};
	string[] two = {"CENTER","ORANGE","RED","WHITE","BLUE","Edge9","Edge1","Edge12","Edge4"};
	string[] three = {"GREEN","Edge10","Edge8","Edge6","Edge3","Corner5","Corner8","Corner4","Corner2"};
	string[] four = {"ORANGE","Edge6","Edge9","Edge1","Edge5","Corner5","Corner6","Corner2","Corner1"};
	string[] five = {"RED","CENTER","Edge3","Edge11","Edge2","WHITE","Edge10","GREEN","YELLOW"};
    string[] seven = {"CENTER","ORANGE","BLUE","RED","WHITE","Edge9","Edge1","Edge4","Edge12"};
	string[] eight = {"Corner2","Corner6","Corner1","Corner5","Edge5","Edge9","Edge1","Edge6","ORANGE"};
	string[] nine = {"BLUE","Edge8","Edge12","Edge4","Edge7","Corner4","Corner3","Corner7","Corner8"};
	string[] six = {"BLUE","Edge8","Corner8","Edge12","Corner4","Edge7","Corner7","Edge4","Corner3"};
	public Vector3 p;
	Vector2 fp,lp;
	GameObject RubiksCube,Parent,Parent2,Parent3,Parent4,Parent5,Parent6,Parent7,Parent8,Parent9;
	GameObject p1,p2,p3,p4,p5,p6,p7,p8,p9,x;
	void Start(){
		RubiksCube=GameObject.Find("RubiksCube");
		Parent=GameObject.Find("Parent");
		Parent2=GameObject.Find("Parent2");
		Parent3=GameObject.Find("Parent3");
		Parent4=GameObject.Find("Parent4");
		Parent5=GameObject.Find("Parent5");
		Parent6=GameObject.Find("Parent6");
		Parent7=GameObject.Find("Parent7");
		Parent8=GameObject.Find("Parent8");
		Parent9=GameObject.Find("Parent9");
	}
	void FixedUpdate(){
		if (Input.GetMouseButtonDown (0)) {
			ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out rayHit)) {
				lastClicked = rayHit.collider.gameObject;
				c=lastClicked.transform.parent;
				print (c);
			}
		}
	}
	void Update(){
		for(int i=0;i<9;i++){
			p1=GameObject.Find(one[i]);
			p1.transform.SetParent(Parent.transform);

			p2=GameObject.Find(two[i]);
			p2.transform.SetParent(Parent2.transform);

			p3=GameObject.Find(three[i]);
			p3.transform.SetParent(Parent3.transform);

			p4=GameObject.Find(four[i]);
			p4.transform.SetParent(Parent4.transform);

			p5=GameObject.Find(five[i]);
			p5.transform.SetParent(Parent5.transform);

			p6=GameObject.Find(six[i]);
			p6.transform.SetParent(Parent6.transform);

			p7=GameObject.Find(seven[i]);
			p7.transform.SetParent(Parent7.transform);

			p8=GameObject.Find(eight[i]);
			p8.transform.SetParent(Parent8.transform);

			p9=GameObject.Find(nine[i]);
			p9.transform.SetParent(Parent9.transform);

		
		}
		//if ((c == GameObject.Find (three [1]).transform)) {
		//	Rotate(Parent3.transform,1,three,"GREEN");
		//}

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
				

				for(int j=0;j<9;j++){
					if((c==GameObject.Find(one[j]).transform)&&(fp.x - lp.x) >80) // left swipe
					{
						Rotate(Parent.transform,1,one,"YELLOW");
					}
					else if((c==GameObject.Find(two[j]).transform)&&(fp.x - lp.x) >80) // left swipe
					{
						Rotate(Parent2.transform,1,two,"CENTER");

						//player.Rotate(0,-90,0);
						//print("left");
					}
					else if((c==GameObject.Find(three[j]).transform)&&(fp.x - lp.x) >80) // left swipe
					{
						Rotate(Parent3.transform,1,three,"GREEN");
					}
				else if ((c==GameObject.Find(three[j]).transform)&&(fp.x - lp.x) < -80){
						Rotate(Parent3.transform,-1,three,"GREEN");

					}
					else if ((c==GameObject.Find(two[j]).transform)&&(fp.x - lp.x) < -80){
						Rotate(Parent2.transform,-1,two,"CENTER");
						
					}
					else if ((c==GameObject.Find(one[j]).transform)&&(fp.x - lp.x) < -80){
						Rotate(Parent.transform,-1,one,"YELLOW");
						
					}
					else if((c==GameObject.Find(seven[j]).transform)&&(fp.y - lp.y) < -80 ) // up swipe
					{
						RotateUp(Parent7.transform,1,seven,"CENTER");
					}
					else if((c==GameObject.Find(eight[j]).transform)&&(fp.y - lp.y) < -80 ) // up swipe
					{
						RotateUp(Parent8.transform,1,eight,"YELLOW");
					}
					else if((c==GameObject.Find(nine[j]).transform)&&(fp.y - lp.y) < -80 ) // up swipe
					{
						RotateUp(Parent9.transform,1,nine,"GREEN");
					}
					else if((c==GameObject.Find(seven[j]).transform)&&(fp.y - lp.y) >80 ) // up swipe
					{
						RotateUp(Parent7.transform,-1,seven,"CENTER");
					}
					else if((c==GameObject.Find(eight[j]).transform)&&(fp.y - lp.y) >80 ) // up swipe
					{
						RotateUp(Parent8.transform,-1,eight,"YELLOW");
					}
					else if((c==GameObject.Find(nine[j]).transform)&&(fp.y - lp.y) > 80 ) // up swipe
					{
						RotateUp(Parent9.transform,-1,nine,"GREEN");
					}


				}

				}
				
					
					/*	else if((fp.x - lp.x) < -80) // right swipe
				{
					Rotate(Parent.transform,-1,six,"RED");
					//player.Rotate(0,90,0);
					//print("right");
				}
				else if((fp.y - lp.y) < -80 ) // up swipe
				{
				 print("up");
				}*/
				//}
			//}
		}
	}
	
	
	public void Rotate(Transform T,int flag,string []f,string r){
		for(int i=0;i<9;i++){
			x=GameObject.Find(f[i]);
			x.transform.SetParent(T);
			
		}
		p=GameObject.Find(r).transform.position;
		T.RotateAround(p, flag*Vector3.up, 380 );
		
		for(int i=0;i<9;i++){
			x=GameObject.Find(f[i]);
			x.transform.SetParent(RubiksCube.transform);
		}
		
	}

	public void RotateUp(Transform T,int flag,string []f,string r){
		for(int i=0;i<9;i++){
			x=GameObject.Find(f[i]);
			x.transform.SetParent(T);
			
		}
		p=GameObject.Find(r).transform.position;
		T.RotateAround(p, flag*Vector3.right, 380 );
		
		for(int i=0;i<9;i++){
			x=GameObject.Find(f[i]);
			x.transform.SetParent(RubiksCube.transform);
		}
		
	}
	
}



