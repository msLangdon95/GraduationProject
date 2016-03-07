using UnityEngine;
using System.Collections;
public class OnClickChangeColor : MonoBehaviour {
	public static int myColor;
	public Rect windowRect = new Rect(220, 280, 220, 220);
	public static int flag;
	void Start(){
		flag=0;
	}
	public void NextColor(int PickedColor){
		flag=1;
		if(PickedColor==7){
			myColor=PickedColor;
			return;
		}
			
		if(RayCaster.ColorsArray[PickedColor].ColorFlag==false)
			PopUp.ThePanel.SetActive(true);
		else
			myColor=PickedColor;
		
	}
	
}