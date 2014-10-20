using UnityEngine;
using System.Collections;

public class Kohtyoh : MonoBehaviour {
	
	public static float	zura		= 0;
	public static float	zura_MAX	= 100;
	
	bool	fall		= false;
	float	fallSpeed	= 0.3f;
	float	studentL	= 0,
			studentR	= 0;
	
	float mul = 1.2f;
	float len = 0.25f;
	float pi = 3.14159245358979f;
	Vector3 pos;
	Vector3 zura_pos;
	

	// Use this for initialization
	void Start () {
		Debug.Log("Game");
		zura	= 0;
		
		pos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.LeftControl)){
			Fukareru(new float[]{10.0f,0.0f});
		}
		
		if(fall == true){
			zura_pos = transform.GetChild(0).transform.position;
			zura_pos.x -= 0.2f;
			zura_pos.y += 0.1f;
			transform.GetChild(0).transform.position = zura_pos;
			
			transform.GetChild(0).Translate(fallSpeed, fallSpeed * 1.0f, 0);
			transform.GetChild(0).Rotate(0,0,30);
		}
	}
	
	void Fukareru(float[] power){
		if(zura < zura_MAX){
			if(power[0] * power[1] > 0){
				zura += (power[0] + power[1]) * mul;
			}
			else{
				zura += power[0] + power[1];
			}
			
			float rot = pi / 3f / zura_MAX * zura;
			transform.GetChild(0).position = new Vector3(
				pos.x + len * Mathf.Cos(rot + pi/2),
				pos.y + len * Mathf.Sin(rot + pi/2),
				pos.z);
			transform.GetChild(0).rotation = Quaternion.Euler(0, 180, -60 / zura_MAX * zura);
			
			//hukitobu
			if(zura >= zura_MAX){
				Result.clearFlg = true;
				transform.GetChild(0).position = new Vector3(
				pos.x + -len,
				pos.y,
				pos.z);
				transform.GetChild(0).rotation = Quaternion.Euler(0, 180, -60);
				fall = true;
			}
		}
	}
}
