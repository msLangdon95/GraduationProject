using UnityEngine;
using System.Collections;
using UnityEngine.UI;    
public class RayCaster : MonoBehaviour {
	GameObject lastClicked;
     Ray ray;
     RaycastHit rayHit;
     void FixedUpdate(){
         if(Input.GetMouseButtonDown (0)){
             ray = Camera.main.ScreenPointToRay(Input.mousePosition);
             if(Physics.Raycast(ray, out rayHit)){
                 lastClicked = rayHit.collider.gameObject;
                 if(lastClicked != null){
                    print(lastClicked.name);
					if(OnClickChangeColor.flag==1){
						if(OnClickChangeColor.myColor == 1){ //green
							lastClicked.gameObject.GetComponent<Renderer>().materials[0].color = Color.green;
							}
						else if(OnClickChangeColor.myColor == 2){ //red
							lastClicked.gameObject.GetComponent<Renderer>().materials[0].color =  Color.red;
							}
						else if(OnClickChangeColor.myColor == 3){ //blue
							lastClicked.gameObject.GetComponent<Renderer>().materials[0].color =  Color.blue;
							}
						else if(OnClickChangeColor.myColor == 4){ //orange
							lastClicked.gameObject.GetComponent<Renderer>().materials[0].color = new Color(255,165,0);
							}
						else if(OnClickChangeColor.myColor == 5){ //yellow
							lastClicked.gameObject.GetComponent<Renderer>().materials[0].color =  Color.yellow;
							}
						else if(OnClickChangeColor.myColor == 6){ //white
							lastClicked.gameObject.GetComponent<Renderer>().materials[0].color =  Color.white;
							}
						}
				 }
             }
         }
     }
}