using UnityEngine; using System.Collections;

 
public class MshanAllah : MonoBehaviour {
	
	
	
	public Transform target;
     public float distance = 0.0f;
     public float xSpeed = 360.0f;
     public float ySpeed = 120.0f;
     public float yMinLimit = 20f;
     public float yMaxLimit = 85f;
     private float x = 0.0f;
     private float y = 0.0f;
	 
	 float f_lastX = 0.0f;
	 float f_lastY = 0.0f;
     float f_difX = 0.5f;
	 float f_difY=0.5f;
     void Start(){
         var angles = transform.eulerAngles;
         x = angles.y;
         y = angles.x;
		 distance = (transform.position - target.position).magnitude;
     }
     
     void Update(){
		 var dt = Time.deltaTime;
			 f_difX = Mathf.Abs(f_lastX - Input.GetAxis ("Horizontal"));
			 f_difY= Mathf.Abs(f_lastY - Input.GetAxis ("Vertical"));
             if (f_lastX < Input.GetAxis ("Mouse X") || f_lastX > Input.GetAxis ("Mouse X") || f_lastY < Input.GetAxis ("Mouse Y") || f_lastY > Input.GetAxis ("Mouse Y")){
				x += Input.GetAxis("Mouse X") * xSpeed * dt;
				y -= Input.GetAxis("Mouse Y") * ySpeed * dt;
				y = ClampAngle(y, yMinLimit, yMaxLimit);
				var rotation = Quaternion.Euler(y, x, 0f);
				var position = rotation * new Vector3(0.0f, 0.0f, -distance) + target.position;
				transform.rotation = rotation;
				transform.position = position;
			 }
			 f_lastX = -Input.GetAxis ("Mouse X");
			 f_lastY = -Input.GetAxis ("Mouse Y");
		 
	 }
     
	 
     static float ClampAngle (float angle, float min, float max){
         if (angle < -360f)
             angle += 360f;
         if (angle > 360f)
             angle -= 360f;
         return Mathf.Clamp (angle, min, max);
     }
	
	
	
	
	/*public Transform target; 
	public float distance = 0.0f; 
	public float xSpeed = 250.0f; 
	public float ySpeed = 120.0f; 
	public float yMinLimit = -20f;
	public float yMaxLimit = 80f; 
	public float zoomSpeed = 120.0f;
	private float x = 0.0f; 
	private float y = .0f;
	public bool zoom;

 
 void Start () {
     Vector3 angles = transform.eulerAngles;
     x = angles.y;
     y = angles.x;
     // Make the rigid body not change rotation
        if (GetComponent<Rigidbody>()) {
         GetComponent<Rigidbody>().freezeRotation = true;
         }
		 distance = (transform.position - target.position).magnitude;
     }
 
 void LateUpdate () {
 if (target) {
     x += (float)(Input.GetAxis("Horizontal") * xSpeed * 0.02);
     y += (float)(Input.GetAxis("Vertical") * zoomSpeed * 0.02);
     y = ClampAngle(y, yMinLimit, yMaxLimit);
             
     Quaternion rotation = Quaternion.Euler(y, x, 0);
     Vector3 position = rotation * new Vector3(-distance/1.3f, distance/5, -distance/2) + target.position;
     
     transform.rotation = rotation;
     transform.position = position;
     }
 }
 private int ClampAngle (float angle, float min, float max) {
     if (angle < -360){
         angle += 360;
     }
         if (angle > 360){
         angle -= 360;
     }
     return Mathf.Clamp ((int)(angle), (int)(min), (int)(max));
 }
 */
} 