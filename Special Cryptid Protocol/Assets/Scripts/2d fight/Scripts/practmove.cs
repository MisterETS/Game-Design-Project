using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class practmove : MonoBehaviour
{

    private Vector3 Startingpos;
    public GameObject Heart;

    public float speed;
    public float Sensitivity;
    private Vector2 MovePos;
    public int MaxX;
    public int MaxY;
    public int MinX;
    public int MinY;

    // Start is called before the first frame update
    void Start()
    {
        Startingpos = new Vector3(1, 2, 1);
        transform.position = Startingpos;
        MovePos = Startingpos;
        MaxX = 5;
        MaxY = 10;
        MinX = -15;
        MinY = -6;
        Sensitivity = 0.1f;
    }

    public int check = 0;

    public void checkup()
    {
        check = 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(check == 1)
        {
            float horizontal = Input.GetAxis("Horizontal") * Sensitivity;
            float vertical = Input.GetAxis("Vertical") * Sensitivity;
            MovePos.x += horizontal;
            MovePos.y += vertical;

            MovePos.x = Mathf.Clamp(MovePos.x, MinX, MaxX);
            MovePos.y = Mathf.Clamp(MovePos.y, MinY, MaxY);

            Heart.transform.position = Vector2.Lerp(transform.position, MovePos, speed * Time.deltaTime);
        }
        
    }
}
