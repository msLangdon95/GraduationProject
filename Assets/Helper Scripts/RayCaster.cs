using UnityEngine;
using System.Collections;
using UnityEngine.UI;    
using System;
using System.Linq;
public class RayCaster : MonoBehaviour {
	public struct Combination{
		public bool flag;
		public string name;
	};
	int x,PrevColorNumber;
	GameObject lastClicked,PrevGameObj;
	Ray ray;
	RaycastHit rayHit;
	int ColorNumber;
	Color ORANGE;
	Combination [] Corners;
	Combination [] Edges;
	string test;
	char c1,c2,c3;
	void Start(){
		ColorNumber=0;
		PrevGameObj=null;
		PrevColorNumber=0;
		ORANGE=new Color(1,0.27058823529f,0,1);	
		Corners = new Combination[8];
		Edges = new Combination[12];
		
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
		
		Edges[0].name="by";
		Edges[0].flag=true;
		Edges[1].name="bo";
		Edges[1].flag=true;
		Edges[2].name="bw";
		Edges[2].flag=true;
		Edges[3].name="br";
		Edges[3].flag=true;
		Edges[4].name="oy";
		Edges[4].flag=true;
		Edges[5].name="ow";
		Edges[5].flag=true;
		Edges[6].name="rw";
		Edges[6].flag=true;
		Edges[7].name="ry";
		Edges[7].flag=true;
		Edges[8].name="go";
		Edges[8].flag=true;
		Edges[9].name="gy";
		Edges[9].flag=true;
		Edges[10].name="gr";
		Edges[10].flag=true;
		Edges[11].name="gw";
		Edges[11].flag=true;
	}
	
	int GetColor(GameObject G){
		Color color = G.gameObject.GetComponent<Renderer> ().material.color;
		if ( color == Color.green)
			return 0;
		else if ( color == Color.red)
			return 1;
		else if ( color == Color.blue)
			return 2;
		else if ( color == ORANGE )
			return 3;
		else if (color==Color.yellow )
			return 4;
		else if (color==Color.white)
			return 5;
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
	
	bool searchInEdges(string x){
		for(int i=0;i<12;i++)
		if(Edges[i].name==x && Edges[i].flag){
			Edges[i].flag=false;
			return true;
		}
		return false;
	}
	
	static string OrderString(string str){
		char[] foo = str.ToArray();
		Array.Sort(foo);
		return new string(foo);
	}
	bool IfCornersOrEdgesAndPaintedReturnStr(GameObject obj, ref string str,int x){
		if(x==3 ){
			str="";
			c1=GetC(obj.transform.parent.GetChild(0).gameObject);
			c2=GetC(obj.transform.parent.GetChild(1).gameObject);
			c3=GetC(obj.transform.parent.GetChild(2).gameObject);
			if(c1 != ' ' && c2 != ' ' && c3 != ' '){
				str+=c1;
				str+=c2;
				str+=c3;
				str=OrderString(str);
				return true;
			}
		}
		else if(x==2){
			str="";
			c1=GetC(obj.transform.parent.GetChild(0).gameObject);
			c2=GetC(obj.transform.parent.GetChild(1).gameObject);
			if(c1 != ' ' && c2 != ' '){
				str+=c1;
				str+=c2;
				str=OrderString(str);
				return true;
			}
		}		
		return false; // if not corners or corners but not fully colored
	}
	
	void FixedUpdate(){
		if(Input.GetMouseButtonDown (0)){
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(ray, out rayHit)){
				lastClicked = rayHit.collider.gameObject;
				if(lastClicked != null && OnClickChangeColor.flag==1 && lastClicked.GetComponent<Collider>().tag != "1" ){
					x=OnClickChangeColor.myColor;// to color with color number x
					if(x != PrevColorNumber || PrevGameObj != lastClicked){
						/*if(x==7){//clear
						lastClicked.gameObject.GetComponent<Renderer>().material.color =Color.gray;
						return;
					}*/
						if(Globals.ColorsArray[x].ColorFlag){
							Globals.ColorsArray[x].ColorCounter ++ ;
							if(Globals.ColorsArray[x].ColorCounter >8){ // can't color more than 8 times so subtract and activate the panel
								Globals.ColorsArray[x].ColorCounter -- ;
								Globals.ColorsArray[x].ColorFlag=false;
								PopUp.ThePanel.SetActive(true);
								return;
							}
							foreach (Transform child in lastClicked.transform.parent)
							if(lastClicked != child.gameObject && GetColor(child.gameObject) == x){ // neighbours can't have the same color
								Globals.ColorsArray[x].ColorCounter -- ;
								return;
							}
							
							// check the previous color to decrement its counter
							ColorNumber=GetColor(lastClicked);
							if(ColorNumber >= 0 && ColorNumber < 6){
								Globals.ColorsArray[ColorNumber].ColorCounter -- ;
								Globals.ColorsArray[ColorNumber].GO.GetComponentInChildren<Text>().text=Globals.ColorsArray[ColorNumber].ColorCounter.ToString();
								if(Globals.ColorsArray[ColorNumber].ColorFlag == false)
									Globals.ColorsArray[ColorNumber].ColorFlag=true;
							}
							//if it was a corner + mwjod 2bl+false->true
							if(lastClicked.transform.parent.childCount == 3 && IfCornersOrEdgesAndPaintedReturnStr(lastClicked,ref test,3)){
								for(int i=0;i<8;i++)
								if(Corners[i].name==test && !Corners[i].flag){
									Corners[i].flag=true;
									break;
								}
							}
							//else if it was an edge+mwjod+false -> true
							else if(lastClicked.transform.parent.childCount == 2 && IfCornersOrEdgesAndPaintedReturnStr(lastClicked,ref test,2)){
								for(int i=0;i<12;i++)
								if(Edges[i].name==test && !Edges[i].flag){
									Edges[i].flag=true;
									break;
								}
							}
							
							lastClicked.gameObject.GetComponent<Renderer>().material.color =Globals.ColorsArray[x].CurrentColor;
							Globals.ColorsArray[x].GO.GetComponentInChildren<Text>().text=Globals.ColorsArray[x].ColorCounter.ToString();	
							if(lastClicked.transform.parent.childCount == 3 && IfCornersOrEdgesAndPaintedReturnStr(lastClicked,ref test,3)){ // verify new colored corner
								print(test);
								if(!searchInCorners(test)){
									print("error");
									for(int i=0;i<3;i++)
										lastClicked.transform.parent.GetChild(i).gameObject.GetComponentInChildren<TextMesh>().text="X";
								}
								else{
									print("success");
									for(int i=0;i<3;i++)
										lastClicked.transform.parent.GetChild(i).gameObject.GetComponentInChildren<TextMesh>().text="";
								}
							}
							//verify new colored edges
							if(lastClicked.transform.parent.childCount == 2 && IfCornersOrEdgesAndPaintedReturnStr(lastClicked,ref test,2)){ // verify new colored corner
								print(test);
								if(!searchInEdges(test)){
									print("error");
									for(int i=0;i<2;i++)
										lastClicked.transform.parent.GetChild(i).gameObject.GetComponentInChildren<TextMesh>().text="X";
								}
								else{
									print("success");
									for(int i=0;i<2;i++)
										lastClicked.transform.parent.GetChild(i).gameObject.GetComponentInChildren<TextMesh>().text="";
								}
							}
							
						}
					}
					PrevColorNumber=x;
					PrevGameObj=lastClicked;
				}
			}
		}
	}
}