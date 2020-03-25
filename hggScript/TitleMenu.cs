using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleMenu : MonoBehaviour
{
    public GameObject GameManager;
    public bool first = true;

    public GameObject startpanel;
    public Button Startbutton;
    public Button Loadbutton;
    public Button Exitbutton;
    public Button TestButton;
    
    public GameObject Loadpanel;
    public Button Load1;
    public Button Load2;
    public Button Load3;
    public Button Load4;
    public Button Back;
    public bool ScenemoveChecker = true;
    
    public GameObject TestPanel;
    public Button SoundTestButton;
    public Button TestBack;
    
    // Start is called before the first frame update
    void Start()
    {
        //초기화
        StartCoroutine(Findbutton());
         ScenemoveChecker = true;
}
    IEnumerator Findbutton()
    {
        yield return null;
        GameManager = GameObject.Find("Gamemanager").gameObject;

        startpanel = GameObject.Find("Canvas").transform.Find("Panel").gameObject;
        Startbutton = GameObject.Find("Canvas").transform.Find("Panel").transform.Find("Start").gameObject.GetComponent<Button>();
        Loadbutton = GameObject.Find("Canvas").transform.Find("Panel").transform.Find("Load").gameObject.GetComponent<Button>();
        Exitbutton = GameObject.Find("Canvas").transform.Find("Panel").transform.Find("Exit").gameObject.GetComponent<Button>();
        TestButton = GameObject.Find("Canvas").transform.Find("Panel").transform.Find("Test").gameObject.GetComponent<Button>();

        Loadpanel = GameObject.Find("LoadCanvas").transform.Find("Panel").gameObject;
        Load1 = GameObject.Find("LoadCanvas").transform.Find("Panel").transform.Find("Load1").gameObject.GetComponent<Button>();
        Load2 = GameObject.Find("LoadCanvas").transform.Find("Panel").transform.Find("Load2").gameObject.GetComponent<Button>();
        Load3 = GameObject.Find("LoadCanvas").transform.Find("Panel").transform.Find("Load3").gameObject.GetComponent<Button>();
        Load4 = GameObject.Find("LoadCanvas").transform.Find("Panel").transform.Find("Load4").gameObject.GetComponent<Button>();
        Back = GameObject.Find("LoadCanvas").transform.Find("Panel").transform.Find("Back").gameObject.GetComponent<Button>();

        TestPanel = GameObject.Find("TestObject").transform.Find("TestCanvas").transform.Find("TestPanel").gameObject;
        SoundTestButton = GameObject.Find("TestObject").transform.Find("TestCanvas").transform.Find("TestPanel").transform.Find("SoundTest").gameObject.GetComponent<Button>();
        TestBack = GameObject.Find("TestObject").transform.Find("TestCanvas").transform.Find("TestPanel").transform.Find("TestBack").gameObject.GetComponent<Button>();

        Startbutton.onClick.AddListener(ClickStartButton);
        Loadbutton.onClick.AddListener(ClickLoadButton);
        Exitbutton.onClick.AddListener(ClickExitButton);
        TestButton.onClick.AddListener(ClickTestButton);

        Load1.onClick.AddListener(ClickLoad1);
        Load2.onClick.AddListener(ClickLoad2);
        Load3.onClick.AddListener(ClickLoad3);
        Load4.onClick.AddListener(ClickLoad4);
        Back.onClick.AddListener(ClickBack);

        SoundTestButton.onClick.AddListener(ClickSoundTest);
        TestBack.onClick.AddListener(ClickBack);

        Loadpanel.SetActive(false);
        TestPanel.SetActive(false);
    }
    //when click startbutton
    void ClickStartButton()
    {
        if (ScenemoveChecker == true)
        {
            GameManager.GetComponent<Gamemanager>().whenstartnumber = 1;
            StartCoroutine(SceneSwitch());
            ScenemoveChecker = false;
        }
    }   
    IEnumerator SceneSwitch()
    {

        SceneManager.LoadScene("Chapter1", LoadSceneMode.Additive);
        Scene Chapter1 = SceneManager.GetSceneByBuildIndex(1);
        GameManager = GameObject.Find("Gamemanager").gameObject;
        int WillClose = SceneManager.GetActiveScene().buildIndex;
        SceneManager.MoveGameObjectToScene(GameManager, Chapter1);
        yield return null;
        SceneManager.UnloadSceneAsync(WillClose);

    }
    void ClickLoadButton()
    {
        startpanel.SetActive(false);
        Loadpanel.SetActive(true);

    }
    void ClickExitButton()
    {
        Application.Quit();
    }
    void ClickTestButton()
    {
        TestPanel.SetActive(true);
        startpanel.SetActive(false);
    }
    void ClickLoad1()
    {
        if (ScenemoveChecker == true)
        {
            if(PlayerPrefs.GetInt("Save1") == 0 )
            {
                GameManager.GetComponent<Gamemanager>().whenstartnumber = 1;
                StartCoroutine(SceneSwitch());
                ScenemoveChecker = false;
            }
            else if (PlayerPrefs.GetInt("Save1") != 0)
            {
                GameManager.GetComponent<Gamemanager>().whenstartnumber = PlayerPrefs.GetInt("Save1");
                StartCoroutine(SceneSwitch());
                ScenemoveChecker = false;
            }

        }
    }
    void ClickLoad2()
    {
        if (PlayerPrefs.GetInt("Save2") == 0)
        {
            GameManager.GetComponent<Gamemanager>().whenstartnumber = 1;
            StartCoroutine(SceneSwitch());
            ScenemoveChecker = false;
        }
        else if (PlayerPrefs.GetInt("Save2") != 0)
        {
            GameManager.GetComponent<Gamemanager>().whenstartnumber = PlayerPrefs.GetInt("Save2");
            StartCoroutine(SceneSwitch());
            ScenemoveChecker = false;
        }
    }
    void ClickLoad3()
    {
        if (PlayerPrefs.GetInt("Save3") == 0)
        {
            GameManager.GetComponent<Gamemanager>().whenstartnumber = 1;
            StartCoroutine(SceneSwitch());
            ScenemoveChecker = false;
        }
        else if (PlayerPrefs.GetInt("Save3") != 0)
        {
            GameManager.GetComponent<Gamemanager>().whenstartnumber = PlayerPrefs.GetInt("Save3");
            StartCoroutine(SceneSwitch());
            ScenemoveChecker = false;
        }
    }
    void ClickLoad4()
    {
        if (PlayerPrefs.GetInt("Save4") == 0)
        {
            GameManager.GetComponent<Gamemanager>().whenstartnumber = 1;
            StartCoroutine(SceneSwitch());
            ScenemoveChecker = false;
        }
        else if (PlayerPrefs.GetInt("Save4") != 0)
        {
            GameManager.GetComponent<Gamemanager>().whenstartnumber = PlayerPrefs.GetInt("Save4");
            StartCoroutine(SceneSwitch());
            ScenemoveChecker = false;
        }
    }
    void ClickBack()
    {
        startpanel.SetActive(true);
        Loadpanel.SetActive(false);
        TestPanel.SetActive(false);
    }
    void ClickSoundTest()
    {
        if (ScenemoveChecker == true)
        {
            StartCoroutine(SceneSwitchSoundTest());
            ScenemoveChecker = false;
        }
    }
    IEnumerator SceneSwitchSoundTest()
    {

        SceneManager.LoadScene("SoundTest", LoadSceneMode.Additive);
        Scene SoundTest = SceneManager.GetSceneByBuildIndex(4);
        GameManager = GameObject.Find("Gamemanager").gameObject;
        int WillClose = SceneManager.GetActiveScene().buildIndex;
        SceneManager.MoveGameObjectToScene(GameManager, SoundTest);
        yield return null;
        SceneManager.UnloadSceneAsync(WillClose);

    }
}
