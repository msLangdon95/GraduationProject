using UnityEngine;
using System.Collections;
using UnityEngine.UI;    
public class RubikScene : MonoBehaviour {
	string [] UpperFace={"Corner3","Edge4","Corner8","Edge12","Corner6","Edge8","Corner2","Edge7"};
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