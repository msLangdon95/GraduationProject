using UnityEngine;
 using System.Collections;
 
 public class GoBack : MonoBehaviour 
 {
	 private bool flag;
	 private string lastLevel;

    public void setLastLevel(string level)
    {
        lastLevel = level;
    }
     void Update() {
           if (Input.GetKeyDown(KeyCode.Escape))
             Application.LoadLevel(lastLevel);
     }
 }