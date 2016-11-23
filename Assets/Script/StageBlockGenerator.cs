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
	float generatePace = 0.065f;
	//生成タイミングを決めるカウント
	float count = 0;
	//生成するブロックのz座標
	float blockPosZ = 8;
	//落とし穴が出現する頻度
	public float HoleFrequency = 0;
	//落とし穴出現頻度をランダムにするための乱数
	public float randomCount;

	void Start()
	{
		randomCount = Random.Range (3.0f, 10.0f);
	}
	
	void Update () {
		//ゲームが開始していない限り何も始まらない
		if (BeforeGameStart ()) return;
		Generate ();
		HoleFrequency += Time.deltaTime;
	}

	//ステージを生成
	void Generate()
	{
		count += Time.deltaTime;
		if (count >= generatePace) {
			//ブロックをフォルダにまとめて生成
			GameObject obj = (GameObject)Instantiate (stageBlock, GeneratePosition (), Quaternion.identity);
			obj.transform.parent = stageBlockFolder.transform;
			//カウントをリセット
			count = 0;
			//次回生成のz座標を設定
			blockPosZ += NextBlockPosZ();
		}

	}
		
	//生成するブロックのz座標を決める
	float NextBlockPosZ()
	{
		//落とし穴を作成
		if (HoleFrequency >= randomCount) {
			HoleFrequency = 0; 
			randomCount = Random.Range (4.0f, 10.0f);
			return Random.Range (5.0f, 15.0f);
		} else {	
			return 1.0f;
		}
	}

	//生成位置を決める
	Vector3 GeneratePosition()
	{
		float y = 0;
		if (gameObject.tag == "DownGenerator") y = 0;
		if (gameObject.tag == "UpGenerator") y = 2.0f;

		return new Vector3 (Random.Range (0.7f, -0.7f), y, blockPosZ);
	}


	//ゲーム開始前ならtrueを返す
	bool BeforeGameStart()
	{
		return !GameManager.isPlaying;
	}
}
