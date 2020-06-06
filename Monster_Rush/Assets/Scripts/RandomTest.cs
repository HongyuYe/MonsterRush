using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RandomTest : MonoBehaviour {

    public int RandomM;
    Text RandomMText;

	// Use this for initialization
	void Start () {
        RandomMText = GameObject.Find("Canvas").transform.Find("RandomText").GetComponent<Text>();
        RandomM = Random.Range(0, 100);
        RandomMText.text = RandomM.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void RandomC()
    {  
        PlayerPrefs.SetInt("indexM", RandomM);
        SceneManager.LoadScene("Scene2");
    }

}
