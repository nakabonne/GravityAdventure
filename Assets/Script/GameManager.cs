using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	//これがfalseである限りゲームは動かない
	public static bool isPlaying;

	//デバッグかどうか
	public static bool isDebug;

	//現在の重力方向
	bool GravitydirectionIsDown;

	//スタートボタン
	public GameObject gameStartButton;

	//重力を表すテキスト
	public Text gravityText;
	// Use this for initialization
	void Start () {
		isPlaying = false;
		GravitydirectionIsDown = true;
	}
	
	// Update is called once per frame
	void Update () {
		//現在の重力方向を表示
		DisplayGravity ();
		//ゲームが開始しないとこの下の処理は行われない
		if (!isPlaying) return;

		if (Input.GetMouseButtonDown (0)) {
			GravitySwitch ();
		}

	}
	//ゲームを開始するメソッド
	public void GameStart()
	{
		isPlaying = true;
		gameStartButton.SetActive (false);
	}
	//重力の切り替えを管理
	void GravitySwitch()
	{
		if (GravitydirectionIsDown) {
			Physics.gravity = new Vector3 (0, 20.0f, 0);
			GravitydirectionIsDown = false;
		}else{
			Physics.gravity = new Vector3 (0,-20.0f,0);
			GravitydirectionIsDown = true;
		}

	}
	//現在の重力方向を表示
	void DisplayGravity()
	{
		//重力方向が下なら
		if (Physics.gravity.y < 0f) {
			gravityText.text = "下";
		}
		else {
			gravityText.text = "上";
		}
	}
}
