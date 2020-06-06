using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class paixu : MonoBehaviour {

    public GameObject L0;
    public GameObject[] newIndexs;
    public GameObject[] newIndexs_;

    public GameObject Panel;

    public GameObject s;
    public GameObject s_;

    public int indexM;
    public string indexM_;

    public Toggle toggle;

    int[] save = new int[4];
    string[] save_ = new string[4];
    int Num;
    string saveIntStr;
    bool Attack = false;

	// Use this for initialization
	void Start () {

        indexM = PlayerPrefs.GetInt("indexM");
        indexM_ = PlayerPrefs.GetString("indexM_");
        toggle.onValueChanged.AddListener((bool value) => HighScore(value));

        for (int i = 0; i < 4; i++)
        {
            string saveIntStrS = saveIntStr + i.ToString();
            string saveIntStrS_ = saveIntStr + i.ToString() + "Name";
            save[i] = PlayerPrefs.GetInt(saveIntStrS);
            save_[i] = PlayerPrefs.GetString(saveIntStrS_);
        }

        for (int i = 0; i < 4; i++)
        {
            if (save[i] == null || save[i] == 0)
            {
                save[i] = indexM;
                save_[i] = indexM_;
                Num = i;

                for (int m = 0; m < Num + 1; ++m)
                {
                    int t = save[m];
                    string t_ = save_[m];

                    int n = m;
                    while ((n > 0) && (save[n - 1] < t))
                    {
                        save[n] = save[n - 1];
                        save_[n] = save_[n - 1];
                        --n;
                    }
                    save[n] = t;
                    save_[n] = t_;
                }
                break;
            }
            else
            {
                int n = 3;
                if (indexM > save[3])
                {
                    while (save[n - 1] < indexM)
                    {
                        save[n] = save[n - 1];
                        save_[n] = save_[n - 1];
                        --n;
                        save[n] = indexM;
                        save_[n] = indexM_;

                        if (n == 0)
                        {
                            break;
                        }
                    }
                    break;
                }
            }
        }


        for (int j = 0; j < 4; j++)
        {
            string saveIntStrI = saveIntStr + j.ToString();
            string saveIntStrI_ = saveIntStr + j.ToString() + "Name";
            PlayerPrefs.SetInt(saveIntStrI, save[j]);
            PlayerPrefs.SetString(saveIntStrI_, save_[j]);

        }

        for (int i = 0; i < newIndexs.Length-1; i++)
        {
            string saveIntStrO = saveIntStr + i.ToString();
            string saveIntStrO_ = saveIntStr + i.ToString() + "Name";


            newIndexs[i].GetComponent<Text>().text = PlayerPrefs.GetInt(saveIntStrO).ToString();
            newIndexs_[i].GetComponent<Text>().text = PlayerPrefs.GetString(saveIntStrO_);
        }

        s.SetActive(false);
        s_.SetActive(false);
    }

	// Update is called once per frame
	void Update () {

	}
    public void reStart(){
        SceneManager.LoadScene("Scene1");
    }

    public void HighScore(bool isOn)
    {
        if(isOn)
        {
            s.SetActive(true);
            s_.SetActive(true);
        }

        else
        {
            s.SetActive(false);
            s_.SetActive(false);
        }
    }
}
