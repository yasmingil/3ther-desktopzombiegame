using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ObjectToCollect : MonoBehaviour
{
    [SerializeField] GameObject objectToDestroy;
    public static int objects = 0;
    // initialization
     void Awake ()
    {
        // only one key so objects will be 1, unless more than one key
        objects++;
    }

    // update that is called once per frame
    void OnTriggerEnter2D(Collider2D player1)
    {
        //Camera.main.transform.Translate(0, 10, 0);

        // check if object that collided is player
        if (player1.tag == "Player")
        { 
            objects--;
            objectToDestroy.SetActive(false);
            gameObject.SetActive(false);
        }

    }

}
