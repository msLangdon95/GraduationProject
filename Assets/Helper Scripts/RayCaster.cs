using UnityEngine;
using System.Collections;
using UnityEngine.UI;    
public class RayCaster : MonoBehaviour {
	public struct COLOR{
		public GameObject GO;
		public bool ColorFlag;
		public Color CurrentColor;
		public int ColorCounter;
	};
	public static COLOR [] ColorsArray;
	int x;
	GameObject lastClicked;
	Ray ray;
	RaycastHit rayHit;
	int ColorNumber;
	Color ORANGE;
	int i;
	void Start(){
		i=0;
		ColorNumber=0;
		ORANGE=new Color(1,0.27058823529f,0,1);	
		
		ColorsArray=new COLOR[7];
		ColorsArray[1].GO=GameObject.Find("green");
		ColorsArray[1].ColorFlag=true;
		ColorsArray[1].CurrentColor=Color.green;
		ColorsArray[1].ColorCounter=0;
		
		ColorsArray[2].GO=GameObject.Find("red");
		ColorsArray[2].ColorFlag=true;
		ColorsArray[2].CurrentColor=Color.red;
		ColorsArray[2].ColorCounter=0;
		
		ColorsArray[3].GO=GameObject.Find("blue");
		ColorsArray[3].ColorFlag=true;
		ColorsArray[3].CurrentColor=Color.blue;
		ColorsArray[3].ColorCounter=0;
		
		ColorsArray[4].GO=GameObject.Find("orange");
		ColorsArray[4].ColorFlag=true;
		ColorsArray[4].CurrentColor=ORANGE; 
		ColorsArray[4].ColorCounter=0;
		
		ColorsArray[5].GO=GameObject.Find("yellow");
		ColorsArray[5].ColorFlag=true;
		ColorsArray[5].CurrentColor=Color.yellow;
		ColorsArray[5].ColorCounter=0;
		
		ColorsArray[6].GO=GameObject.Find("white");
		ColorsArray[6].ColorFlag=true;
		ColorsArray[6].CurrentColor=Color.white;
		ColorsArray[6].ColorCounter=0;
	}
	
	
	int GetColor(GameObject G){
		Color color = G.gameObject.GetComponent<Renderer> ().material.color;
		if ( color == Color.green)
			return 1;
		else if ( color == Color.red)
			return 2;
		else if ( color == Color.blue)
			return 3;
		else if ( color == ORANGE )
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
				if(lastClicked != null && OnClickChangeColor.flag==1 && lastClicked.GetComponent<Collider>().tag != "1"){
					x=OnClickChangeColor.myColor;// to color with color number x
					if(ColorsArray[x].ColorFlag){
						foreach (Transform child in lastClicked.transform.parent){
							if(lastClicked != child.gameObject && GetColor(child.gameObject) == x){
								print("not valid" + child.name);
								return;
							}
							else{
								print("else"+ i++);
								ColorsArray[x].ColorCounter ++ ;
								if(ColorsArray[x].ColorCounter >8){ // can't color more than 8 times so subtract and activate the panel
									ColorsArray[x].ColorCounter -- ;
									ColorsArray[x].ColorFlag=false;
									PopUp.ThePanel.SetActive(true);
									}
							else{ // check the previous color to decrement its counter
								ColorNumber=GetColor(lastClicked);
								if(ColorNumber > 0 && ColorNumber < 7){
									ColorsArray[ColorNumber].ColorCounter -- ;
									ColorsArray[ColorNumber].GO.GetComponentInChildren<Text>().text=ColorsArray[ColorNumber].ColorCounter.ToString();
									if(ColorsArray[ColorNumber].ColorFlag == false)
										ColorsArray[ColorNumber].ColorFlag=true;
									}
								lastClicked.gameObject.GetComponent<Renderer>().material.color =ColorsArray[x].CurrentColor;
								ColorsArray[x].GO.GetComponentInChildren<Text>().text=ColorsArray[x].ColorCounter.ToString();
							}
						}
						}
					}
					
				}
			}
		}
	}
}


