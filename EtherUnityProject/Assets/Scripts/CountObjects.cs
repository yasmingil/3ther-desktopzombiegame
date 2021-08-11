using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class CountObjects : MonoBehaviour
{
    // level message: Maybe level completed, or level 2
    // public string nextLevel;

    // object that get destroyed (Maybe the door/ camouflage that reveals the door)
    public GameObject objToDestroy;

    public GameObject keyUI;
    // Start is called before the first frame update
    void Start()
    {
        keyUI = GameObject.Find("KeysNum");
    }

    // Update is called once per frame
    void Update()
    {
        // message display with num keys left
        if(ObjectToCollect.objects > 1)
        {
            keyUI.GetComponent<Text>().text = ObjectToCollect.objects.ToString() + " Keys left";
        }
        else
        {
            keyUI.GetComponent<Text>().text = ObjectToCollect.objects.ToString() + " Key left";
        }
        if(ObjectToCollect.objects == 0)
        {
            // Application.LoadLevel("nextLevel");
            // Destroy door/ door cover 
           // Destroy(objToDestroy);
            keyUI.GetComponent<Text>().text = "Keys Collected. \n Now you may go through the door.";
        }
    }
}
