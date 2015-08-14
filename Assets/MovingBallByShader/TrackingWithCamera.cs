using UnityEngine;
using System.Collections;

public class TrackingWithCamera : MonoBehaviour {

	public Material material;
	public string shaderPositionName = "_Position";
	public float distance = 10.0f;
	
	private Camera thisCamera;
	
	
	// Use this for initialization
	void Start () {
		thisCamera = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		var screen = Input.mousePosition;
        screen.z = distance;
        var world = thisCamera.ScreenToWorldPoint(screen);
		Debug.Log(world);
        material.SetVector(shaderPositionName, world);
	}
}
