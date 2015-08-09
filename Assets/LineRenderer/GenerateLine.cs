// caution: Camera projection type must be Orthographic


using UnityEngine;
using System.Collections;

public class GenerateLine : MonoBehaviour{

	public Material material;
	public float lineWidth;
	private LineRenderer line; 
	private int currLines = 0;

	public Vector3 getMousePositionWorld() {
		Vector3 screen = Input.mousePosition;
		screen.z = 0;
		Vector3 world = Camera.main.ScreenToWorldPoint (screen);
		world.z = 0;
		//Debug.LogFormat( screen +  "->" + world);
		return world;
	}
	
	void Update (){
		if(Input.GetMouseButtonDown(0)){
			if(line == null){
				createLine();
			}
			Vector3 position =  getMousePositionWorld();
			line.SetPosition(0, position);
			line.SetPosition(1, position);
		}
		else if(Input.GetMouseButtonUp(0) && line){
			Vector3 position =  getMousePositionWorld();
			line.SetPosition(1, position);
			line = null;
			currLines++;
		}
		else if(Input.GetMouseButton(0) && line){
			Vector3 position =  getMousePositionWorld();
			line.SetPosition(1, position);
		}
	}

	private void createLine(){
		line = new GameObject("Line" + currLines).AddComponent<LineRenderer>();
		line.material =  material;
		line.SetVertexCount(2);
		line.SetWidth(lineWidth, lineWidth);
		line.useWorldSpace = true;  
	}
}
