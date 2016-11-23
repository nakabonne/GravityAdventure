using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	//前進するスピード
	float moveSpeed = 55.0f;
	//横移動するスピード
	float sideSpeed = 5.0f;
	//移動方向
	public Vector3 dir = Vector3.zero;

	void Start () {
	}
	
	void Update () {
		//ゲームが始まってない限りUpdate内の処理はなされない
		if (BeforeGameStart()) return;

		Move ();
	}

	//移動を管理
	void Move()
	{
		//moveSpeedの速度で前へ移動
		dir.z = Time.deltaTime * moveSpeed;
		//傾きを検知
		dir.x = Input.acceleration.x;

		dir *= Time.deltaTime;

		transform.Translate (dir * sideSpeed);
	}


	//ゲーム開始前ならtrueを返す
	bool BeforeGameStart()
	{
		return !GameManager.isPlaying;
	}


}
