using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed;
    public float health;
    public float power;
    public float rotationSpeed;
    private bool isMoving = false;

    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;
    }
    
    // Update is called once per frame
    void Update()
    {
        isMoving = false;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) 
        { 
            transform.Translate(0, 0, speed * Time.deltaTime);
            isMoving = true;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        { 
            transform.Translate(0, 0, -speed * Time.deltaTime);
            isMoving = true;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) 
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
            isMoving = true;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
            isMoving = true;
        }

        if (isMoving)
        {
            anim.SetInteger("Walk", 1);
        }
        else
        {
            anim.SetInteger("Walk", 0);
        }

        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(0, mouseX * rotationSpeed * Time.deltaTime , 0);
        //float mouseY = Input.GetAxis("Mouse Y");
        //transform.Rotate(mouseY * rotationSpeed * Time.deltaTime, 0, 0);
    }
}
