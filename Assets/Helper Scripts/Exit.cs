using UnityEngine;
 using System.Collections;
 
 public class Exit : MonoBehaviour {
	void Start () {
		Globals.ExitPanel = GameObject.Find ("ExitPanel");
		Globals.ExitPanel.SetActive (false);

	}
	 
	public void showMessage(){

		Globals.ExitPanel.SetActive (true);
	}

	public void DoNothing(){
		Globals.ExitPanel.SetActive (false);


	}
     public void QUIT()
     {
         Application.Quit ();
     }
 }