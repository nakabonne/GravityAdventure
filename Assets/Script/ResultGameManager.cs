using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultGameManager : MonoBehaviour {
	//今回のスコアを表示するテキスト
	public Text thisScoreLabel;
	//ハイスコアを表示するテキスト
	public Text highScoreLabel;

	AllGameManager allgamemanager;
	GameObject allgamemanagerobj;

	// Use this for initialization
	void Start () {
		allgamemanagerobj = GameObject.Find ("AllGameManager");
		allgamemanager = allgamemanagerobj.GetComponent<AllGameManager> ();
		//ハイスコアかどうかを審査
		allgamemanager.SetScore ();
	}
	
	// Update is called once per frame
	void Update () {
		DisplayThisScore ();
	
	}
	//プレイ画面に戻る
	public void Retry()
	{
		SceneManager.LoadScene ("Stage1");
	}
	//今回のスコア情報を表示するメソッド
	void DisplayThisScore()
	{
		//今回のスコアを表示
		thisScoreLabel.text = "今回のスコア" + allgamemanager.thisTimeScore.ToString("f1");
		//ハイスコアを表示
		highScoreLabel.text = "ハイスコア" + allgamemanager.highScore.ToString ("f1");
	}
}
