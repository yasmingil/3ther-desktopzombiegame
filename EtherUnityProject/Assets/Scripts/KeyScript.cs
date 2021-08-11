using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    //public GameObject objToDestroy;

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
            Debug.Log("Triggered");
            gameObject.SetActive(false);
            //Destroy(objToDestroy);
        }
    }
}
