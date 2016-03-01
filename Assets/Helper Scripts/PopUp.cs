using UnityEngine;
using System.Collections;
public class PopUp : MonoBehaviour {
	public static GameObject ThePanel;
	void Start(){
		ThePanel=GameObject.Find("PopUp");
		ThePanel.SetActive(false);
	}
	
	public void Close(){
		ThePanel.SetActive(false);
	}
	
}