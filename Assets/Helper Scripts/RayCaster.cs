// 2 with 3 and 1 (red with green and blue) -> red and white --> third one can be only BLUE or GREEN

using UnityEngine;
using System.Collections;
using UnityEngine.UI;    
using System;
using System.Linq;
public class RayCaster : MonoBehaviour {
	public struct COLOR{
		public GameObject GO;
		public bool ColorFlag;
		public Color CurrentColor;
		public int ColorCounter;
	};
	public struct CornersCombination{
		public bool flag;
		public string name;
	};
	public static COLOR [] ColorsArray;
	int x;
	GameObject lastClicked;
	Ray ray;
	RaycastHit rayHit;
	int ColorNumber;
	Color ORANGE;
	CornersCombination [] Corners;
	string test;
	char forNothing;
	void Start(){
		ColorNumber=0;
		ORANGE=new Color(1,0.27058823529f,0,1);	
		Corners = new CornersCombination[8];
		
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
		
		Corners [0].name = "grw";
		Corners[0].flag=true;
		Corners [1].name = "bry";
		Corners[1].flag=true;
		Corners [2].name = "brw";
		Corners[2].flag=true;
		Corners [3].name = "gry";
		Corners[3].flag=true;
		Corners [4].name = "bow";
		Corners[4].flag=true;
		Corners [5].name = "gow";
		Corners[5].flag=true;
		Corners [6].name = "goy";
		Corners[6].flag=true;
		Corners [7].name = "boy";
		Corners[7].flag=true;
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
	
	char GetC(GameObject G){
		Color color = G.gameObject.GetComponent<Renderer> ().material.color;
		if ( color == Color.green)
			return 'g';
		else if ( color == Color.red)
			return 'r';
		else if ( color == Color.blue)
			return 'b';
		else if ( color == ORANGE )
			return 'o';
		else if (color==Color.yellow )
			return 'y';
		else if (color==Color.white)
			return 'w';
		else
			return ' ';
	}
	
	bool searchInCorners(string x){
		for(int i=0;i<8;i++)
			if(Corners[i].name==x && Corners[i].flag){
				Corners[i].flag=false;
				return true;
			}
		return false;
	}
	
	
	static string OrderString(string str){
		char[] foo = str.ToArray();
		Array.Sort(foo);
		return new string(foo);
		}
	
	void FixedUpdate(){
		if(Input.GetMouseButtonDown (0)){
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(ray, out rayHit)){
				lastClicked = rayHit.collider.gameObject;
				if(lastClicked != null && OnClickChangeColor.flag==1 && lastClicked.GetComponent<Collider>().tag != "1"){
					x=OnClickChangeColor.myColor;// to color with color number x
					if(x==7){//clear
						lastClicked.gameObject.GetComponent<Renderer>().material.color =Color.gray;
						return;
					}
					if(ColorsArray[x].ColorFlag){
						ColorsArray[x].ColorCounter ++ ;
						if(ColorsArray[x].ColorCounter >8){ // can't color more than 8 times so subtract and activate the panel
							ColorsArray[x].ColorCounter -- ;
							ColorsArray[x].ColorFlag=false;
							PopUp.ThePanel.SetActive(true);
							return;
							}
						foreach (Transform child in lastClicked.transform.parent)
							if(lastClicked != child.gameObject && GetColor(child.gameObject) == x){ // neighbours can't have the same color
								ColorsArray[x].ColorCounter -- ;
								return;
							}
								
							// check the previous color to decrement its counter
								ColorNumber=GetColor(lastClicked);
								if(ColorNumber > 0 && ColorNumber < 7){
									ColorsArray[ColorNumber].ColorCounter -- ;
									ColorsArray[ColorNumber].GO.GetComponentInChildren<Text>().text=ColorsArray[ColorNumber].ColorCounter.ToString();
									if(ColorsArray[ColorNumber].ColorFlag == false)
										ColorsArray[ColorNumber].ColorFlag=true;
									}
								lastClicked.gameObject.GetComponent<Renderer>().material.color =ColorsArray[x].CurrentColor;
								ColorsArray[x].GO.GetComponentInChildren<Text>().text=ColorsArray[x].ColorCounter.ToString();																
								
								if(lastClicked.transform.parent.childCount==3 ){
									for(int i=0;i<3;i++){
										forNothing=GetC(lastClicked.transform.parent.GetChild(i).gameObject);
										if(forNothing == ' '){
											test="";
											return;
										}
										else{
											test+=forNothing;
											if(test.Length==3){
												
												print("test is "+test);
												if(!searchInCorners(OrderString(test))){
													print("error");
													lastClicked.transform.parent.GetChild(0).gameObject.GetComponentInChildren<TextMesh>().text="X";
													lastClicked.transform.parent.GetChild(1).gameObject.GetComponentInChildren<TextMesh>().text="X";
													lastClicked.transform.parent.GetChild(2).gameObject.GetComponentInChildren<TextMesh>().text="X";
												}
												else{
													print("success");
													lastClicked.transform.parent.GetChild(0).gameObject.GetComponentInChildren<TextMesh>().text="";
													lastClicked.transform.parent.GetChild(1).gameObject.GetComponentInChildren<TextMesh>().text="";
													lastClicked.transform.parent.GetChild(2).gameObject.GetComponentInChildren<TextMesh>().text="";
												}
											}
											
										}
									}
								}
								test="";
					}
					
				}
			}
		}
	}
}

