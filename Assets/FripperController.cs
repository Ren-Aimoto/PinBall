using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour {
	//Hinge Jointコンポーネントを入れる
	private HingeJoint myHingeJoint;
	//初期の傾き
	private float defaultAngle = 20;
	//弾いた時の傾き
	private float flickAngle = -20;

	// Use this for initialization
	void Start () {
		//HingeJointコンポーネント取得
		this.myHingeJoint = GetComponent<HingeJoint>();

		//フリッパーの傾きを設定
		SetAngle(this.defaultAngle);

	}
	
	// Update is called once per frame
	void Update () {
		//左矢印を押した時に左フリッパーを動かす
		if (Input.GetKeyDown (KeyCode.LeftArrow) && tag == "LeftFripperTag") {
			SetAngle (this.flickAngle);
		}
		//右矢印を押した時に左フリッパーを動かす
		if (Input.GetKeyDown (KeyCode.RightArrow) && tag == "RightFripperTag") {
			SetAngle (this.flickAngle);
		}
		//矢印が離れた時にfripperを戻す
		if (Input.GetKeyUp (KeyCode.LeftArrow) && tag == "LeftFripperTag") {
			SetAngle (this.defaultAngle);
		}

		if (Input.GetKeyUp (KeyCode.RightArrow) && tag == "RightFripperTag") {
			SetAngle (this.defaultAngle);
		}
		//タッチされている場合
		if (0 < Input.touchCount) {
			//タッチされている指の数だけ処理を繰り返す
			for (int i = 0; i < Input.touchCount; i++) {
				//画面の左側に触れた際に左フリッパーを動かす
				if ((Input.GetTouch (i).phase == TouchPhase.Began && Input.GetTouch (i).position.x <= Screen.width / 2) && tag == "LeftFripperTag") {
					SetAngle (this.flickAngle);
				}
				//画面の右側に触れた際に右フリッパーを動かす
				if ((Input.GetTouch (i).phase == TouchPhase.Began && Input.GetTouch (i).position.x >= Screen.width / 2) && tag == "RightFripperTag") {
					SetAngle (this.flickAngle);
				}
				//タッチが離れた際にfripperを戻す
				if ((Input.GetTouch (i).phase == TouchPhase.Ended && Input.GetTouch (i).position.x <= Screen.width / 2) && tag == "LeftFripperTag") {
					SetAngle (this.defaultAngle);
				}
				if ((Input.GetTouch (i).phase == TouchPhase.Ended && Input.GetTouch (i).position.x >= Screen.width / 2) && tag == "RightFripperTag") {
					SetAngle (this.defaultAngle);
				}
			}
		}
				
	}
		//フリッパーの傾きを設定
		public void SetAngle(float angle){
			JointSpring jointSpr = this.myHingeJoint.spring;
			jointSpr.targetPosition = angle;
			this.myHingeJoint.spring = jointSpr;
	}
}
