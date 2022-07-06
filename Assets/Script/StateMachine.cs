using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class StateMachine : MonoBehaviour
{
            public Text displaytext;
        public int timevote;

        private int timeplay;
        private float timestamp;

        private PhotonView PV;
    public enum State
    {
        start,
        time,
        showcolou,
        click
    }

    public State currenstate;

    // Start is called before the first frame update
    void Start()
    {
        currenstate = State.start;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch(currenstate)
        {
            case State.start:
                currenstate = State.time;
                break;
            case State.time:
                Timevalue();
                break;

        }
    }

    public void Timevalue()
    {



        if (Time.fixedTime - timestamp >= 1f)
        {
            if (timeplay > 0)
            {
                timeplay -= 1;
                timestamp = Time.fixedTime;
                PV.RPC("RPC_Function", RpcTarget.AllBuffered, timeplay);
            }
            else if (timeplay <= 0)
            {
                PV.RPC("RPC_Function", RpcTarget.AllBuffered, timeplay);

                timeplay = timevote;
                Debug.Log(timeplay);
                //trig_time = false;
            }
        }
    }
}
