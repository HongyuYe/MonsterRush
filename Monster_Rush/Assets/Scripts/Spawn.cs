
using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour
{

    public GameObject monsterPrefab;

    int count = 0;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(Test02(int.MaxValue));
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Test02(int num)
    {
        count = 0;
        while (count < num)
        {
            count++;
            yield return StartCoroutine(Test01(1));
        }
    }

    IEnumerator Test01(int number)
    {
        int c = 0;
        while (c < number)
        {
            c++;
            float temp =  10f / (count);
            if (temp <= 0.8f)
                temp = 0.8f;
            yield return new WaitForSeconds(temp);
            Instantiate(monsterPrefab, transform.position, Quaternion.identity);
        }
    }
}

