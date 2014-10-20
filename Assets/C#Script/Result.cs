using UnityEngine;
using System.Collections;

public class Result : MonoBehaviour {
	
	public static bool clearFlg = false;
	
	public GameObject Clear;
	public GameObject Miss;
	public GameObject Zura;
	
	float len = 0.25f;
	float pi = 3.14159245358979f;

	// Use this for initialization
	void Start () {
		Debug.Log("Result");
		if(clearFlg == true){
			Instantiate(Clear);
		}
		else{
			Instantiate(Miss);
			GameObject zura1 = (GameObject)Instantiate(Zura, new Vector3(0, 4.5f, 0), Quaternion.identity);
			Vector3 pos = zura1.transform.position;
			
			float rot = pi / 3f / Kohtyoh.zura_MAX * Kohtyoh.zura;
			zura1.transform.GetChild(0).position = new Vector3(
				pos.x + len * Mathf.Cos(rot + pi/2),
				pos.y + len * Mathf.Sin(rot + pi/2),
				pos.z);
			zura1.transform.GetChild(0).rotation
				= Quaternion.Euler(new Vector3(0, 180, -60 / Kohtyoh.zura_MAX * Kohtyoh.zura));
		}
		
		clearFlg  = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.RightControl)){
			Application.LoadLevel(0);
		}
		if(Input.GetKeyDown(KeyCode.LeftControl)){
			Application.LoadLevel(2);
		}
	}
}
