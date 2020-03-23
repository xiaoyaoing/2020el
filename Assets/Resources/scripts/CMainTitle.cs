using UnityEngine;
using System.Collections;

public class CMainTitle : MonoBehaviour {
	
	Texture bg;
	GameObject battleroom;
	
	// Use this for initialization
	void Start () {
		this.bg = Resources.Load("images/title_blue") as Texture;
		this.battleroom = GameObject.Find("BattleRoom");
		this.battleroom.SetActiveRecursively (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
		{
			this.battleroom.SetActiveRecursively(true);
			gameObject.SetActiveRecursively(false);
		}
	}
	
	void OnGUI()
	{
		GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height), this.bg);
	}
}
