using UnityEngine;
using System.Collections;

public class timerScript : MonoBehaviour {

	private float seconds = 00.0f;
	private float minutes = 00.0f;
	private float hours = 00.0f;
	int sec;
	GUIText healthGUI;
	Color o = new Color (1,1,0,1);

	GUIStyle style = new GUIStyle();
	void Start(){
	//	healthGUI = "00.00.00";
		style.normal.textColor = o;
	
	}
	void Update () {
		seconds += Time.deltaTime;
		if(seconds > 60){
			minutes += 1;
			seconds = 00;
		}
		if(minutes > 60){
			hours += 1;
			minutes = 00;
		}
		//print(/*"Hours: " + hours + " " + "Minutes: " + minutes + " " + "Seconds" +*/(int) seconds);
		sec = (int)seconds;
		
		
	}
	
	void OnGUI(){
		GUI.Label (new Rect (10,0,50,100),hours.ToString()+":"+minutes.ToString()+":"+ sec.ToString(),style);
		/*GUI.Box (new Rect (Screen.width - 100,0,100,50), "Top-right");
		GUI.Box (new Rect (0,Screen.height - 50,100,50), "Bottom-left");
		GUI.Box (new Rect (Screen.width - 100,Screen.height - 50,100,50), "Bottom-right");*/
	}
}
