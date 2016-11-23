using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DethZone : MonoBehaviour {
	//プレイヤー
	GameObject player;
	//スタート時のポジション
	Vector3 startPos = new Vector3();

	ScoreManager scoreManager;
	GameObject scoreManagerObj;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		scoreManagerObj = GameObject.Find ("ScoreManager");
		scoreManager = scoreManagerObj.GetComponent<ScoreManager> ();
		//初期位置を保存
		startPos = gameObject.transform.position;
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Position ();
	}

	void OnTriggerEnter(Collider other)
	{
		//プレイやーと衝突したら
		if (other.gameObject.tag == "Player") {
			//スコアマネージャーにAllGameManagerへスコアを送信するよう指示
			scoreManager.SendScore ();
			SceneManager.LoadScene ("Result");
		}
	}

	//位置を管理
	Vector3 Position()
	{
		return new Vector3 (startPos.x, startPos.y, player.transform.position.z);
	}
}
