var sensitivityX:float = 1;
var sensitivityY:float = 1;

//Camera that acts as a point of view to rotate the object relative to.
var referenceCamera:Transform;

//The script in Start() is executed before Update(), so we can use it to
//doublecheck our variables have valid values before we try to run the script in Update().
function Start() {

	//Ensure the referenceCamera variable has a valid value before letting this script run.
	//If the user didn't set a camera manually, try to automatically assign the scene's Main Camera.
	if (!referenceCamera) {
		if (!Camera.main) {
			Debug.LogError("No Camera with 'Main Camera' as its tag was found. Please either assign a Camera to this script, or change a Camera's tag to 'Main Camera'.");
			Destroy(this);
			return;
		}
		referenceCamera = Camera.main.transform;
	}
}

//Update() is called once every frame, and should be used to run script that
//should be doing something constantly. In this case, we potentially want to
//rotate the object constantly if the user is always moving the mouse.
function Update(){

	//Get how far the mouse has moved by using the Input.GetAxis().
	var rotationX:float = Input.GetAxis("Mouse X") * sensitivityX;
	var rotationY:float = Input.GetAxis("Mouse Y") * sensitivityY;

	//Rotate the object around the camera's "up" axis, and the camera's "right" axis.
	transform.RotateAroundLocal( referenceCamera.up		, -Mathf.Deg2Rad * rotationX );
	transform.RotateAroundLocal( referenceCamera.right	,  Mathf.Deg2Rad * rotationY );

}
/*
var targetItem : GameObject;
 var GUICamera : Camera;
 var ambient : GameObject;
 
 
 
 var rotationRate : float = 1.0;
 private var wasRotating;
 
 private var scrollPosition : Vector2 = Vector2.zero;
 private var scrollVelocity : float = 0;
 private var timeTouchPhaseEnded: float;
 private var inertiaDuration : float = 0.5f;
 
 private var itemInertiaDuration : float = 1.0f;
 private var itemTimeTouchPhaseEnded: float;
 private var rotateVelocityX : float = 0;
 private var rotateVelocityY : float = 0;
 
 
 var hit: RaycastHit;
 
 private var layerMask = (1 <<  8) | (1 << 2);
 //private var layerMask = (1 <<  0);
 
 
 function Start()
 {
     layerMask =~ layerMask;    
 }
 
 function FixedUpdate()
 {
     
     if (Input.touchCount > 0) 
     {        //    If there are touches...
             var theTouch : Touch = Input.GetTouch(0);        //    Cache Touch (0)
             
             var ray = Camera.main.ScreenPointToRay(theTouch.position);
             var GUIRayq = GUICamera.ScreenPointToRay(theTouch.position);
             
                 
              if(Physics.Raycast(ray,hit,50,layerMask))
              {    
 
                 if(Input.touchCount == 1)
                         {
                             
                             if (theTouch.phase == TouchPhase.Began) 
                              {
                                  wasRotating = false;    
                              }        
                              
                              if (theTouch.phase == TouchPhase.Moved) 
                              {
                                   
                                  targetItem.transform.Rotate(0, theTouch.deltaPosition.x * rotationRate,0,Space.World);
                                  wasRotating = true;
                              }        
              
             }
 
 
             
                         
             
     }}
 }
 */