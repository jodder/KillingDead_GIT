using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    [SerializeField] GameObject player;        


    //private Vector3 offset;            

    
    void Start()
    {
        //player = GameObject.Find("player").gameObject;

        //offset = transform.position - player.transform.position;
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, (player.transform.position.z-10));

    }

    
    void LateUpdate()
    {
        transform.position = new Vector3((player.transform.position.x+ 2), player.transform.position.y, (player.transform.position.z - 10));

        //transform.position = player.transform.position;
    }
}
