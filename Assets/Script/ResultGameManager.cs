using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultGameManager : MonoBehaviour {
	//今回のスコアを表示するテキスト
	public Text thisScoreLabel;

	AllGameManager allgamemanager;
	GameObject allgamemanagerobj;

	// Use this for initialization
	void Start () {
		allgamemanagerobj = GameObject.Find ("AllGameManager");
		allgamemanager = allgamemanagerobj.GetComponent<AllGameManager> ();
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
	//今回のスコアを表示する
	void DisplayThisScore()
	{
		thisScoreLabel.text = allgamemanager.thisTimeScore.ToString("f1");
	}
}
