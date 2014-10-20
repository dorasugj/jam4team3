using UnityEngine;
using System.Collections;

public class Description : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log("Description");
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl)){
			Application.LoadLevel(2);
		}
	}
}
