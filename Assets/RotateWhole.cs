using UnityEngine;
 using System.Collections;
 
 public class RotateWhole : MonoBehaviour {
 
     float f_lastX = 0.0f;
     float f_difX = 0.5f;
     float f_steps = 0.0f;
     int i_direction = 1;
 
     // Use this for initialization
     void Start () 
     {
         
     }
     
     // Update is called once per frame
     void Update () 
     {
         if (Input.GetMouseButtonDown(0))
         {
             f_difX = 0.0f;
         }
         else if (Input.GetMouseButton(0))
         {
             f_difX = Mathf.Abs(f_lastX - Input.GetAxis ("Mouse X"));
 
             if (f_lastX < Input.GetAxis ("Mouse X"))
             {
                 i_direction = -1;
                 transform.Rotate(Vector3.up, -f_difX);
             }
 
             if (f_lastX > Input.GetAxis ("Mouse X"))
             {
                 i_direction = 1;
                 transform.Rotate(Vector3.up, f_difX);
             }
 
             f_lastX = -Input.GetAxis ("Mouse X");
         }
        /* else 
         {
             if (f_difX > 0.5f) f_difX -= 0.05f;
             if (f_difX < 0.5f) f_difX += 0.05f;
 
             transform.Rotate(Vector3.up, f_difX * i_direction);
         }*/
     }
 }
/*using UnityEngine;
using System.Collections;
public class LOL : MonoBehaviour{
	private float _sensitivity;
	private float _sensitivitx;
	private Vector3 _mouseReference;
	private Vector3 _mouseOffset;
	private Vector3 _rotation;
	private bool _isRotating;
	
	void OnMouseDown()
	{
		// rotating flag
		_isRotating = true;
		
		// store mouse
		_mouseReference = Input.mousePosition;
		_isRotating=false;
	}
	
	void OnMouseUp()
	{
		// rotating flag
		_isRotating = false;
	}
	void Start ()
	{
		_sensitivity = 0.4f;
		_sensitivitx = 0.4f;
		_rotation = Vector3.zero;
	}
	
	void Update()
	{
		if(_isRotating)
		{
			// offset
			_mouseOffset = (Input.mousePosition - _mouseReference);
			
			// apply rotation
			_rotation.y = -(_mouseOffset.x + _mouseOffset.y) * _sensitivity;
			_rotation.x = -(_mouseOffset.x + _mouseOffset.y) * _sensitivitx;
			// rotate
			transform.Rotate(_rotation);
			
			// store mouse
			_mouseReference = Input.mousePosition;
		}
	}
	
	
}*/