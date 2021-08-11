using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorTrigger : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject cam;
    [SerializeField] Vector3 playerTeleport;
    [SerializeField] Vector3 cameraTeleport;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Initialize");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

            Debug.Log("Door triggered");

            //cam.transform.position = cameraTeleport;
            player.transform.position = playerTeleport;

            cam.GetComponent<CameraFollow>().NextLevel();
        }
    }
}