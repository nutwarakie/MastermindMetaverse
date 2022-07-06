using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class Press : MonoBehaviour
{
    public static int countP = 0;
    public static int countB = 0;
    public static int countG = 0;
    public static int countY = 0;
    public static int countO = 0;
    public static int countR = 0;
    //char a;
    //public int countC = 0;

    public Text displaytext_P;
    public Text displaytext_B;
    public Text displaytext_G;
    public Text displaytext_Y;
    public Text displaytext_O;
    public Text displaytext_R;


    public static bool status = true;
    private PhotonView PV;

    public GameObject blockvote;

    //public static  GameObject[] IconCheck;


    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponent<PhotonView>();
        status = true;
        countP = 0;
        countB = 0;
        countG = 0;
        countY = 0;
        countO = 0;
        countR = 0;
    }

    private void Update()
    {
        if(!status)
        {
            blockvote.SetActive(true);
        }
        else
        {
            blockvote.SetActive(false);

            /*
            for(int i=1;i<7;i++)
            {
                IconCheck[i].SetActive(false);
            }
            */
        }
    }

    public void pressbutton_P()
    {
        if (status)
        {
            PV.RPC("RPC_Botton", RpcTarget.AllBuffered, 1);
            //status = false;

            //IconCheck[1].SetActive(true);
        }
    }
    public void pressbutton_B()
    {
        if (status)
        {
            PV.RPC("RPC_Botton", RpcTarget.AllBuffered, 2);
            //status = false;

            //IconCheck[2].SetActive(true);
        }
    }

    public void pressbutton_G()
    {
        if (status)
        {
            PV.RPC("RPC_Botton", RpcTarget.AllBuffered, 3);
            //status = false;

            //IconCheck[3].SetActive(true);
        }
    }

    public void pressbutton_Y()
    {
        if (status)
        {
            PV.RPC("RPC_Botton", RpcTarget.AllBuffered, 4);
            //status = false;

            //IconCheck[4].SetActive(true);
        }
    }

    public void pressbutton_O()
    {
        if (status)
        {
            PV.RPC("RPC_Botton", RpcTarget.AllBuffered, 5);
            //status = false;

            //IconCheck[5].SetActive(true);
        }
    }

    public void pressbutton_R()
    {
        if (status)
        {
            PV.RPC("RPC_Botton", RpcTarget.AllBuffered, 6);
            //status = false;

            //IconCheck[6].SetActive(true);
        }
    }

    [PunRPC]
    void RPC_Botton(int value)
    {
        if(value == 1)
        {
            countP += 1;
            displaytext_P.text = countP.ToString();
        }
        else if (value == 2)
        {
            countB += 1;
            displaytext_B.text = countB.ToString();
        }
        else if (value == 3)
        {
            countG += 1;
            displaytext_G.text = countG.ToString();
        }
        else if (value == 4)
        {
            countY += 1;
            displaytext_Y.text = countY.ToString();
        }
        else if (value == 5)
        {
            countO += 1;
            displaytext_O.text = countO.ToString();
        }
        else if (value == 6)
        {
            countR += 1;
            displaytext_R.text = countR.ToString();
        }
        //displaytext_R.text = countR.ToString();
        //displaytext_B.text = countB.ToString();
    }

}
