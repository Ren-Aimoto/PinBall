using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class PointController : MonoBehaviour {
	//得点を表示するテキスト
	private GameObject pointtext;
	//得点の変数宣言
	public int score = 0;
	//衝突時に呼ばれる関数
	void OnCollisionEnter(Collision col){
		//得点をオブジェクトに応じて入れる。
		if (col.gameObject.tag == "SmallStarTag") {
			score += 10;
		} else if (col.gameObject.tag == "LargeStarTag") {
			score += 20;
		} else if (col.gameObject.tag == "LargeCloudTag") {
			score += 30;
		} else if (col.gameObject.tag == "SmallCloudTag"){
			score += 40;
			}
	}
	// Use this for initialization
	void Start () {
		//シーン中のPointTextオブジェクトを取得
		this.pointtext = GameObject.Find("PointText");
	}
	
	// Update is called once per frame
	void Update () {
		//オブジェクトからTextコンポーネントを取得
		this.pointtext.GetComponent<Text> ().text = ("Score : " + score);
	}
}
