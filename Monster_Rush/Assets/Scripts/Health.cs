using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public bool Player = false;
    public Text fail;
    Transform cam;
    TextMesh tm;

    // Use this for initialization
    void Start()
    {
        tm = GetComponent<TextMesh>();
        cam = GameObject.Find("Camera").GetComponent<Transform>();
        if (Player)
            fail.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        transform.forward = cam.forward;
    }

    public int current()
    {
        return tm.text.Length;
    }

    public void decrease(int damage)
    {
        if (current() > 1)
        {
            if (current() > damage)
            {
                tm.text = tm.text.Remove(tm.text.Length - damage);
            }
            else
            {
                tm.text = tm.text.Remove(tm.text.Length - current());
            }
        }

        else
        {
            if (!Player)
            {
                ScoreMgr.instance.ScoreIncrease();
                Destroy(transform.parent.gameObject);
            }
            else
            {
                fail.gameObject.SetActive(true);
                fail.text = "FAIL";
                StartCoroutine(end());
            }
        }
    }

    IEnumerator end()
    {
        yield return new WaitForSeconds(2f);

        string curName = DataManager.Instance.curUserName;
        PlayerPrefs.SetInt(curName + "Scores", 0);
        PlayerPrefs.SetInt(curName + "Coins", 0);
        DataManager.Instance.curUserCoins = 0;
        DataManager.Instance.curUserScore = 0;

        PlayerPrefs.SetInt("indexM", 0);
        PlayerPrefs.SetString("indexM_", " ");

        SceneManager.LoadScene(0);
    }
}
