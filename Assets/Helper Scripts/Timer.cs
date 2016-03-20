using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Timer : MonoBehaviour {

	public float sec;
	public float min;
	public float hours;
	public Text time; 
	void Start(){
	}
	void Update () {
		sec +=Time.deltaTime;
		if(sec>=60){
			min+=1;
			sec=0;
		}
		if(min>=60){
			hours+=1;
			min=0;
		}
		time.text = hours + ":" + min + ":" + sec;
	}

}

