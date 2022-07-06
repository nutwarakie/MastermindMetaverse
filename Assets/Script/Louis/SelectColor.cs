using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectColor : MonoBehaviour
{
    public float originPosX;
    public float originPosY;
    private bool firstTime = true;

    // Update is called once per frame
    private void Update()
    {
        if (firstTime)
        {
            originPosX = this.gameObject.transform.localPosition.x;
            originPosY = this.gameObject.transform.localPosition.y;
            firstTime = false;
        }

    }
}
