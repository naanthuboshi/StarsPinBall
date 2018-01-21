using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{

	//ボールが見える可能性のあるz軸の最大値
	private float visiblePosZ = -6.5f;

	//ゲームオーバを表示するテキスト
	private GameObject gameoverText;

	// 得点を格納しておく変数
	private int score;

	// 得点を表示するテキスト
	private GameObject scoreText;

	// Use this for initialization
	void Start()
	{
		//シーン中のGameOverTextオブジェクトを取得
		this.gameoverText = GameObject.Find("GameOverText");
		this.scoreText = GameObject.Find("ScoreText");
	}

	// Update is called once per frame
	void Update()
	{
		//ボールが画面外に出た場合
		if (this.transform.position.z < this.visiblePosZ)
		{
			//GameoverTextにゲームオーバを表示
			this.gameoverText.GetComponent<Text>().text = "Game Over";
		}
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag("SmallStarTag"))
		{
			score += 10;
		}
		else if (other.gameObject.CompareTag("LargeStarTag"))
		{
			score += 20;
		}
		else if (other.gameObject.CompareTag("LargeCloudTag"))
		{
			score += 15;
		}
		else if (other.gameObject.CompareTag("SmallCloudTag"))
		{
			score += 5;
		}

		scoreText.GetComponent<Text>().text = score.ToString();
	}
}