using UnityEngine;
using System.Collections;
using UnityEngine.UI;    
public class RayCaster : MonoBehaviour {
	GameObject lastClicked,Green,Red,Blue,Yellow,White,Orange;
	Ray ray;
	RaycastHit rayHit;
	int ColorNumber;
	int [] ColorsCount;
	
	void Start(){
		ColorNumber=0;
		ColorsCount=new int[7];
		Green=GameObject.Find("green");
		Red=GameObject.Find("red");
		Blue=GameObject.Find("blue");
		Yellow=GameObject.Find("yellow");
		White=GameObject.Find("white");
		Orange=GameObject.Find("orange");
		for(int i=1;i<7;i++)
			ColorsCount[i]=0;
	}
	
	int GetColor(GameObject G){
		Color color = G.gameObject.GetComponent<Renderer> ().material.color;
		if ( color == Color.green)
			return 1;
		else if ( color == Color.red)
			return 2;
		else if ( color == Color.blue)
			return 3;
		else if ( color [0] == 1 && color [0] == 0 && color [0] == 0.27058823529f && color [0] == 1  )
			return 4;
		else if (color==Color.yellow )
			return 5;
		else if (color==Color.white)
			return 6;
		else 
			return -1;
	}
	
	void FixedUpdate(){
		if(Input.GetMouseButtonDown (0)){
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(ray, out rayHit)){
				lastClicked = rayHit.collider.gameObject;
				if(lastClicked != null && OnClickChangeColor.flag==1 && lastClicked.tag != "1"){
					ColorNumber=GetColor(lastClicked);
					if(OnClickChangeColor.myColor == 1){ //green
						if(ColorNumber > 0 && ColorNumber < 7)
							ColorsCount[ColorNumber] -- ;
						lastClicked.gameObject.GetComponent<Renderer>().material.color = Color.green;
						ColorsCount[1]++;
						Green.GetComponentInChildren<Text>().text=ColorsCount[1].ToString();
					}
					else if(OnClickChangeColor.myColor == 2){ //red
						if(ColorNumber > 0 && ColorNumber < 7)
							ColorsCount[ColorNumber] -- ;
						lastClicked.gameObject.GetComponent<Renderer>().material.color =  Color.red;
						ColorsCount[2]++;
						Red.GetComponentInChildren<Text>().text=ColorsCount[2].ToString();
					}
					else if(OnClickChangeColor.myColor == 3){ //blue
						if(ColorNumber > 0 && ColorNumber < 7)
							ColorsCount[ColorNumber] -- ;
						lastClicked.gameObject.GetComponent<Renderer>().material.color =  Color.blue;
						ColorsCount[3]++;
						Blue.GetComponentInChildren<Text>().text=ColorsCount[3].ToString();
					}
					else if(OnClickChangeColor.myColor == 4){ //orange
						if(ColorNumber > 0 && ColorNumber < 7)
							ColorsCount[ColorNumber] -- ;
						lastClicked.gameObject.GetComponent<Renderer>().material.color = new Color(1,0.27058823529f,0,1);
						ColorsCount[4]++;
						Orange.GetComponentInChildren<Text>().text=ColorsCount[4].ToString();
					}
					else if(OnClickChangeColor.myColor == 5){ //yellow
						if(ColorNumber > 0 && ColorNumber < 7)
							ColorsCount[ColorNumber] -- ;
						lastClicked.gameObject.GetComponent<Renderer>().material.color =  Color.yellow;
						ColorsCount[5]++;
						Yellow.GetComponentInChildren<Text>().text=ColorsCount[5].ToString();
					}
					else if(OnClickChangeColor.myColor == 6){ //white
						if(ColorNumber > 0 && ColorNumber < 7)
							ColorsCount[ColorNumber] -- ;
						lastClicked.gameObject.GetComponent<Renderer>().material.color =  Color.white;
						ColorsCount[6]++;
						White.GetComponentInChildren<Text>().text=ColorsCount[6].ToString();
					}
				}
			}
		}
		
	}
}