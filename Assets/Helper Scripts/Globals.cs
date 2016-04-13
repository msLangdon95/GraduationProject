using UnityEngine;
using System.Collections;
using UnityEngine.UI;    
public class Globals : MonoBehaviour {
	
	public struct COLOR{
		public GameObject GO;
		public bool ColorFlag;
		public Color CurrentColor;
		public int ColorCounter;
		public COLOR(GameObject x,bool cf, Color cc, int cCounter){
			GO=x;
			ColorFlag=cf;
			CurrentColor=cc;
			ColorCounter=cCounter;
		}
	};
	public static string [] EdgesAndCorners={
		"Red1","Red2","Red3","Red4","Red5","Red6","Red7","Red8",//up
		"Green1","Green2","Green3","Green4","Green5","Green6","Green7","Green8",//front
		"Blue1","Blue2","Blue3","Blue4","Blue5","Blue6","Blue7","Blue8",
		"Yellow1","Yellow2","Yellow3","Yellow4","Yellow5","Yellow6","Yellow7","Yellow8",//back
		"Orange1","Orange2","Orange3","Orange4","Orange5","Orange6","Orange7","Orange8",
		"White1","White2","White3","White4","White5","White6","White7","White8"//down
	};
	public static Color [] CurrentCubeColors=new Color[48];
	public static COLOR [] ColorsArray=new COLOR[]{
		new COLOR(GameObject.Find("green"),true,Color.green,0),
		new COLOR(GameObject.Find("red"),true,Color.red,0),
		new COLOR(GameObject.Find("blue"),true,Color.blue,0),
		new COLOR(GameObject.Find("orange"),true,new Color(1,0.27058823529f,0,1),0),
		new COLOR(GameObject.Find("yellow"),true,Color.yellow,0),
		new COLOR(GameObject.Find("white"),true,Color.white,0),
	};
	public static GameObject ThePanel;
	public static GameObject ColoredWronglyPanel;
	public static GameObject VerifyPanel;
	public static GameObject ExitPanel;
	public static GameObject LoadingMessagePanel;
	public static bool dontShowAgain;
	public static Color Orange=new Color(1,0.27058823529f,0,1);
}