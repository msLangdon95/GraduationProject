using UnityEngine;
using System.Collections;
using System.Collections.Generic;

 public class RotateWhole : MonoBehaviour {
     float f_lastX = 0.0f;
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
			 if (f_lastY < Input.GetAxis ("Mouse Y")){
                 transform.Rotate(Vector3.back, f_difY);
             } 
			 if (f_lastY > Input.GetAxis ("Mouse Y")){
                 transform.Rotate(Vector3.left, f_difY);
             }
 
             f_lastX = -Input.GetAxis ("Mouse X");
			 f_lastY = -Input.GetAxis ("Mouse Y");
         }
     }
 }