using UnityEngine;
 using System.Collections;
 
 public class GoBack : MonoBehaviour 
 {
	 string[] SceneName = {"main", "newload", "chooseinput","manualinput","rubik","solution"};
	 
     void Update() {
           if (Input.GetKeyDown(KeyCode.Escape)){
			   int LoadedLevel=Application.loadedLevel;
			   if(LoadedLevel==0)
				  Application.Quit();
			  else if(LoadedLevel==4)
				  Application.LoadLevel("chooseinput");
			  else
				Application.LoadLevel(SceneName[LoadedLevel-1]);
		   }
     }
 }