using UnityEngine;
using System.Collections;

public class Student : MonoBehaviour {
	
	public GameObject []Prefab;
	private GameObject[] Player;
	public const int nMAX_PLAYER = 2;
	public const float fMAX_GAUGE = 100.0f;
	private Vector3[] Pos;
	private Vector3[] BlowPos;
	public float[] fGauge;
	public float[] fTimerGauge;
	private GameObject[] Blow;
	private Material Mat;
	private Color color;
	public Texture[] TexList = new Texture[6];
	private const string TexName = "Tex/CharaRight01";
	
	// Use this for initialization
	void Start () {
		Pos = new Vector3[nMAX_PLAYER];
		Player = new GameObject[nMAX_PLAYER];
		fGauge = new float[nMAX_PLAYER]{0.0f, 0.0f};
		Blow = new GameObject[nMAX_PLAYER];
		fTimerGauge = new float[nMAX_PLAYER]{0.0f, 0.0f};
		BlowPos = new Vector3[nMAX_PLAYER];
		//Prefab = new GameObject[nMAX_PLAYER];
		//Tex = Texture.
		
		for(int nCnt = 0; nCnt < nMAX_PLAYER; nCnt ++){
			Pos[nCnt] = new Vector3(-3.0f + (nCnt * 6.0f), -2.0f , -10.0f);
			BlowPos[nCnt] = new Vector3(-3.0f + (nCnt * 6.0f), 0.7f , -10.0f);
		}
		
		Quaternion Rot = Quaternion.Euler(90.0f, 180.0f, 0.0f);
		//Quaternion Rot = Quaternion.AngleAxis(-90.0f, new Vector3(1.0f, 0.0f, 0.0f));
		//Quaternion Rot2 = Quaternion.AngleAxis(90.0f, new Vector3(0.0f, 0.0f, 1.0f));
		//Rot = Quaternion.Slerp(Rot, Rot2, 1.0f);
		//Prefab[0] = (GameObject)Resources.Load("Student");
		//Prefab[1] = (GameObject)Resources.Load("Blow");
		
		for(int nCnt = 0; nCnt < nMAX_PLAYER; nCnt ++){
			Player[nCnt] = (GameObject)Instantiate(Prefab[0], Pos[nCnt], Rot);
			Blow[nCnt] = (GameObject)Instantiate(Prefab[1], BlowPos[nCnt], Rot);
			
		}
		//color = Prefab[1].renderer.material.color;
		color.a = 0.0f;
		color.r = 1.0f;
		color.g = 1.0f;
		color.b = 1.0f;
		
		Player[1].renderer.material.mainTexture = TexList[2];
		Player[0].renderer.material.mainTexture = TexList[0];
		Player[0].transform.localScale = new Vector3(0.334f,1,0.895f);
		Player[0].transform.position = new Vector3(-3.35f,-3,-10);
		
		Player[1].transform.localScale = new Vector3(0.334f,1,0.895f);
		Player[1].transform.position = new Vector3(3.35f,-3,-10);
		
		Blow[0].renderer.material.mainTexture = TexList[4];
		Blow[1].renderer.material.mainTexture = TexList[5];
		Blow[0].renderer.material.color = color;
		Blow[1].renderer.material.color = color;
		
		color.a = 1.0f;
		Player[1].renderer.material.color = color;
		Player[0].renderer.material.color = color;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.LeftControl)){
			fGauge[0] = fTimerGauge[0];
			color.a = 1.0f;
			Blow[0].renderer.material.color = color;
			fTimerGauge[0] = 0.0f;
		}
		if(Input.GetKeyUp(KeyCode.LeftControl)){
			color.a = 0.0f;
			Blow[0].renderer.material.color = color;
		}
		if(Input.GetKeyDown(KeyCode.RightControl)){
			fGauge[1] = fTimerGauge[1];
			color.a = 1.0f;
			Blow[1].renderer.material.color = color;
			fTimerGauge[1] = 0.0f;
		}
		if(Input.GetKeyUp(KeyCode.RightControl)){
			color.a = 0.0f;
			Blow[1].renderer.material.color = color;
		}
		for(int nCnt = 0; nCnt < nMAX_PLAYER; nCnt ++){
			fTimerGauge[nCnt] ++;
		}
		for(int nCnt = 0; nCnt < nMAX_PLAYER; nCnt ++){
			if(fTimerGauge[nCnt] > fMAX_GAUGE){
				fTimerGauge[nCnt] = 0.0f;
			}
		}
	}
}
