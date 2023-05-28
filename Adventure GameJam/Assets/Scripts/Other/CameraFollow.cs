using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AGJ.Camera
{
public class CameraFollow : MonoBehaviour
{
    private Vector3 currentPos;
    public Transform transOfPlayer;
        public Vector3 offset;


    // Update is called once per frame
    void Update()
    {
        currentPos = transOfPlayer.position + offset;
        transform.position = currentPos;
    }
}

}

