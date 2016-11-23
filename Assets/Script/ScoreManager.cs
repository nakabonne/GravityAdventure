using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	//このステージのスコア
	public float score = 0;
	//スコアを表すテキスト
	public Text ScoreLabel;

	//シングルトン作る
	void Awake()
	{
		
	}


	void Update () {
		if (!GameManager.isPlaying) return;
		Displaying ();
		TimeAdd ();
	
	}

	//時間によるスコア追加
	void TimeAdd()
	{
		score += Time.deltaTime;
	}
	//スコアを表示
	void Displaying()
	{
		ScoreLabel.text = score.ToString ("f1");
	}
}
