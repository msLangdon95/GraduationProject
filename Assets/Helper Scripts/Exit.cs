using UnityEngine;
 using System.Collections;
 
 public class Exit : MonoBehaviour {
	GameObject BackPanel;
	void Start () {
		Globals.ExitPanel = GameObject.Find ("ExitPanel");
		Globals.ExitPanel.SetActive (false);
		BackPanel = GameObject.Find ("BackPanel");
		BackPanel.SetActive(false);
	}
	 
	public void showMessage(){

		Globals.ExitPanel.SetActive (true);
	}

	public void showBackMessage(){
		
		BackPanel.SetActive (true);
	}

	public void DoNothing(){
		Globals.ExitPanel.SetActive (false);

	}
	public void DoNothingBack(){
		BackPanel.SetActive (false);
		
		
	}

     public void QUIT()
     {
         Application.Quit();
     }
 }