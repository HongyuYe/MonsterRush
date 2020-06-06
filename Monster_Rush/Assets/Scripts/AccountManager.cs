using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System;

public class AccountManager : MonoBehaviour
{
    public InputField userName;
    public InputField passWord;

    public Text showHintMsgText;

    [HideInInspector]
    public Dictionary<string, string> registerMsg;

    bool succeed = false;

    void Start()
    {
        registerMsg = new Dictionary<string, string>();
        showHintMsgText.text = " ";
        succeed = false;
    }

    public void OnClickOkBtn()
    {
        if (PlayerPrefs.GetString(userName.text) != "" && PlayerPrefs.GetString(userName.text) == passWord.text)
        {
            DataManager.Instance.curUserName = userName.text;

            int curCoins = PlayerPrefs.GetInt(userName.text + "Coins");
            int curScore = PlayerPrefs.GetInt(userName.text + "Scores");            

            Debug.LogWarning(curCoins);
            if (curCoins < 10)            
                curCoins = 20;
            DataManager.Instance.curUserCoins = curCoins;
            PlayerPrefs.SetInt(userName.text + "Coins", curCoins);

            string stemp = "Signed in successfully, welcom back!";
            ShowHintText(stemp);
            succeed = true;
        }

        else if (!PlayerPrefs.HasKey(userName.text) && userName.text != "")
        {
            succeed = false;
            ShowHintText("This account does not exist!");
        }
        else if (PlayerPrefs.HasKey(userName.text) && PlayerPrefs.GetString(userName.text) != passWord.text)
        {
            succeed = false;
            ShowHintText("Wrong password!");
        }
        else
        {
            succeed = false;
            ShowHintText("Account name and password cannot be empty!");
        }
    }

    public void OnClickRegisterBtn()
    {
        if (userName.text != "" && passWord.text != "")
        {
            if (!PlayerPrefs.HasKey(userName.text))
            {
                registerMsg.Add(userName.text, passWord.text);
                DataMsgSave();
                succeed = true;               
                ShowHintText("Signed up successfully!");
                passWord.text = " ";
            }
            else
            {
                ShowHintText("This account is existed!");
                succeed = false;
            }
        }
        else
        {
            ShowHintText("Account name and password cannot be empty!");
            succeed = false;
        }
    }


    private void DataMsgSave()
    {
        foreach (KeyValuePair<string, string> pair in registerMsg)
        {
            PlayerPrefs.SetString(pair.Key, pair.Value);
            PlayerPrefs.SetInt(pair.Key + "Coins", 50);
            PlayerPrefs.SetInt(pair.Key + "Scores", 0);
            DataManager.Instance.curUserCoins = 50;
            DataManager.Instance.curUserName = pair.Key;
            DataManager.Instance.curUserScore = 0;
        }
    }

    private void ShowHintText(string Str)
    {
        showHintMsgText.text = Str;
        StartCoroutine("HideHintText");
    }

    IEnumerator HideHintText()
    {
        yield return new WaitForSeconds(2f);
        showHintMsgText.text = " ";
        if (succeed)
        {
            SceneManager.LoadScene(1);
        }
    }

    public void DestoryAccount()
    {
        PlayerPrefs.DeleteAll();
        DataManager.Instance.curUserName = " ";
        DataManager.Instance.curUserLastDecTime = "0";
        DataManager.Instance.curUserCoins = 0;
        DataManager.Instance.curUserScore = 0;
        ShowHintText("Your account have been written off!");
    }    
}
