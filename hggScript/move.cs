using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public GameObject Image;
    public int x = 0;
    // Start is called before the first frame update
    void Start()
    {
        Image = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            x += 1;
            transform.Translate(x, 0, 0);
        }
    }
}
