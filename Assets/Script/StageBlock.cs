using UnityEngine;
using System.Collections;

public class StageBlock : MonoBehaviour {

	void Start () {
		Invoke ("Hide", 30.0f);
	}
	//ブロックを非表示にする
	void Hide()
	{
		//もともと置いてあったブロックの場合は実行されない
		if (isDefaultBlock()) return;
		gameObject.SetActive (false);
	}
	//このオブジェクトがデフォルトのブロックどうかを返す
	bool isDefaultBlock()
	{
		return gameObject.tag == "DefaultBlock";
	}

}
