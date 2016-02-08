using UnityEngine;
using System.Collections;

public class ChooseColor : MonoBehaviour {

	void Start () {
	}
	void Update(){
		UpdateMouse();
	}

	void UpdateMouse(){
		if (Input.GetMouseButtonDown(0)){
			Vector2 worldPoint=Camera.main.ScreenToWorldPoint(Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
		if(hit && hit.collider.name == "green"){
				GetComponent<SpriteRenderer>().material.color= Color.green;
			}
		if(hit && hit.collider.name == "blue"){
				GetComponent<SpriteRenderer>().material.color= Color.blue;
			}
		if(hit && hit.collider.name == "yellow"){
				GetComponent<SpriteRenderer>().material.color= Color.yellow;
			}
		if(hit && hit.collider.name == "white"){
				GetComponent<SpriteRenderer>().material.color= Color.white;
			}
		if(hit && hit.collider.name == "red"){
				GetComponent<SpriteRenderer>().material.color= Color.red;
			}
		if(hit && hit.collider.name == "orange"){
				GetComponent<SpriteRenderer>().material.color= new Color(30,255,255);
			}
		}
	}
}





