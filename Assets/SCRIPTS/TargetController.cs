using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    //serialize field for the Camera Controller to access from the editor

    [SerializeField] private Transform player;



    // Update is called once per frame
    void Update()
    {
        transform.position = player.position;
    }
}
