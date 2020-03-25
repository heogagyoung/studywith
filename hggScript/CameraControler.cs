using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    [SerializeField] float zoomSpeed=4;
    [SerializeField] float zoomMax = 3;
    [SerializeField] float zoomMin = -8;
    [SerializeField] Vector2 limit;

    public GameObject menu;
    private void Start()
    {
        limit.Set(5, 3);
    }
    void Update()
    {
        
            CameraZoom();
            CameraMove();
        
    }

    void CameraZoom()
    {
        float zoomDirc = Input.GetAxis("Mouse ScrollWheel");

        if (transform.position.z >= zoomMax && zoomDirc > 0)
            return;
        else if (transform.position.z <= zoomMin && zoomDirc < 0)
            return;

        transform.position += Vector3.forward * zoomDirc * zoomSpeed;
    }

    void CameraMove()
    {
        if (Input.GetMouseButton(1))
        {
            float posX = Input.GetAxis("Mouse X");
            float posY = Input.GetAxis("Mouse Y");

            float limitL = -limit.x + limit.x * (transform.position.z + 3f) / -5f; // 왼쪽 경계
            float limitR = limit.x + -limit.x * (transform.position.z + 3f) / -5f; // 오른쪽 경계
            float limitB = -limit.y + limit.y * (transform.position.z + 3f) / -5f; // 아래쪽 경계
            float limitT = limit.y + -limit.y * (transform.position.z + 3f) / -5f; // 위쪽 경계

            if (transform.position.x <= limitL && posX > 0)
                posX = 0f;
            else if (transform.position.x >= limitR && posX < 0)
                posX = 0f;
            if (transform.position.y <= limitB && posY > 0)
                posY = 0f;
            else if (transform.position.y >= limitT && posY < 0)
                posY = 0f;

            transform.position -= new Vector3(posX, posY, 0);
        }
    }
}