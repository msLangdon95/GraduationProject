using UnityEngine;
using System.Collections;
using UnityEngine.UI;    
public class RayCaster : MonoBehaviour {
	GameObject lastClicked;
     Ray ray;
     RaycastHit rayHit;
	 int [] ColorsCount;
	 
	 void Start(){
		 ColorsCount=new int[7];
		 for(int i=1;i<7;i++)
			 ColorsCount[i]=0;
	 }
	 //int GetColor(){
		// lastClicked.gameObject.GetComponent<Renderer>().materials[ColorFlag].color; -> gives you current color;
		//it returns a gameObject of type Color, for instance for green, it returns (0,1,0,1);
		//you have to deal with this gameobject and return 1 for green, 2 for red, 3 for blue, 4 for orange, 5 for yellow, 6 for white
	 //}
     void FixedUpdate(){
         if(Input.GetMouseButtonDown (0)){
             ray = Camera.main.ScreenPointToRay(Input.mousePosition);
             if(Physics.Raycast(ray, out rayHit)){
                 lastClicked = rayHit.collider.gameObject;
                 if(lastClicked != null && lastClicked.tag !="1"){ // ADD TAGS TO ALL BOXES .. tag 0 means that it is a regular box, tag 1 means that it's reference box
                    print(lastClicked.name);
					if(OnClickChangeColor.flag==1){
						if(OnClickChangeColor.myColor == 1){ //green
							// int ColorNumber=GetColor();
							// ColorsCount[ColorNumber] --;
							//ColorsCount[1] ++ ;
							// which means, decrement previous color count and increment green's count
							// then, find a way to display the changed two colors (green and old color) on the color palette 
							lastClicked.gameObject.GetComponent<Renderer>().materials[1].color = Color.green;
							}
						else if(OnClickChangeColor.myColor == 2){ //red
							lastClicked.gameObject.GetComponent<Renderer>().materials[1].color =  Color.red;
							}
						else if(OnClickChangeColor.myColor == 3){ //blue
							lastClicked.gameObject.GetComponent<Renderer>().materials[1].color =  Color.blue;
							}
						else if(OnClickChangeColor.myColor == 4){ //orange
							lastClicked.gameObject.GetComponent<Renderer>().materials[1].color = new Color(1,0.27058823529f,0,1);
							}
						else if(OnClickChangeColor.myColor == 5){ //yellow
							lastClicked.gameObject.GetComponent<Renderer>().materials[1].color =  Color.yellow;
							}
						else if(OnClickChangeColor.myColor == 6){ //white
							lastClicked.gameObject.GetComponent<Renderer>().materials[1].color =  Color.white;
							}
						}
				 }
             }
         }
     }
}