using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load : MonoBehaviour {

    public void Load_1(int level)
    {
        int curScore = 0;
        string curName = " ";
        if (level == 0)
        {
            if(ScoreMgr.instance.Attack)
            {
                curScore = PlayerPrefs.GetInt(DataManager.Instance.curUserName + "Scores");
                curName = DataManager.Instance.curUserName;
            }
            else
            {
                curScore = 0;
                curName = " ";
            }
        }
        PlayerPrefs.SetInt("indexM", curScore);
        PlayerPrefs.SetString("indexM_", curName);
        SceneManager.LoadScene(level);
    }
}
