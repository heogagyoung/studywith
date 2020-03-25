using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Chapter1Script : MonoBehaviour
{
    public GameObject Gamemanager;
    public GameObject[] Card;
    public GameObject[] Card2;
    public Image Timer;
    public float time;
    public bool Trigger;
    public bool Scenemovechecker = false;
    public int nownumber = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        
        Gamemanager = GameObject.Find("Gamemanager").gameObject;
        Card = new GameObject[10];
        Card2 = new GameObject[10];

        StartCoroutine(setfirst());

         Timer = GameObject.Find("TimerCanvers").transform.Find("Timer").gameObject.GetComponent<Image>();
         Timer.enabled = false;
         Trigger = false;
         Scenemovechecker = true;
    }
    IEnumerator setfirst()
    {

        yield return null;
        nownumber = Gamemanager.gameObject.GetComponent<Gamemanager>().whenstartnumber;
        for (int i = 1; i < 4; i++)
        {
            Card[i] = GameObject.Find("Canvas").transform.Find("Card" + i.ToString()).gameObject;
        }
        for (int j =1; j<3; j++)
        {
            Card2[j] = GameObject.Find("Canvas").transform.Find("Card" + j.ToString()+"_2").gameObject;
        }
    
        Card[1].GetComponent<Button>().onClick.AddListener(ClickCard1);
        Card[2].GetComponent<Button>().onClick.AddListener(ClickCard2);

        for (int i = 1; i < 4; i++)
        {
            Card[i].SetActive(false);
        }
        for (int j = 1; j < 3; j++)
        {
            Card2[j].SetActive(false);
        }
       
        Card[nownumber].SetActive(true);
        for (int i =1; i < nownumber; i++)
        {
            Card2[i].SetActive(true);
        }

        if(nownumber == 2)
        {
            Gamemanager.GetComponent<Gamemanager>().AllTimer = 0;
            Timer.enabled = true;
            Trigger = true;
        }
       
    }
    // Update is called once per frame
    void Update()
    {
        time = Gamemanager.GetComponent<Gamemanager>().AllTimer;
        if (Trigger == true)
        {
            Timer.fillAmount = (1.0f - time / 5.0f);
            if (time > 5.0f && Scenemovechecker == true)
            {
               StartCoroutine(GameOver());
                Scenemovechecker = false;
            }
        }
        
    }
    IEnumerator GameOver()
    {
        SceneManager.LoadScene("GameOver", LoadSceneMode.Additive);
        Scene GameOverScene = SceneManager.GetSceneByBuildIndex(2);
        SceneManager.MoveGameObjectToScene(Gamemanager,GameOverScene);
        yield return null;
        SceneManager.UnloadSceneAsync("Chapter1");
    }
    void ClickCard1()
    {
        nownumber = 2;
        Debug.Log("click card1");
        Gamemanager.GetComponent<Gamemanager>().AllTimer = 0;
        Timer.enabled = true;
        Trigger = true;
        Card2[1].SetActive(true);
        Card[2].SetActive(true);
        Card[1].SetActive(false);
    }
    void ClickCard2()
    {
        nownumber = 3;
        Debug.Log("click card2");
        Trigger = false;
        Timer.enabled = false;
        Card2[2].SetActive(true);
        Card[2].SetActive(false);
        Card[3].SetActive(true);

    }
}
