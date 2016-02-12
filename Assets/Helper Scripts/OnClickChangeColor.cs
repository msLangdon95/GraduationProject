using UnityEngine;
using System.Collections;
public class OnClickChangeColor : MonoBehaviour {
	public static int myColor;
	public static int flag;
	void Start(){
		flag=0;
	}
	public void NextColor(int PickedColor){
		flag=1;
		myColor=PickedColor;
	}
}