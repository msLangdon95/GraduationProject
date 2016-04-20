using UnityEngine;
 using System.Collections;
 
 [AddComponentMenu("Camera-Control/Mouse Orbit")]
 public class RotateCamera : MonoBehaviour
 {
     public Transform target;
     public float distance = 10.0f;
     
     public float xSpeed = 250.0f;
     public float ySpeed = 120.0f;
     
     public float yMinLimit = -20f;
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
		//print(distance);
         // Make the rigid body not change rotation
            if (GetComponent<Rigidbody>())
             GetComponent<Rigidbody>().freezeRotation = true;
		var rotation = Quaternion.Euler(y, x, 0f);
		var position = rotation * new Vector3(0.0f, 0.0f, -distance) + target.position;
		transform.rotation = rotation;
		transform.position = position;
     }
     
   void LateUpdate(){
         if (target != null && Input.GetMouseButton(0))
         {
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(ray, out rayHit)){
				lastClicked = rayHit.collider.gameObject;
				if(lastClicked.transform.parent.parent.name=="RubiksCube"){
					return;
				}
			}
					x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
					y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
					y = ClampAngle(y, yMinLimit, yMaxLimit);
					var rotation = Quaternion.Euler(y, x, 0f);
					var position = rotation * new Vector3(0.0f, 0.0f, -distance) + target.position;
					transform.rotation = rotation;
					transform.position = position;
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