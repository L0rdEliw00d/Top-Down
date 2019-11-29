using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPoint : MonoBehaviour
{

    private Player_Movement thePlayer;
    private CameraControl theCamera;

    public string pointName;
    
    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<Player_Movement>();

        if(thePlayer.startPoint == pointName)
        {
            thePlayer.transform.position = new Vector3(transform.position.x, transform.position.y, thePlayer.transform.position.z); 
            theCamera = FindObjectOfType<CameraControl>();
            theCamera.transform.position = new Vector3(transform.position.x, transform.position.y, theCamera.transform.position.z);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
