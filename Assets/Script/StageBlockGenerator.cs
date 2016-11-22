using UnityEngine;
using System.Collections;

public class StageBlockGenerator : MonoBehaviour {

	//生成するブロック
	public GameObject stageBlock;
	//生成するブロックを収納するフォルダ
	public GameObject stageBlockFolder;
	//プレイヤー
	public GameObject player;
	//生成ペース
	float generatePace = 0.1f;
	//生成タイミングを決めるカウント
	float count = 0;
	//生成するブロックのz座標
	float blockPosZ = 8;

	
	void Update () {
		//ゲームが開始していない限り何も始まらない
		if (BeforeGameStart ()) return;
		Generate ();
	}

	//ステージを生成
	void Generate()
	{
		count += Time.deltaTime;
		if (count >= generatePace) {
			GameObject obj = (GameObject)Instantiate (stageBlock, GeneratePosition (), Quaternion.identity);
			obj.transform.parent = stageBlockFolder.transform;
			//カウントをリセット
			count = 0;
			//次回の生成位置を前回生成位置の1つ前に設定
			blockPosZ += 1.0f;
		}

	}
	//生成位置を決める
	Vector3 GeneratePosition()
	{
		float y = 0;
		if (gameObject.tag == "DownGenerator") y = 0;
		if (gameObject.tag == "UpGenerator") y = 2.0f;

		return new Vector3 (Random.Range (0.5f, -0.5f), y, blockPosZ);
	}


	//ゲーム開始前ならtrueを返す
	bool BeforeGameStart()
	{
		return !GameManager.isPlaying;
	}
}
