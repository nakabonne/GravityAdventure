using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {
	GameObject player;
	PlayerScript playerscript;

	//最初のカメラポジション
	public Vector3 StartPosition;
	//プレイヤーとカメラの距離
	public float withPlayerDistance = 3.56f;

	// Use this for initialization
	void Start (){
		player = GameObject.Find ("Player");
		playerscript = player.GetComponent<PlayerScript> ();
		//初期の座標を代入
		StartPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
	}
	//移動を管理
	void Move()
	{
		transform.position = new Vector3 (StartPosition.x,StartPosition.y, player.transform.position.z - withPlayerDistance);
	}
}
