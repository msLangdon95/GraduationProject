using UnityEngine;
using System.Collections;
using UnityEngine.UI;    
public class Verify : MonoBehaviour {
	GameObject x;
	string [] counters={"white","green","red","blue","orange","yellow"};
	public void VerifyAndGo(){
		for(int i=0;i<8;i++){
			x=GameObject.Find(counters[i]);
			if(x.GetComponentInChildren<Text>().text != "8"){ //not all cubies are fully colored
				print("error");
				return;
			}
		}

		for(int i=0;i<48;i++){
			x=GameObject.Find(Clear.EdgesAndCorners[i]);
			if(x.GetComponentInChildren<TextMesh>().text=="X"){//not all cubies are colored correctly
				print("error");
				return;
			}
		}
		Application.LoadLevel("rubik");
	}
}