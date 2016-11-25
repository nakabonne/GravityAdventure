using UnityEngine;
using System.Collections;

//全シーンに使いたいデータをまとめたクラス
public class AllGameManager : MonoBehaviour {

	public static AllGameManager instance = null;

	//リザルトシーンにもっていくスコア
	public float thisTimeScore = 0;
	//ハイスコア
	public float highScore = 0;
	//シングルトン作成
	void Awake()
	{
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (this.gameObject);
		} else {
			Destroy (this.gameObject);
		}
	}
	void Start()
	{
		//初保存時にキーを初期化
		if (!PlayerPrefs.HasKey("HIGHSCORE")) 
		{
			PlayerPrefs.SetFloat ("HIGHSCORE", 0.0f);
		}
		//保存されているハイスコアを読み込む
		highScore = PlayerPrefs.GetFloat ("HIGHSCORE");
	}

	//ハイスコアを更新するメソッド
	public void SetScore()
	{
		//今回のスコアがハイスコアを超えていない場合は何もしない
		if (thisTimeScore < highScore) return;
		Debug.Log ("aaaaaaaa");
		//ハイスコアを更新
		highScore = thisTimeScore;

		//highScoreをキーに保存する
		PlayerPrefs.SetFloat ("HIGHSCORE", highScore);
	}
}
