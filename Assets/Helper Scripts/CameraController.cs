using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
	public static WebCamTexture mCamera = null;
	public static GameObject plane;
	public Shader shader1;
    public Renderer rend;
	void Start (){
		plane = GameObject.FindWithTag ("Player");
		mCamera = new WebCamTexture ();
		plane.GetComponent<Renderer>().material.mainTexture = mCamera;
		mCamera.Play ();
		
		rend = GetComponent<Renderer>();
        shader1 = Shader.Find("UI/Default");
		rend.material.shader = shader1;
	}
	void Update(){
	}
}