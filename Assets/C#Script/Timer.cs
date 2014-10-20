using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {
	
	int time;

	// Use this for initialization
	void Start () {
		time = 300;
	}
	
	// Update is called once per frame
	void Update () {
		if(time > 0){
			time--;
			if(time <= 0){
				Application.LoadLevel(3);
			}
		}
		
		string timeText = (time / 60).ToString() + ".";
		int comTime = time - (time / 60) * 60;
		comTime = (int)(comTime / 3f * 5f);
		if(comTime < 10){
			timeText += "0";
		}
		transform.guiText.text = timeText + comTime.ToString();
	}
}
