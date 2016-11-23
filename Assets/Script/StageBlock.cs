using UnityEngine;
using System.Collections;

public class StageBlock : MonoBehaviour {

	//衝突を管理
	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Player") {
			Invoke ("Hide", 5.0f);
		}
			
	}
	//ブロックを非表示にする
	void Hide()
	{
		//もともと置いてあったブロックの場合は実行されない
		if (isDefaultBlock()) return;
		//Rayを上に飛ばして当たったオブジェクトを非表示
		SkipRay();

		//ゲームオブジェクトを非表示にする
		gameObject.SetActive (false);
	}
		
	//このオブジェクトがデフォルトのブロックどうかを返す
	bool isDefaultBlock()
	{
		return gameObject.tag == "DefaultBlock";
	}
	//Rayをy方向に飛ばす
	void SkipRay()
	{
		Ray ray = new Ray (transform.position,new Vector3 (0,1,0));
		RaycastHit hitInfo;
		int distance = 15;
		if (Physics.Raycast (ray, out hitInfo, distance)) {
			//Rayが当たったオブジェクトのtagがPlayerだったら
			if (hitInfo.collider.tag == "Block") 
			{
				hitInfo.collider.gameObject.SetActive (false);
			}
		}
	}
}
