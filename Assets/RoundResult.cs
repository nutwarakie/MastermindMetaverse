using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundResult : MonoBehaviour
{
    public static int RoundPlayed;
    public static int WinCount;
    public static int LoseCount;
    // Start is called before the first frame update
    void Start()
    {
        RoundPlayed = 0;
        WinCount = 0;
        LoseCount = 0;
        Debug.Log(RoundPlayed);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
