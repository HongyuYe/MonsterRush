using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PetController : MonoBehaviour
{
   
    public List<GameObject> eggs;

    
    public List<GameObject> fish;
    Dictionary<string, List<GameObject>> PetsSpecies = new Dictionary<string, List<GameObject>>();

    
    public List<ParticleSystem> first;
    public ParticleSystem moveEffect;
    //public List<ParticleSystem> third;

    
    public float value_1;
    public float value_2;
    public float speed = 1;

    
    public CanvasGroup canvasGroup;
    public Image illustrated;
    public List<Sprite> sprites = new List<Sprite>();
    public Toggle toggle;
    Sprite curSprite;

    private void Awake()
    {
        PetsSpecies.Add("Fish", fish);
    }

    // Use this for initialization
    void Start()
    {
        
        SpwanEgg();

        
        canvasGroup.alpha = 0;
        curSprite = sprites[0];
        toggle.onValueChanged.AddListener((bool isOn) => { Displayillustrated(isOn); });
    }

    // Update is called once per frame
    void Update()
    {

    }

    
    void SpwanEgg()
    {

        float petEn = DataManager.Instance.curUserPetEnergy;
        Debug.Log("Energy of pet" + petEn);

        if (petEn <= 0)
        {
            GameObject egg = GameObject.FindWithTag("egg");
            if (egg != null)
            {
                Debug.Log("Egg is not null");
                Destroy(egg);
            }

            int r = Random.Range(0, eggs.Count - 1);
            Debug.Log("Number of eggs now" + r);
            Instantiate(eggs[r]);
        }
    }

    public void DisplayPet(float value, string petName)
    {
        
        illustrated.sprite = curSprite;

        
        GameObject egg = GameObject.FindWithTag("egg");
        if (egg != null)
        {
            first[0].Play();
            Destroy(egg);
        }

        GameObject tempfish = GameObject.FindWithTag("fish");
        bool noPet = tempfish == null ? true : false;

        
        switch (petName)
        {
            
            case "fish":
                //Top status
                if ( value > value_2)
                {
                    curSprite = sprites[2];
                    if (noPet || tempfish.name != "fish_3(Clone)")
                    {
                        DestroyObject(tempfish);
                        StartCoroutine("PlayEffectIE", 2);
                    }
                    Debug.LogWarning("Top status" + value);
                }

                ////Second status
                else if (value <= value_2 && value > value_1)
                {
                    curSprite = sprites[1];
                    if (noPet || tempfish.name != "fish_2(Clone)")
                    {
                        DestroyObject(tempfish);
                        StartCoroutine("PlayEffectIE", 1);
                    }
                    Debug.LogWarning("//Second status" + value);
                }

                //First status
                else if (value <= value_1)
                {
                    curSprite = sprites[0];
                    if (noPet || tempfish.name != "fish_1(Clone)")
                    {
                        StartCoroutine("PlayEffectIE", 0);
                    }
                    Debug.LogWarning("First status" + value);
                }
                break;
            default: break;
        }
    }

    IEnumerator PlayEffectIE(int index)
    {
        first[index].gameObject.SetActive(true);
            first[index].Play();
        yield return new WaitForSeconds(2f);
        StopEffect(index, "fish");
    }

    void StopEffect(int index, string perName)
    {
        switch (perName)
        {
            case "fish":
                first[index].Stop();
                first[index].gameObject.SetActive(false);
                Instantiate(fish[index]);
                break;
            default: break;
        }

        StopAllCoroutines();
    }

    public void Displayillustrated(bool isOn)
    {
        if (isOn)
        {
            Debug.LogWarning("On");

            canvasGroup.alpha = 1;
        }
        else
        {
            Debug.LogWarning("Off");

            canvasGroup.alpha = 0;
        }
    }
}


