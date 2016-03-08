using UnityEngine;
using System.Collections;
using UnityEngine.UI;    
public class Clear : MonoBehaviour {
	public static string [] EdgesAndCorners={
	"White1","White2","White3","White4","White6","White7","White8","White9",
	"Blue1","Blue2","Blue3","Blue4","Blue6","Blue7","Blue8","Blue9",
	"Red1","Red2","Red3","Red4","Red6","Red7","Red8","Red9",
	"Yellow1","Yellow2","Yellow3","Yellow4","Yellow6","Yellow7","Yellow8","Yellow9",
	"Orange1","Orange2","Orange3","Orange4","Orange6","Orange7","Orange8","Orange9",
	"Green1","Green2","Green3","Green4","Green6","Green7","Green8","Green9"
	};
	GameObject x;
	public void ReClear(){
		for(int i=0;i<48;i++){
			x=GameObject.Find(EdgesAndCorners[i]);
			x.GetComponent<Renderer>().material.color =Color.gray;
		}
	}
}