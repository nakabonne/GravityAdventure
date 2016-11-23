using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	//前進するスピード
	float moveSpeed = 55.0f;
	//横移動するスピード
	float sideSpeed = 5.0f;
	//現在の重力方向
	bool GravitydirectionIsDown;
	//移動方向
	public Vector3 dir = Vector3.zero;

	void Start () {
		GravitydirectionIsDown = true;
	}
	
	void Update () {
		//ゲームが始まってない限りUpdate内の処理はなされない
		if (BeforeGameStart()) return;

		Move ();
		if (Input.GetMouseButtonDown (0)) {
			GravitySwitch ();
		}
	}

	//移動を管理
	void Move()
	{
		dir.z = Time.deltaTime * moveSpeed;
		//デバッグでなければ
//		if (!GameManager.isDebug) {
			dir.x = Input.acceleration.x;
//		} else {
//		
//			if (Input.GetKey (KeyCode.LeftArrow))
//				dir.x = -1.0f;
//			if (Input.GetKey (KeyCode.LeftArrow))
//				dir.x = 1.0f;
//		}
		
	
		dir *= Time.deltaTime;

		transform.Translate (dir * sideSpeed);
					
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
	//ゲーム開始前ならtrueを返す
	bool BeforeGameStart()
	{
		return !GameManager.isPlaying;
	}


}
