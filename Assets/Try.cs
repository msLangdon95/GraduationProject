 using UnityEngine;
 using System.Collections;
 public class Try : MonoBehaviour
 {
     public Transform target;
     public float distance = 0.0f;
     public float xSpeed = 360.0f;
     public float ySpeed = 120.0f;
     public float yMinLimit = 20f;
     public float yMaxLimit = 85f;
     private float x = 0.0f;
     private float y = 0.0f;

     void Start(){
         var angles = transform.eulerAngles;
         x = angles.y;
         y = angles.x;
		 distance = (transform.position - target.position).magnitude;
     }
     
     void Update(){
		 var dt = Time.deltaTime;
		 if (Input.GetMouseButton(0)){
			 x += Input.GetAxis("Mouse X") * xSpeed * dt;
			 y -= Input.GetAxis("Mouse Y") * ySpeed * dt;
			 y = ClampAngle(y, yMinLimit, yMaxLimit);
			 var rotation = Quaternion.Euler(y, x, 0f);
			 var position = rotation * new Vector3(0.0f, 0.0f, -distance) + target.position;
			 transform.rotation = rotation;
			 transform.position = position;
			 }
		 }
     
	 
     static float ClampAngle (float angle, float min, float max){
         if (angle < -360f)
             angle += 360f;
         if (angle > 360f)
             angle -= 360f;
         return Mathf.Clamp (angle, min, max);
     }
 }