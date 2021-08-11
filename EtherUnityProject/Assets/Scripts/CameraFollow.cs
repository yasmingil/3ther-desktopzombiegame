using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Vector2[] bottomLefts;
    [SerializeField] Vector2[] topRights;
    int level;
    Vector2 bottomLeft;
    Vector2 topRight;

    // Start is called before the first frame update
    void Start()
    {
        level = 1;
        UpdateLevel();
    }

    public void NextLevel()
    {
        level++;
        UpdateLevel();
    }

    private void UpdateLevel()
    {
        bottomLeft = bottomLefts[level - 1];
        topRight = topRights[level - 1];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = player.position;
        newPos.z = Camera.main.transform.position.z;

        if (newPos.x < bottomLeft.x)
        {
            newPos.x = bottomLeft.x;
        }
        if (newPos.x > topRight.x)
        {
            newPos.x = topRight.x;
        }
        if (newPos.y < bottomLeft.y)
        {
            newPos.y = bottomLeft.y;
        }
        if (newPos.y > topRight.y)
        {
            newPos.y = topRight.y;
        }

        Camera.main.transform.position = newPos;

        
    }
}
