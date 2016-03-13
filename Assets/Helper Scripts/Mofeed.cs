using UnityEngine;
using System.Collections;
using UnityEngine.UI;    
public class Mofeed : MonoBehaviour {
	string [] ArrayOfStr={
	"Corner3","Edge4","Corner8","Edge12","Corner6","Edge8","Corner2","Edge7"
	};
	GameObject x,y;
	public void Click(){
		for(int i=0;i<1;i++){
			x=GameObject.Find(ArrayOfStr[i]);
			y=GameObject.Find(ArrayOfStr[i+2]);
			x.transform.position=y.transform.position;
			x.transform.rotation=y.transform.rotation;
			print(x.transform.position);
			print(y.transform.position);
		}
	}
}