/*
	
	public Rect windowRect = new Rect(220, 280, 220, 220);
	
	
	public void OnGUI() {
		if(Input.GetMouseButtonDown (0) && !RayCaster.GreenFlag){
			windowRect = GUI.Window(0, windowRect, DoMyWindow, "Sorry, you can only color using green 8 times");
		}
    }
	
    void DoMyWindow(int windowID) {
       // if (GUI.Button(new Rect(10, 20, 100, 20), "Hello World"))
           // print("Got a click"); 
    }
	
	
	
	void CheckFlag(out bool TempFlag,int number){
		if((number==1 && ColorsCount[1] > 8) || (number==2 && ColorsCount[2] > 8) || (number==3 && ColorsCount[3] > 8)  || (number==4 && ColorsCount[4] > 8) || (number==5 && ColorsCount[5] > 8) || (number==6 && ColorsCount[6] > 8))
			TempFlag=false;
		else
			TempFlag=true;
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
	
	GameObject getGameObject(int number){
		if(number==1)
			return Green;
		if(number==2)
			return Red;
		if(number==3)
			return Blue;
		if(number==4)
			return Orange;
		if(number==5)
			return Yellow;
		else
			return White;
	}
	
	
	
	
	/*if(OnClickChangeColor.myColor == 1 && ColorsArray[1].ColorFlag){ //green
						if(ColorNumber > 0 && ColorNumber < 7){
							ColorsCount[ColorNumber] -- ;
							ColorsArray[ColorNumber].GO.GetComponentInChildren<Text>().text=ColorsCount[ColorNumber].ToString();
						}
						ColorsCount[1]++;
						if(ColorsCount[1] > 8) 
							ColorsArray[1].ColorFlag=false;
						else{
						lastClicked.gameObject.GetComponent<Renderer>().material.color = Color.green;
						ColorsArray[1].GO.GetComponentInChildren<Text>().text=ColorsCount[1].ToString();
						}
					}
					
					else if(OnClickChangeColor.myColor == 2 && ColorsArray[2].ColorFlag){ //red
						if(ColorNumber > 0 && ColorNumber < 7){
							ColorsCount[ColorNumber] -- ;
							ColorsArray[ColorNumber].GO.GetComponentInChildren<Text>().text=ColorsCount[ColorNumber].ToString();
						}
						ColorsCount[2]++;
						if(ColorsCount[2] > 8) 
							ColorsArray[2].ColorFlag=false;
						else{
							lastClicked.gameObject.GetComponent<Renderer>().material.color =  Color.red;
							ColorsArray[2].GO.GetComponentInChildren<Text>().text=ColorsCount[2].ToString();
						}
					}
					else if(OnClickChangeColor.myColor == 3 && ColorsArray[3].ColorFlag){ //blue
						if(ColorNumber > 0 && ColorNumber < 7){
							ColorsCount[ColorNumber] -- ;
							ColorsArray[ColorNumber].GO.GetComponentInChildren<Text>().text=ColorsCount[ColorNumber].ToString();
						}
						ColorsCount[3]++;
						if(ColorsCount[3] > 8) 
							ColorsArray[3].ColorFlag=false;
						else{
							lastClicked.gameObject.GetComponent<Renderer>().material.color =  Color.blue;
							ColorsArray[3].GO.GetComponentInChildren<Text>().text=ColorsCount[3].ToString();
						}
					}
					else if(OnClickChangeColor.myColor == 4 && ColorsArray[4].ColorFlag){ //orange
						if(ColorNumber > 0 && ColorNumber < 7){
							ColorsCount[ColorNumber] -- ;
							ColorsArray[ColorNumber].GO.GetComponentInChildren<Text>().text=ColorsCount[ColorNumber].ToString();
						}
						ColorsCount[4]++;
						if(ColorsCount[4] > 8) 
							ColorsArray[4].ColorFlag=false;
						else{
							lastClicked.gameObject.GetComponent<Renderer>().material.color = new Color(1,0.27058823529f,0,1);
							ColorsArray[4].GO.GetComponentInChildren<Text>().text=ColorsCount[4].ToString();
						}
					}
					else if(OnClickChangeColor.myColor == 5 && ColorsArray[5].ColorFlag){ //yellow
						if(ColorNumber > 0 && ColorNumber < 7){
							ColorsCount[ColorNumber] -- ;
							ColorsArray[ColorNumber].GO.GetComponentInChildren<Text>().text=ColorsCount[ColorNumber].ToString();
						}
						ColorsCount[5]++;
						if(ColorsCount[5] > 8) 
							ColorsArray[5].ColorFlag=false;
						else{
							lastClicked.gameObject.GetComponent<Renderer>().material.color =  Color.yellow;
							ColorsArray[5].GO.GetComponentInChildren<Text>().text=ColorsCount[5].ToString();
						}
					}
					else if(OnClickChangeColor.myColor == 6 && ColorsArray[6].ColorFlag){ //white
						if(ColorNumber > 0 && ColorNumber < 7){
							ColorsCount[ColorNumber] -- ;
							ColorsArray[ColorNumber].GO.GetComponentInChildren<Text>().text=ColorsCount[ColorNumber].ToString();
						}
						ColorsCount[6]++;
						if(ColorsCount[6] > 8) 
							ColorsArray[6].ColorFlag=false;
						else{
							lastClicked.gameObject.GetComponent<Renderer>().material.color =  Color.white;
							ColorsArray[6].GO.GetComponentInChildren<Text>().text=ColorsCount[6].ToString();
						}
					}*/
