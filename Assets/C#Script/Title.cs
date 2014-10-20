using UnityEngine;
using System.Collections;

public class Title : MonoBehaviour {
	
	int cl = 0, cr = 0;

	// Use this for initialization
	void Start () {
		Debug.Log("Title");
	}
	
	// Update is called once per frame
	void Update () {
		if(cl * cr > 0){
			Application.LoadLevel(1);
		}
		
		if(cl > 0){
			cl--;
		}
		else if(Input.GetKeyDown(KeyCode.LeftControl)){
			cl = 10;
		}
		
		if(cr > 0){
			cr--;
		}
		else if(Input.GetKeyDown(KeyCode.RightControl)){
			cr = 10;
		}
	}
}
