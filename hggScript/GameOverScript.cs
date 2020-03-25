using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    public GameObject GameManager;
    public bool Trigger = false;
    public float Time = 0;
    public bool ScenemoveCheker = true;
    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("Gamemanager").gameObject;
        GameManager.GetComponent<Gamemanager>().AllTimer = 0;
        Trigger = true;
        ScenemoveCheker = true;
    }

    // Update is called once per frame
    void Update()
    {
        Time = GameManager.GetComponent<Gamemanager>().AllTimer;
        if(Time >3.0f && ScenemoveCheker==true)
        {
            ScenemoveCheker = false;
            StartCoroutine(gotoMainMenu());
        }
    }
    IEnumerator gotoMainMenu()
    {
        SceneManager.LoadScene("MainScene2", LoadSceneMode.Additive);
        Scene MainScene2 = SceneManager.GetSceneByBuildIndex(3);
        SceneManager.MoveGameObjectToScene(GameManager, MainScene2);
        yield return null;
        SceneManager.UnloadSceneAsync("GameOver");
    }
}
