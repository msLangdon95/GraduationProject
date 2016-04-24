 using UnityEngine;
 using System.Collections;
 public class RotateCamera : MonoBehaviour
 {
     public Transform target;
     public float distance;
     public float xSpeed = 250.0f;
     public float ySpeed = 550.0f;
     public float yMinLimit = 80f;
     public float yMaxLimit = 80f;
     private float x = 0.0f;
     private float y = 0.0f;
     Ray ray;
	 RaycastHit rayHit;
	 GameObject lastClicked;
     
     void Start()
     {
         var angles = transform.eulerAngles;
         x = angles.y;
         y = angles.x;
		 distance = (transform.position - target.position).magnitude;
         // Make the rigid body not change rotation
            if (GetComponent<Rigidbody>())
             GetComponent<Rigidbody>().freezeRotation = true;
		  transform.rotation =Quaternion.Euler(-1.2583486f,7.4292461f,-0.129597f);
		 // transform.position =new Vector3(1689.247f, 932.0135f,-1224.659f);
     }
     
     void LateUpdate()
     {
		 ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		 if(Physics.Raycast(ray, out rayHit)){
			lastClicked = rayHit.collider.gameObject;
			if(lastClicked!=null){
				return;
				}
			}
         if (target != null && Input.GetMouseButton(0))
         {
             x += Input.GetAxis("Mouse X") * xSpeed * 0.04f;
             y -= Input.GetAxis("Mouse Y") * ySpeed * 0.04f;
             
             y = ClampAngle(y, -30f, 80f);
             
             var rotation = Quaternion.Euler(y, x, 0f);
             var position = rotation * new Vector3(0.0f, 0.0f, -distance) + target.position;
             
             transform.rotation = rotation;
			// print("rotation is "+ rotation.x+" "+rotation.y+" "+rotation.z);
             transform.position = position;
			// print("position is "+ position.x+" "+position.y+" "+position.z);
         }
     }
 
     static float ClampAngle (float angle, float min, float max)
     {
         if (angle < -360f)
             angle += 360f;
         if (angle > 360f)
             angle -= 360f;
         return Mathf.Clamp (angle, min, max);
     }
 }