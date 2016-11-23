using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour {
	//これがfalseである限りゲームは動かない
	public static bool isPlaying;

	//デバッグかどうか
	public static bool isDebug;

	//重力の大さ
	float gravityPower = 20.0f;

	//現在の重力方向
	bool GravitydirectionIsDown;

	//スタートボタン
	public GameObject gameStartButton;

	//重力を表すテキスト
	public Text gravityText;

	//スコアを表すテキスト
	public Text ScoreLabel;

	ScoreManager scoreManager;
	public GameObject scoreManagerObj;

	// Use this for initialization
	void Start () {
		//プレイ中ではない
		isPlaying = false;
		//重力をした方向へ
		Physics.gravity = new Vector3 (0,-gravityPower,0);
		GravitydirectionIsDown = true;
		//スコアをScoreManagerから参照
		scoreManager = scoreManagerObj.GetComponent<ScoreManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		//現在の重力方向を表示
		DisplayGravity ();
		//スコアを表示
		ScoreDisplay ();
		//ゲームが開始しないとこの下の処理は行われない
		if (!isPlaying) return;

		//画面タップ
		if (TapWithoutButton()) {
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
			Physics.gravity = new Vector3 (0, gravityPower, 0);
			GravitydirectionIsDown = false;
		}else{
			Physics.gravity = new Vector3 (0,-gravityPower,0);
			GravitydirectionIsDown = true;
		}

	}

	//スコアを表示
	void ScoreDisplay()
	{
		ScoreLabel.text = scoreManager.score.ToString ("f1");
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
	//タイトル画面へ
	public void GoTitle()
	{
		SceneManager.LoadScene ("Title");
	}

	//画面タップしたらtrueを返すが、ボタンクリックは画面タップとみなされないためfalseを返す
	bool TapWithoutButton()
	{
		return Input.GetMouseButtonDown (0) && !EventSystem.current.IsPointerOverGameObject ();
	}
}
