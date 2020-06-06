using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreMgr : MonoBehaviour {

    [HideInInspector]
    public static ScoreMgr instance;

    public Text scoreText;
    public Text scoreText_1;

    [HideInInspector]
    public int score;
    [HideInInspector]
    public int score_1;

    public bool Attack = false;

    private void Awake()
    {
        instance = this;
        //score = DataManager.Instance.curUserCoins;
        score = PlayerPrefs.GetInt(DataManager.Instance.curUserName + "Coins");
        score_1 = PlayerPrefs.GetInt(DataManager.Instance.curUserName + "Scores");
        scoreText.text = score.ToString();
        //score_1 = DataManager.Instance.curUserScore;
        scoreText_1.text = score_1.ToString();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ScoreIncrease()
    {
        Attack = true;
        score += 10;
        score_1 += 1;
        scoreText.text = score.ToString();
        scoreText_1.text = score_1.ToString();
        DataManager.Instance.curUserCoins = score;
        DataManager.Instance.curUserScore = score_1;
        PlayerPrefs.SetInt(DataManager.Instance.curUserName + "Coins", score);
        PlayerPrefs.SetInt(DataManager.Instance.curUserName + "Scores", score_1);
    }

    public bool ScoreDecrease(int cost)
    {
        int temp = score;
        if(temp - cost < 0)
        {
            return false;
        }
        score -= cost;
        scoreText.text = score.ToString();
        DataManager.Instance.curUserCoins = score;
        PlayerPrefs.SetInt(DataManager.Instance.curUserName + "Coins", score);
        return true;
    }
}
