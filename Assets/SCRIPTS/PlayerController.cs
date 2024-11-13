using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class PlayerController : MonoBehaviour
{
    public TextMeshProUGUI countText;
    public GameObject winTextObject; 

    private float speed;        //How hard the ball is pushed
    private float xDirection;   //Move the ball left and right 
    private float zDirection;   // Move the ball foward and backwards;
    private float count;        //xounts pick ups 

    // Start is called before the first frame update
    void Start()
    {
        speed = 7;
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        GetPlayerInput();
        MoveBall();
        SetCountText();
    }

    private void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

    }

    private void MoveBall()
    {
        Vector3 direction = new Vector3(xDirection, 0, zDirection);
        GetComponent<Rigidbody>().AddForce(direction * speed);
    }

    //listens for the player clicking arrows or W-A-S-D keys
    private void GetPlayerInput()
    {
        xDirection = -Input.GetAxis("Horizontal");
        zDirection = -Input.GetAxis("Vertical"); 
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            
            winTextObject.SetActive(false);
            SetCountText();
            count = count + 1;

            if (count >= 12)
            {
                winTextObject.SetActive(true);
            }
           
        }
    }

}