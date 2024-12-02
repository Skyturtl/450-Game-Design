using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraFollow : MonoBehaviour
{
    void Start()
    {
       
        CinemachineVirtualCamera virtualCamera = FindObjectOfType<CinemachineVirtualCamera>();

       
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (virtualCamera != null && player != null)
        {
            
            virtualCamera.Follow = player.transform;
        }
    }
}
