using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class TimeCountdown : MonoBehaviour
{
    public static bool trig_time;
    public static int columm;

    public Text displaytime;
    public Text displaycolumm;
    public int timevote;

    public static int timeplay;
    public static float timestamp;


    private PhotonView PV;
    //public int syncVariable;

    [SerializeField] private AudioSource TimeOutSFX;
    [SerializeField] private AudioSource CountSFX;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("HELLO");
        PV = GetComponent<PhotonView>();
        //Debug.Log(PV);
        //System.Console.WriteLine(PV);
        columm = 1;
        trig_time = true;
        timeplay = timevote;
        PV.RPC("RPC_Function", RpcTarget.AllBuffered, timeplay);
        PV.RPC("RPC_columm", RpcTarget.AllBuffered, columm);
    }


    // Update is called once per frame

    void FixedUpdate()
    {

        if (trig_time)
        {
            if (Time.fixedTime - timestamp >= 1f)
            {

                if (timeplay > 0)
                {

                    timeplay -= 1;
                    timestamp = Time.fixedTime;

                    if (timeplay <= 3)
                    {
                        CountSFX.Play();
                    }
                    if (PV.IsMine)
                    {
                        PV.RPC("RPC_Function", RpcTarget.AllBuffered, timeplay); // 1-1 = 0  --> send 0 to below timeplay = timevote(15) timeplay = syn(0) --> time = 0
                    }
                }
                else if (timeplay <= 0)
                {
                    TimeOutSFX.Play();
                    //PV.RPC("RPC_Function", RpcTarget.AllBuffered, timeplay); // Callfullyyyy !!!!! 555
                    timeplay = timevote + 1;
                    columm = columm + 1;
                    if (PV.IsMine)
                    {
                        PV.RPC("RPC_columm", RpcTarget.AllBuffered, columm);
                    }
                    //Debug.Log(timeplay);
                    trig_time = false;
                }
            }
        }


    }

    [PunRPC]
    void RPC_Function(int syncln_T)
    {
        timeplay = syncln_T;
        displaytime.text = timeplay.ToString();
    }

    [PunRPC]
    void RPC_columm(int syncln_C)
    {
        columm = syncln_C;
        if (columm >= 5)
        {
            columm = 1;
        }
        displaycolumm.text = columm.ToString();
    }



}
