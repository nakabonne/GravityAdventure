using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	//これがfalseである限りゲームは動かない
	public static bool isPlaying;

	//デバッグかどうか
	public static bool isDebug;

	public GameObject gameStartButton;
	// Use this for initialization
	void Start () {
		isPlaying = false;
	}
	
	// Update is called once per frame
	void Update () {
	}
	//ゲームを開始するメソッド
	public void GameStart()
	{
		isPlaying = true;
		gameStartButton.SetActive (false);
	}
}
