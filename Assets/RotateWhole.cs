using UnityEngine;
using System.Collections;
using System.Collections.Generic;

 public class RotateWhole : MonoBehaviour {
	/* public GameObject target;// var target : Transform;
	 float edgeBorder = 0.1f;
	 float horizontalSpeed = 360.0f;
	 float verticalSpeed = 120.0f;
	 float minVertical = 20.0f;
	 float maxVertical = 85.0f;
	 float  x = 0.0f;
	 float y = 0.0f;
	 float  distance = 0.0f;
	 
	 void Start(){
		 x = transform.eulerAngles.y;
		 y = transform.eulerAngles.x;
		 distance = Camera.mainCamera.gameObject.transform.position - target.transform.position;
	 }
	 void Update(){
	 }*/
	 
	 
	 
	/*  public GameObject target;//the target object
		private float speedMod = 10.0f;//a speed modifier
		private Vector3 point;//the coord to the point where the camera looks at
   
    void Start () {//Set up things on the start method
        point = target.transform.position;//get target's coords
        transform.LookAt(point);//makes the camera look to it
    }
   
    void Update () {//makes the camera rotate around "point" coords, rotating around its Y axis, 20 degrees per second times the speed modifier
        transform.RotateAround (point,new Vector3(0.0f,1.0f,0.0f),20 * Time.deltaTime * speedMod);
    }
 */
    /* float f_lastX = 0.0f;
	 float f_lastY = 0.0f;
     float f_difX = 0.5f;
	 float f_difY=0.5f;
     float f_steps = 0.0f;
	 public GameObject target;//the target object
	 private float speedMod = 10.0f;//a speed modifier
	 private Vector3 point;//the coord to the point where the camera looks at
     void Start () 
     {
          point = target.transform.position;//get target's coords
         // transform.LookAt(point);//makes the camera look to it
     }
     void Update () 
     {
         if (Input.GetMouseButtonDown(0))
         {
             f_difX = 0.0f;
	     f_difY=0.0f;
         }
         else if (Input.GetMouseButton(0))
         {
             f_difX = Mathf.Abs(f_lastX - Input.GetAxis ("Mouse X"));
	     f_difY= Mathf.Abs(f_lastY - Input.GetAxis ("Mouse Y"));
             if (f_lastX < Input.GetAxis ("Mouse X")){
		     transform.RotateAround (point, Vector3.up, 1);
             }
	     if (f_lastX > Input.GetAxis ("Mouse X")){
                transform.RotateAround (point, Vector3.up, -1);
             }
			 /*
			 if (f_lastY < Input.GetAxis ("Mouse Y")){
                 transform.Rotate(Vector3.back, f_difY);
             }
			/* if (f_lastZ < Input.GetAxis ("Mouse ScrollWheel"))
             {
                 transform.Rotate(Vector3.up, -f_difZ);
             }
			 */	 
             
			/* if (f_lastY > Input.GetAxis ("Mouse Y")){
                 transform.Rotate(Vector3.left, f_difY);
             }*/
			 /*if (f_lastZ > Input.GetAxis ("Mouse ScrollWheel"))
             {
                 i_direction = 1;
                 transform.Rotate(Vector3.left, f_difZ);
             }
 
             f_lastX = -Input.GetAxis ("Mouse X");
			 f_lastY = -Input.GetAxis ("Mouse Y");
         }
     }*/
 }