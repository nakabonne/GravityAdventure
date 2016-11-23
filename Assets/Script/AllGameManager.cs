using UnityEngine;
using System.Collections;

//全シーンに使いたいデータをまとめたクラス
public class AllGameManager : MonoBehaviour {

	public static AllGameManager instance = null;

	//リザルトシーンにもっていくスコア
	public float thisTimeScore = 0;

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
}
