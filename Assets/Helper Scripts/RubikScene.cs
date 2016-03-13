using UnityEngine;
using System.Collections;
using UnityEngine.UI;    
public class RubikScene : MonoBehaviour {
	string [] UpperFace={"Corner3","Edge4","Corner8","Edge12","Corner6","Edge8","Corner2","Edge7"};
	
	public Vector3 p;
	GameObject x,Parent,RubiksCube;
	void Start(){
		Parent=GameObject.Find("Parent");
		RubiksCube=GameObject.Find("RubiksCube");
		/*for(int i=0;i<48;i++){
			x=GameObject.Find(Globals.EdgesAndCorners[i]);
			x.GetComponent<Renderer>().material.color=Globals.CurrentCubeColors[i];
		}*/
	}
	public void RotateUpper(Transform T){
		for(int i=0;i<8;i++){
			x=GameObject.Find(UpperFace[i]);
			x.transform.SetParent(Parent.transform);
		}
		p=GameObject.Find("Orange5").transform.position;
		T.RotateAround(p, Vector3.up, 380 );
		
		for(int i=0;i<8;i++){
			x=GameObject.Find(UpperFace[i]);
			x.transform.SetParent(RubiksCube.transform);
		}
		
	}
	
	
	
}