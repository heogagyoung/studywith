using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Scenemove : MonoBehaviour
{
    public GameObject GameManager;
    public bool first=true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            if (first == true)
            {
                first = false;
                StartCoroutine(SceneSwitch());
            }
            
            
        }
    }
    IEnumerator SceneSwitch()
    {

        SceneManager.LoadScene("Chapter1", LoadSceneMode.Additive);
        Scene Chapter1 = SceneManager.GetSceneByBuildIndex(1);
        GameManager = GameObject.Find("Gamemanager").gameObject;
        SceneManager.MoveGameObjectToScene(GameManager, Chapter1);
        yield return null;
        SceneManager.UnloadSceneAsync("MainScene");

    }

}
