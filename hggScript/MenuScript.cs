using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuScript : MonoBehaviour
{
    public GameObject GameManager;
    public Button Resume;
    public Button Save;
    public Button Title;
    public Button Exit;

    public Button Save1;
    public Button Save2;
    public Button Save3;
    public Button Save4;
    public Button Back;

    public GameObject Menupanel;
    public GameObject MenuButton;
    public GameObject SavePanel;
    public bool moveSceneCheke = true;
    public int nowcardnumber = 1;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(firstset());
        moveSceneCheke = true;

    }
    IEnumerator firstset()
    {
        yield return null;
        ///판넬 오브젝트 지정
        { 
            Menupanel = GameObject.Find("MenuCanvas").transform.Find("MenuPanel").gameObject;
            SavePanel = GameObject.Find("MenuCanvas").transform.Find("SavePanel").gameObject;
        }
        MenuButton = GameObject.Find("Canvas").transform.Find("Menu").gameObject;
        //메뉴판넬에 있는 버튼지정
        {
            Resume = GameObject.Find("MenuCanvas").transform.Find("MenuPanel").transform.Find("Resume").gameObject.GetComponent<Button>();
            Save = GameObject.Find("MenuCanvas").transform.Find("MenuPanel").transform.Find("Save").gameObject.GetComponent<Button>();
            Exit = GameObject.Find("MenuCanvas").transform.Find("MenuPanel").transform.Find("Exit").gameObject.GetComponent<Button>();
            Title = GameObject.Find("MenuCanvas").transform.Find("MenuPanel").transform.Find("Title").gameObject.GetComponent<Button>();
        }
            //savepanel에 있는 버튼지정
        { 
           Save1 = GameObject.Find("MenuCanvas").transform.Find("SavePanel").transform.Find("Save1").gameObject.GetComponent<Button>();
           Save2 = GameObject.Find("MenuCanvas").transform.Find("SavePanel").transform.Find("Save2").gameObject.GetComponent<Button>();
           Save3 = GameObject.Find("MenuCanvas").transform.Find("SavePanel").transform.Find("Save3").gameObject.GetComponent<Button>();
           Save4 = GameObject.Find("MenuCanvas").transform.Find("SavePanel").transform.Find("Save4").gameObject.GetComponent<Button>();
           Back  = GameObject.Find("MenuCanvas").transform.Find("SavePanel").transform.Find("Back").gameObject.GetComponent<Button>();
        }
        GameManager = GameObject.Find("Gamemanager").gameObject;

        MenuButton.GetComponent<Button>().onClick.AddListener(ClickMenu);
        // 메뉴판넬에 있는 버튼 기능 활성화
        {
            Resume.onClick.AddListener(ClickResume);
            Save.onClick.AddListener(ClickSave);
            Title.onClick.AddListener(ClickTitle);
            Exit.onClick.AddListener(ClickExit);
        }
        // savePanel에 있는 버튼 기능 활성화
        {
            Save1.onClick.AddListener(ClickSave1);
            Save2.onClick.AddListener(ClickSave2);
            Save3.onClick.AddListener(ClickSave3);
            Save4.onClick.AddListener(ClickSave4);
            Back.onClick.AddListener(ClickBack);
        }


        Menupanel.SetActive(false);
        SavePanel.SetActive(false);
    }
    // Update is called once per frame
    void ClickResume()
    {
        Time.timeScale = 1;
        Menupanel.SetActive(false);
    }
    void ClickSave()
    {
        Menupanel.SetActive(false);
        SavePanel.SetActive(true);
    }
    void ClickTitle()
    {
        if (moveSceneCheke == true)
        {
            moveSceneCheke = false;
            StartCoroutine(gotoMenu());
        }
    }
    IEnumerator gotoMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainScene2", LoadSceneMode.Additive);
        Scene MainScene2 = SceneManager.GetSceneByBuildIndex(3);
        GameManager = GameObject.Find("Gamemanager").gameObject;
        SceneManager.MoveGameObjectToScene(GameManager, MainScene2);
        yield return null;
        SceneManager.UnloadSceneAsync("Chapter1");
    }
    void ClickExit()
    {
        Application.Quit();
    }
    void ClickMenu()
    {
        Time.timeScale = 0;
        Menupanel.SetActive(true);
    }
    void ClickSave1()
    {
        nowcardnumber = GameObject.Find("Controlobject").gameObject.GetComponent<Chapter1Script>().nownumber;
        PlayerPrefs.SetInt("Save1", nowcardnumber);
    }
    void ClickSave2()
    {
        nowcardnumber = GameObject.Find("Controlobject").gameObject.GetComponent<Chapter1Script>().nownumber;
        PlayerPrefs.SetInt("Save2", nowcardnumber);
    }
    void ClickSave3()
    {
        nowcardnumber = GameObject.Find("Controlobject").gameObject.GetComponent<Chapter1Script>().nownumber;
        PlayerPrefs.SetInt("Save3", nowcardnumber);
    }
    void ClickSave4()
    {
        nowcardnumber = GameObject.Find("Controlobject").gameObject.GetComponent<Chapter1Script>().nownumber;
        PlayerPrefs.SetInt("Save4", nowcardnumber);
    }
    void ClickBack()
    {
        Menupanel.SetActive(true);
        SavePanel.SetActive(false);
    }
}
