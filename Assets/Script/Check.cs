using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class Check : MonoBehaviour
{
    public static bool state = true;
    //public GameObject[] buttonclick;

    //public Press botton;

    private PhotonView PV;
    public Text displayLoop;
    public Text displayMaxVotecolour;
    //public Text[] displaytext;
    public static int votecolour;
    public static int votetimes;
    private int loop;

    //////////////
    private GameObject CheckAns;
    public CheckAnswer CheckAnsClass;

    public float waitTimevote;

    private List<int> ColorSave = new List<int>();

    private int VoteTrigger;

    private BulbControl _BulbControl;

    private float timestamp;

    public GameObject[] buttonclick;
    public Text[] displaytext;
    public GameObject[] IconCheck;


    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponent<PhotonView>();
        CheckAns = GameObject.Find("CheckAnswerManager");
        CheckAnsClass = CheckAns.GetComponent<CheckAnswer>();
        state = true;

        _BulbControl = GameObject.Find("BulbManager").GetComponent<BulbControl>();
        //PV = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (VoteTrigger == 1)
        {
            VoteTrigger = 0;

            if (votecolour == 1)
            {
                IconCheck[1].SetActive(true);
            }
            if (votecolour == 2)
            {
                IconCheck[2].SetActive(true);
            }
            if (votecolour == 3)
            {
                IconCheck[3].SetActive(true);
            }
            if (votecolour == 4)
            {
                IconCheck[4].SetActive(true);
            }
            if (votecolour == 5)
            {
                IconCheck[5].SetActive(true);
            }
            if (votecolour == 6)
            {
                IconCheck[6].SetActive(true);
            }
            CheckAnsClass.ColorAfterVote(votecolour, TimeCountdown.columm - 1);

        }

        if (VoteTrigger == 2)
        {

            VoteTrigger = 0;

            if ((TimeCountdown.columm - 1) > 0 && (TimeCountdown.columm - 1) < 4) //  1230  1230  1230
            {
                if (votecolour == 1)
                {
                    buttonclick[1].SetActive(false);
                    IconCheck[1].SetActive(false);
                }
                if (votecolour == 2)
                {
                    buttonclick[2].SetActive(false);
                    IconCheck[2].SetActive(false);
                }
                if (votecolour == 3)
                {
                    buttonclick[3].SetActive(false);
                    IconCheck[3].SetActive(false);
                }
                if (votecolour == 4)
                {
                    buttonclick[4].SetActive(false);
                    IconCheck[4].SetActive(false);
                }
                if (votecolour == 5)
                {
                    buttonclick[5].SetActive(false);
                    IconCheck[5].SetActive(false);
                }
                if (votecolour == 6)
                {
                    buttonclick[6].SetActive(false);
                    IconCheck[6].SetActive(false);
                }
            }
            else if ((TimeCountdown.columm - 1) == 0)
            {
                for (int j = 1; j <= 6; j++)
                {
                    buttonclick[j].SetActive(true);
                    IconCheck[j].SetActive(false);
                }
                CheckAnsClass.AnswerCheck(); // CheckAnswer

            }
        }

        //////////////////////////////////////////////////////////////////////

        if (state)
        {
            if (!TimeCountdown.trig_time)
            {
                Press.status = false;
                showcolour();
                state = false;
            }
        }

    }

    void FixedUpdate()
    {
        if (Time.fixedTime - timestamp >= 1f)
        {
            timestamp = Time.fixedTime;
            if (!TimeCountdown.trig_time)
            {
                if (PV.IsMine)
                {
                    PV.RPC("RPC_showVoteTimestamp", RpcTarget.AllBuffered, votecolour);             // Spam Send target
                    PV.RPC("RPC_showloop", RpcTarget.AllBuffered, TimeCountdown.columm - 1);
                    PV.RPC("RPC_showvalueclick", RpcTarget.AllBuffered, 0);
                }

                if ((TimeCountdown.columm - 1) == 0)
                {
                    for (int j = 1; j <= 6; j++)
                    {
                        buttonclick[j].SetActive(true);
                        IconCheck[j].SetActive(false);
                    }

                    CheckAnsClass.AnswerCheck(); // Spam Check Answer
                }
            }

        }
    }

    void showcolour()
    {
        StartCoroutine(Resetvalue());
    }

    IEnumerator Resetvalue()
    {
        Debug.Log("FRAME HERE");
        if (!buttonclick[1].activeSelf)
        {
            Press.countP = 0;
        }
        if (!buttonclick[2].activeSelf)
        {
            Press.countB = 0;
        }
        if (!buttonclick[3].activeSelf)
        {
            Press.countG = 0;
        }
        if (!buttonclick[4].activeSelf)
        {
            Press.countY = 0;
        }
        if (!buttonclick[5].activeSelf)
        {
            Press.countO = 0;
        }
        if (!buttonclick[6].activeSelf)
        {
            Press.countR = 0;
        }

        //////////////////////////////////////////////////////////////////

        votetimes = Mathf.Max(Press.countP, Press.countB, Press.countG, Press.countY, Press.countO, Press.countR);
        ColorSave = new List<int>();

        if (votetimes == Press.countP && buttonclick[1].activeSelf)
        {
            ColorSave.Add(1);
        }
        if (votetimes == Press.countB && buttonclick[2].activeSelf)
        {
            ColorSave.Add(2);
        }
        if (votetimes == Press.countG && buttonclick[3].activeSelf)
        {
            ColorSave.Add(3);
        }
        if (votetimes == Press.countY && buttonclick[4].activeSelf)
        {
            ColorSave.Add(4);
        }
        if (votetimes == Press.countO && buttonclick[5].activeSelf)
        {
            ColorSave.Add(5);
        }
        if (votetimes == Press.countR && buttonclick[6].activeSelf)
        {
            ColorSave.Add(6);
        }
        if (ColorSave.Count >= 2)
        {
            votecolour = ColorSave[Random.Range(0, ColorSave.Count)];
        }
        else
        {
            votecolour = ColorSave[0];
        }

        //.................................................//

        if (PV.IsMine)
        {
            PV.RPC("RPC_showVote", RpcTarget.AllBuffered, votecolour);
        }

        yield return new WaitForSeconds(waitTimevote);

        TimeCountdown.trig_time = true;

        yield return new WaitForSeconds(0.1f);
        Press.status = true;

        state = true;

        Press.countP = 0;
        Press.countB = 0;
        Press.countG = 0;
        Press.countY = 0;
        Press.countO = 0;
        Press.countR = 0;


        ///////////////////////////////////////////////////////////////////////


        if (PV.IsMine)
        {
            PV.RPC("RPC_flasebutton", RpcTarget.AllBuffered, 0);
        }


        yield return new WaitForSeconds(0.1f);

        if (TimeCountdown.columm - 1 == 0)
        {
            _BulbControl.L1_1_ColorNumber = 99;
            _BulbControl.L1_2_ColorNumber = 99;
            _BulbControl.L1_3_ColorNumber = 99;
            _BulbControl.L1_4_ColorNumber = 99;

            /*_BulbControl.L2_1_ColorNumber = 99;
            _BulbControl.L2_2_ColorNumber = 99;
            _BulbControl.L2_3_ColorNumber = 99;
            _BulbControl.L2_4_ColorNumber = 99;*/
        }
        if ((TimeCountdown.columm - 2) == 0)
        {
            _BulbControl.L2_1_ColorNumber = 99;
            _BulbControl.L2_2_ColorNumber = 99;
            _BulbControl.L2_3_ColorNumber = 99;
            _BulbControl.L2_4_ColorNumber = 99;
        }

        Press.countP = 0;
        Press.countB = 0;
        Press.countG = 0;
        Press.countY = 0;
        Press.countO = 0;
        Press.countR = 0;
    }


    [PunRPC]
    void RPC_showVote(int showVote)
    {
        votecolour = showVote;
        displayMaxVotecolour.text = votecolour.ToString();
        VoteTrigger = 1;
    }

    [PunRPC]
    void RPC_showVoteTimestamp(int showVote)
    {
        votecolour = showVote;
        displayMaxVotecolour.text = votecolour.ToString();
    }

    [PunRPC]
    void RPC_showloop(int showloop)
    {
        loop = showloop;
        displayLoop.text = loop.ToString();
    }

    [PunRPC]
    void RPC_showvalueclick(int showclick)
    {
        for (int i = 0; i <= 5; i++)
        {
            displaytext[i].text = showclick.ToString();
        }

    }

    [PunRPC]
    void RPC_flasebutton(int boolbotton)
    {
        VoteTrigger = 2;
    }



}
