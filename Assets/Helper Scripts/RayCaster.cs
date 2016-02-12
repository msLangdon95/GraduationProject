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
                 if(lastClicked != null)
                     print(lastClicked.name);
             }
         }
     }
}