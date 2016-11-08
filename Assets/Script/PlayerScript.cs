using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	//前進するスピード
	float moveSpeed = 40.0f;
	//横移動するスピード
	float sideSpeed = 5.0f;
	//現在の重力方向
	bool GravitydirectionIsDown;

	// Use this for initialization
	void Start () {
		GravitydirectionIsDown = true;
	}
	
	// Update is called once per frame
	void Update () {
		//ゲームが始まってない限りUpdate内の処理はなされない
		if (!GameManager.isPlaying) return;

		Move ();
		if (Input.GetMouseButtonDown (0)) {
			GravitySwitch ();
		}
	}

	//移動を管理
	void Move()
	{
		var dir = Vector3.zero;
		dir.x = Input.acceleration.x;
		//縦の移動
		dir.z += Time.deltaTime * moveSpeed;

		if(dir.sqrMagnitude > 1){
			dir.Normalize();
		}

		dir *= Time.deltaTime;

		transform.Translate(dir * sideSpeed);
	}

	//重力の切り替えを管理
	void GravitySwitch()
	{
		if (GravitydirectionIsDown) {
			Physics.gravity = new Vector3 (0, 9.7f, 0);
			GravitydirectionIsDown = false;
		}else{
			Physics.gravity = new Vector3 (0,-9.7f,0);
			GravitydirectionIsDown = true;
		}

	}


}
