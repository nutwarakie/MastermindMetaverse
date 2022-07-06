using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeBar : MonoBehaviour
{
    public Slider slider;

    private float timestamp;
    private float timevalue;
    // Start is called before the first frame update
    void Start()
    {
        timevalue = TimeCountdown.timeplay * 100;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(TimeCountdown.trig_time)
        {
            if (Time.fixedTime - timestamp >= 0.01f)
            {
                timestamp = Time.fixedTime;
                timevalue = timevalue - 2.1f;
                //Debug.Log(timevalue);
                slider.value = timevalue;
            }
        }
        else
        {
            timevalue = (float)(TimeCountdown.timeplay * 100);
        }
        

        
            
    }
}
