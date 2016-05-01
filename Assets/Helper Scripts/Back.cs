using UnityEngine;
using System.Collections;

public class Back : MonoBehaviour {
	GameObject BackPanel;
	// Use this for initialization
	void Start () {
		BackPanel = GameObject.Find ("BackPanel");
		BackPanel.SetActive(false);
	}
	
	public void showBackMessage(){
		
		BackPanel.SetActive (true);
	}
	public void DoNothingBack(){
		BackPanel.SetActive (false);
		
		
	}

}
