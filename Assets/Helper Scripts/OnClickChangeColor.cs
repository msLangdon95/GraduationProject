using UnityEngine;
using System.Collections;
public class OnClickChangeColor : MonoBehaviour {
	public static int myColor;
	//private static int flag;
	void Start(){}
	public void NextColor(int PickedColor){
		myColor=PickedColor;
	}
}