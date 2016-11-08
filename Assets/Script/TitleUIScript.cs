using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TitleUIScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GameStart()
	{
		SceneManager.LoadScene ("Stage1");
	}
}
