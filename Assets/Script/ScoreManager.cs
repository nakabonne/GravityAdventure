using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour {

	AllGameManager allGameManager;
	GameObject allGameManagerObj;

	//このステージのスコア
	public float score = 0;

	void Start()
	{
		allGameManagerObj = GameObject.Find ("AllGameManager");
		allGameManager = allGameManagerObj.GetComponent<AllGameManager> ();
		score = 0;
	}

	void Update () {
		if (!GameManager.isPlaying) return;
		if (SceneManager.GetActiveScene ().name == "Stage1") {
			TimeAdd ();
		}
	
	}

	//時間によるスコア追加
	void TimeAdd()
	{
		score += Time.deltaTime;
	}
	//スコアをAllGameManagerに送る
	public void SendScore()
	{
		allGameManager.thisTimeScore = score;
	}

}
