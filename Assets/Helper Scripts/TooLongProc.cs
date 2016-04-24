using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class TooLongProc : MonoBehaviour {
	public void WaitAgain(){
		RubikScene.TooLong.SetActive(false);
		OptimalSolution.timer=0f;
		OptimalSolution.badExit = false; 
	}
	public void GoToHome(){
		RubikScene.TooLong.SetActive(false);
		OptimalSolution.myProcess.Kill();
		OptimalSolution.myProcess.Close();
		OptimalSolution.myProcess = null; 
		//FlushIt
		Application.LoadLevel("main");
	}
	public void ExitTooLong(){
		RubikScene.TooLong.SetActive(false);
		OptimalSolution.myProcess.Kill();
		OptimalSolution.myProcess.Close();
		OptimalSolution.myProcess = null; 
		OptimalSolution.paused=false;
		OptimalSolution.badExit = false; 
	}
}