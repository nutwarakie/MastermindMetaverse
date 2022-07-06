using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Photon.Pun;

public class CheckAnswer : MonoBehaviour
{
    private PhotonView PV;
    private GameObject firstColor;
    private GameObject secondColor;
    private GameObject thirdColor;
    private GameObject fourthColor;
    private GameObject fifthColor;
    private GameObject sixthColor;

    private GameObject OneOne;
    private GameObject OneTwo;
    private GameObject OneThree;
    private GameObject OneFour;
    private GameObject TwoOne;
    private GameObject TwoTwo;
    private GameObject TwoThree;
    private GameObject TwoFour;
    private GameObject ThreeOne;
    private GameObject ThreeTwo;
    private GameObject ThreeThree;
    private GameObject ThreeFour;
    private GameObject FourOne;
    private GameObject FourTwo;
    private GameObject FourThree;
    private GameObject FourFour;
    private GameObject FiveOne;
    private GameObject FiveTwo;
    private GameObject FiveThree;
    private GameObject FiveFour;

    private GameObject SolveOne;
    private GameObject SolveTwo;
    private GameObject SolveThree;
    private GameObject SolveFour;

    //private float firstColorOriginX;
    //private float firstColorOriginY;
    //private float secondColorOriginX;
    //private float secondColorOriginY;
    //private float thirdColorOriginX;
    //private float thirdColorOriginY;
    //private float fourthColorOriginX;
    //private float fourthColorOriginY;
    //private float fifthColorOriginX;
    //private float fifthColorOriginY;
    //private float sixthColorOriginX;
    //private float sixthColorOriginY;

    //public float AnsOneX;
    //public float AnsOneY;
    //public float AnsTwoX;
    //public float AnsTwoY;
    //public float AnsThreeX;
    //public float AnsThreeY;
    //public float AnsFourX;
    //public float AnsFourY;

    public GameObject AnsOne;
    public GameObject AnsTwo;
    public GameObject AnsThree;
    public GameObject AnsFour;

    private GameObject Answer;
    private RandomAnswer AnswerRequest;
    private List<int> AnswerList = new List<int>();
    private int CorrectColor;
    private int CorrectPos;
    private int CheckPos;
    private int ReadyColor;
    public int CurrentLevel;

    private int ColorStateOne;
    private int ColorStateTwo;
    private int ColorStateThree;
    private int ColorStateFour;

    private Color ColorOne;
    private Color ColorTwo;
    private Color ColorThree;
    private Color ColorFour;

    private GameObject C_OneOne;
    private GameObject C_OneTwo;
    private GameObject C_OneThree;
    private GameObject C_OneFour;
    private GameObject C_TwoOne;
    private GameObject C_TwoTwo;
    private GameObject C_TwoThree;
    private GameObject C_TwoFour;
    private GameObject C_ThreeOne;
    private GameObject C_ThreeTwo;
    private GameObject C_ThreeThree;
    private GameObject C_ThreeFour;
    private GameObject C_FourOne;
    private GameObject C_FourTwo;
    private GameObject C_FourThree;
    private GameObject C_FourFour;
    private GameObject C_FiveOne;
    private GameObject C_FiveTwo;
    private GameObject C_FiveThree;
    private GameObject C_FiveFour;

    public GameObject H_OneOne;
    public GameObject H_OneTwo;
    public GameObject H_OneThree;
    public GameObject H_OneFour;
    public GameObject H_TwoOne;
    public GameObject H_TwoTwo;
    public GameObject H_TwoThree;
    public GameObject H_TwoFour;
    public GameObject H_ThreeOne;
    public GameObject H_ThreeTwo;
    public GameObject H_ThreeThree;
    public GameObject H_ThreeFour;
    public GameObject H_FourOne;
    public GameObject H_FourTwo;
    public GameObject H_FourThree;
    public GameObject H_FourFour;
    public GameObject H_FiveOne;
    public GameObject H_FiveTwo;
    public GameObject H_FiveThree;
    public GameObject H_FiveFour;

    private GameObject VoteOne;
    private GameObject VoteTwo;
    private GameObject VoteThree;
    private GameObject VoteFour;

    private GameObject HighlightOne;
    private GameObject HighlightTwo;
    private GameObject HighlightThree;
    private GameObject HighlightFour;

    private int StateCheckOne;
    private int StateCheckTwo;
    private int StateCheckThree;
    private int StateCheckFour;

    private Color GreenColor;
    private Color YellowColor;
    private Color RedColor;

    public static int Answer_1;
    public static int Answer_2;
    public static int Answer_3;
    public static int Answer_4;

    private int ReadyColorState;

    public static bool EndGame = false;
    public static int happyending = 0;

    private BulbControl _BulbControl;




    private void Start()
    {
        PV = GetComponent<PhotonView>();

        firstColor = GameObject.Find("Choice-1");
        secondColor = GameObject.Find("Choice-2");
        thirdColor = GameObject.Find("Choice-3");
        fourthColor = GameObject.Find("Choice-4");
        fifthColor = GameObject.Find("Choice-5");
        sixthColor = GameObject.Find("Choice-6");

        OneOne = GameObject.Find("1-1");
        OneTwo = GameObject.Find("1-2");
        OneThree = GameObject.Find("1-3");
        OneFour = GameObject.Find("1-4");
        TwoOne = GameObject.Find("2-1");
        TwoTwo = GameObject.Find("2-2");
        TwoThree = GameObject.Find("2-3");
        TwoFour = GameObject.Find("2-4");
        ThreeOne = GameObject.Find("3-1");
        ThreeTwo = GameObject.Find("3-2");
        ThreeThree = GameObject.Find("3-3");
        ThreeFour = GameObject.Find("3-4");
        FourOne = GameObject.Find("4-1");
        FourTwo = GameObject.Find("4-2");
        FourThree = GameObject.Find("4-3");
        FourFour = GameObject.Find("4-4");
        FiveOne = GameObject.Find("5-1");
        FiveTwo = GameObject.Find("5-2");
        FiveThree = GameObject.Find("5-3");
        FiveFour = GameObject.Find("5-4");

        SolveOne = GameObject.Find("Answer-1");
        SolveTwo = GameObject.Find("Answer-2");
        SolveThree = GameObject.Find("Answer-3");
        SolveFour = GameObject.Find("Answer-4");

        Answer = GameObject.Find("Random");
        AnswerRequest = Answer.GetComponent<RandomAnswer>();

        _BulbControl = GameObject.Find("BulbManager").GetComponent<BulbControl>();


        /*Answer_1 = RandomAnswer.Ans1;
        Answer_2 = RandomAnswer.Ans2;
        Answer_3 = RandomAnswer.Ans3;
        Answer_4 = RandomAnswer.Ans4;

        Debug.Log(Answer_1);
        Debug.Log(Answer_1);
        Debug.Log(Answer_1);
        Debug.Log(Answer_1);*/

        /*AnswerList.Add(Answer_1);
        AnswerList.Add(Answer_2);
        AnswerList.Add(Answer_3);
        AnswerList.Add(Answer_4);*/

        /*foreach (var x in AnswerList)
        {
            Debug.Log(x);
        }*/

        CorrectColor = 0;
        CurrentLevel = 0;

        C_OneOne = GameObject.Find("C1-1");
        C_OneTwo = GameObject.Find("C1-2");
        C_OneThree = GameObject.Find("C1-3");
        C_OneFour = GameObject.Find("C1-4");
        C_TwoOne = GameObject.Find("C2-1");
        C_TwoTwo = GameObject.Find("C2-2");
        C_TwoThree = GameObject.Find("C2-3");
        C_TwoFour = GameObject.Find("C2-4");
        C_ThreeOne = GameObject.Find("C3-1");
        C_ThreeTwo = GameObject.Find("C3-2");
        C_ThreeThree = GameObject.Find("C3-3");
        C_ThreeFour = GameObject.Find("C3-4");
        C_FourOne = GameObject.Find("C4-1");
        C_FourTwo = GameObject.Find("C4-2");
        C_FourThree = GameObject.Find("C4-3");
        C_FourFour = GameObject.Find("C4-4");
        C_FiveOne = GameObject.Find("C5-1");
        C_FiveTwo = GameObject.Find("C5-2");
        C_FiveThree = GameObject.Find("C5-3");
        C_FiveFour = GameObject.Find("C5-4");

        /*H_OneOne = GameObject.Find("H1-1");
        H_OneTwo = GameObject.Find("H1-2");
        H_OneThree = GameObject.Find("H1-3");
        H_OneFour = GameObject.Find("H1-4");
        H_TwoOne = GameObject.Find("H2-1");
        H_TwoTwo = GameObject.Find("H2-2");
        H_TwoThree = GameObject.Find("H2-3");
        H_TwoFour = GameObject.Find("H2-4");
        H_ThreeOne = GameObject.Find("H3-1");
        H_ThreeTwo = GameObject.Find("H3-2");
        H_ThreeThree = GameObject.Find("H3-3");
        H_ThreeFour = GameObject.Find("H3-4");
        H_FourOne = GameObject.Find("H4-1");
        H_FourTwo = GameObject.Find("H4-2");
        H_FourThree = GameObject.Find("H4-3");
        H_FourFour = GameObject.Find("H4-4");
        H_FiveOne = GameObject.Find("H5-1");
        H_FiveTwo = GameObject.Find("H5-2");
        H_FiveThree = GameObject.Find("H5-3");
        H_FiveFour = GameObject.Find("H5-4");*/

        if (PV.IsMine)
        {
            _BulbControl.Motor_StatusNumber = 2;
        }

    }
    void Update()
    {
        /*if (Input.GetKeyDown("1"))
        {
            _BulbControl.L1_1_ColorNumber = 1 ;
        }*/
        /*
        if (PV.IsMine)
        {
            PV.RPC("RPC_AnswerCheck", RpcTarget.All, CurrentLevel, CorrectColor, CorrectPos, ReadyColor,
            StateCheckOne, StateCheckTwo, StateCheckThree, StateCheckFour, ColorStateOne, ColorStateTwo,
            ColorStateThree, ColorStateFour);

        }
        */

        if (ReadyColor == 4 && ReadyColorState == 1)
        {
            EachReadyColor();
            /*if (PV.IsMine)
            {
                PV.RPC("RPC_MoveLevel", RpcTarget.All, CurrentLevel);
            }*/
        }
    }

    [PunRPC]
    void RPC_AnswerCheck(int CorrectColor_value, int CorrectPos_value, int ReadyColor_value,
    int StateCheckOne_value, int StateCheckTwo_value, int StateCheckThree_value, int StateCheckFour_value, int ColorStateOne_value,
    int ColorStateTwo_value, int ColorStateThree_value, int ColorStateFour_value)
    {
        CorrectColor = CorrectColor_value;
        CorrectPos = CorrectPos_value;
        ReadyColor = ReadyColor_value;
        StateCheckOne = StateCheckOne_value;
        StateCheckTwo = StateCheckTwo_value;
        StateCheckThree = StateCheckThree_value;
        StateCheckFour = StateCheckFour_value;
        ColorStateOne = ColorStateOne_value;
        ColorStateTwo = ColorStateTwo_value;
        ColorStateThree = ColorStateThree_value;
        ColorStateFour = ColorStateFour_value;

        //Debug.Log(CurrentLevel);
        //Debug.Log(ReadyColor);
    }
    [PunRPC]
    void RPC_EachReadyColor(int ReadyColorState_value)
    {
        if (ReadyColorState_value != 0)
        {
            ReadyColorState = ReadyColorState_value;
        }
    }
    [PunRPC]
    void RPC_MoveLevel(int CurrentLevel_value)
    {
        CurrentLevel = CurrentLevel_value;
    }

    public void ColorAfterVote(int mostVoteColor, int voteNumber)
    {
        if (FiveFour.GetComponent<SpriteRenderer>().color == SolveFour.GetComponent<SpriteRenderer>().color)
        {
            CurrentLevel = 4;
            if (FourFour.GetComponent<SpriteRenderer>().color == SolveFour.GetComponent<SpriteRenderer>().color)
            {
                CurrentLevel = 3;
                if (ThreeFour.GetComponent<SpriteRenderer>().color == SolveFour.GetComponent<SpriteRenderer>().color)
                {
                    CurrentLevel = 2;
                    if (TwoFour.GetComponent<SpriteRenderer>().color == SolveFour.GetComponent<SpriteRenderer>().color)
                    {
                        CurrentLevel = 1;
                        if (OneFour.GetComponent<SpriteRenderer>().color == SolveFour.GetComponent<SpriteRenderer>().color)
                        {
                            CurrentLevel = 0;
                        }
                    }
                }
            }
        }

        if (CurrentLevel == 0)
        {
            VoteOne = OneOne;
            VoteTwo = OneTwo;
            VoteThree = OneThree;
            VoteFour = OneFour;

            HighlightOne = H_OneTwo;
            HighlightTwo = H_OneThree;
            HighlightThree = H_OneFour;
            HighlightFour = H_TwoOne;

            H_OneOne.SetActive(false);
        }
        else if (CurrentLevel == 1)
        {
            VoteOne = TwoOne;
            VoteTwo = TwoTwo;
            VoteThree = TwoThree;
            VoteFour = TwoFour;

            HighlightOne = H_TwoTwo;
            HighlightTwo = H_TwoThree;
            HighlightThree = H_TwoFour;
            HighlightFour = H_ThreeOne;

            H_TwoOne.SetActive(false);
        }
        else if (CurrentLevel == 2)
        {
            VoteOne = ThreeOne;
            VoteTwo = ThreeTwo;
            VoteThree = ThreeThree;
            VoteFour = ThreeFour;

            HighlightOne = H_ThreeTwo;
            HighlightTwo = H_ThreeThree;
            HighlightThree = H_ThreeFour;
            HighlightFour = H_FourOne;

            H_ThreeOne.SetActive(false);
        }
        else if (CurrentLevel == 3)
        {
            VoteOne = FourOne;
            VoteTwo = FourTwo;
            VoteThree = FourThree;
            VoteFour = FourFour;

            HighlightOne = H_FourTwo;
            HighlightTwo = H_FourThree;
            HighlightThree = H_FourFour;
            HighlightFour = H_FiveOne;

            H_FourOne.SetActive(false);
        }
        else if (CurrentLevel == 4)
        {
            VoteOne = FiveOne;
            VoteTwo = FiveTwo;
            VoteThree = FiveThree;
            VoteFour = FiveFour;

            HighlightOne = H_FiveTwo;
            HighlightTwo = H_FiveThree;
            HighlightThree = H_FiveFour;
            HighlightFour = H_FiveFour;

            H_FiveOne.SetActive(false);
        }

        HighlightOne.SetActive(false);
        HighlightTwo.SetActive(false);
        HighlightThree.SetActive(false);
        HighlightFour.SetActive(false);

        if (voteNumber == 1)
        {
            HighlightOne.SetActive(true);

        }
        else if (voteNumber == 2)
        {
            HighlightTwo.SetActive(true);

        }
        else if (voteNumber == 3)
        {
            HighlightThree.SetActive(true);

        }
        else if (voteNumber == 0)
        {
            HighlightFour.SetActive(true);

        }

        if (mostVoteColor == 1)
        {
            if (voteNumber == 1)
            {
                _BulbControl.L1_1_ColorNumber = mostVoteColor;
                MoveVoteColor(firstColor, VoteOne);
            }
            else if (voteNumber == 2)
            {
                _BulbControl.L1_2_ColorNumber = mostVoteColor;
                MoveVoteColor(firstColor, VoteTwo);
            }
            else if (voteNumber == 3)
            {
                _BulbControl.L1_3_ColorNumber = mostVoteColor;
                MoveVoteColor(firstColor, VoteThree);
            }
            else if (voteNumber == 0)
            {
                _BulbControl.L1_4_ColorNumber = mostVoteColor;
                MoveVoteColor(firstColor, VoteFour);
            }
        }
        else if (mostVoteColor == 2)
        {
            if (voteNumber == 1)
            {
                _BulbControl.L1_1_ColorNumber = mostVoteColor;
                MoveVoteColor(secondColor, VoteOne);
            }
            else if (voteNumber == 2)
            {
                _BulbControl.L1_2_ColorNumber = mostVoteColor;
                MoveVoteColor(secondColor, VoteTwo);
            }
            else if (voteNumber == 3)
            {
                _BulbControl.L1_3_ColorNumber = mostVoteColor;
                MoveVoteColor(secondColor, VoteThree);
            }
            else if (voteNumber == 0)
            {
                _BulbControl.L1_4_ColorNumber = mostVoteColor;
                MoveVoteColor(secondColor, VoteFour);
            }
        }
        else if (mostVoteColor == 3)
        {
            if (voteNumber == 1)
            {
                _BulbControl.L1_1_ColorNumber = mostVoteColor;
                MoveVoteColor(thirdColor, VoteOne);
            }
            else if (voteNumber == 2)
            {
                _BulbControl.L1_2_ColorNumber = mostVoteColor;
                MoveVoteColor(thirdColor, VoteTwo);
            }
            else if (voteNumber == 3)
            {
                _BulbControl.L1_3_ColorNumber = mostVoteColor;
                MoveVoteColor(thirdColor, VoteThree);
            }
            else if (voteNumber == 0)
            {
                _BulbControl.L1_4_ColorNumber = mostVoteColor;
                MoveVoteColor(thirdColor, VoteFour);
            }
        }
        else if (mostVoteColor == 4)
        {
            if (voteNumber == 1)
            {
                _BulbControl.L1_1_ColorNumber = mostVoteColor;
                MoveVoteColor(fourthColor, VoteOne);
            }
            else if (voteNumber == 2)
            {
                _BulbControl.L1_2_ColorNumber = mostVoteColor;
                MoveVoteColor(fourthColor, VoteTwo);
            }
            else if (voteNumber == 3)
            {
                _BulbControl.L1_3_ColorNumber = mostVoteColor;
                MoveVoteColor(fourthColor, VoteThree);
            }
            else if (voteNumber == 0)
            {
                _BulbControl.L1_4_ColorNumber = mostVoteColor;
                MoveVoteColor(fourthColor, VoteFour);
            }
        }
        else if (mostVoteColor == 5)
        {
            if (voteNumber == 1)
            {
                _BulbControl.L1_1_ColorNumber = mostVoteColor;
                MoveVoteColor(fifthColor, VoteOne);
            }
            else if (voteNumber == 2)
            {
                _BulbControl.L1_2_ColorNumber = mostVoteColor;
                MoveVoteColor(fifthColor, VoteTwo);
            }
            else if (voteNumber == 3)
            {
                _BulbControl.L1_3_ColorNumber = mostVoteColor;
                MoveVoteColor(fifthColor, VoteThree);
            }
            else if (voteNumber == 0)
            {
                _BulbControl.L1_4_ColorNumber = mostVoteColor;
                MoveVoteColor(fifthColor, VoteFour);
            }
        }
        else if (mostVoteColor == 6)
        {
            if (voteNumber == 1)
            {
                _BulbControl.L1_1_ColorNumber = mostVoteColor;
                MoveVoteColor(sixthColor, VoteOne);
            }
            else if (voteNumber == 2)
            {
                _BulbControl.L1_2_ColorNumber = mostVoteColor;
                MoveVoteColor(sixthColor, VoteTwo);
            }
            else if (voteNumber == 3)
            {
                _BulbControl.L1_3_ColorNumber = mostVoteColor;
                MoveVoteColor(sixthColor, VoteThree);
            }
            else if (voteNumber == 0)
            {
                _BulbControl.L1_4_ColorNumber = mostVoteColor;
                MoveVoteColor(sixthColor, VoteFour);
            }
        }
    }

    public void MoveVoteColor(GameObject ColorObject, GameObject VoteObject)
    {
        VoteObject.GetComponent<SpriteRenderer>().color = ColorObject.GetComponent<SpriteRenderer>().color;
        if (VoteObject.GetComponent<SpriteRenderer>().color != ColorObject.GetComponent<SpriteRenderer>().color)
        {
            MoveVoteColor(ColorObject, VoteObject);
        }
    }

    public void CheckColor(GameObject ColorCheck, GameObject PositionCheck, int ColorNumber)
    {
        if (ColorCheck.GetComponent<SpriteRenderer>().color == PositionCheck.GetComponent<SpriteRenderer>().color)
        {
            ReadyColor += 1;
            if (AnswerList.Contains(ColorNumber))
            {
                CorrectColor += 1;
            }
            CheckPos = AnswerList.IndexOf(ColorNumber);
            if (PositionCheck == AnsOne)
            {

                if (AnswerList.Contains(ColorNumber))
                {
                    if (CheckPos == 0)
                    {
                        CorrectPos += 1;
                        CorrectColor += -1;
                        StateCheckOne = 2;
                    }
                    else
                    {
                        StateCheckOne = 1;
                    }
                }
                else
                {
                    StateCheckOne = 0;
                }
            }
            else if (PositionCheck == AnsTwo)
            {

                if (AnswerList.Contains(ColorNumber))
                {
                    if (CheckPos == 1)
                    {
                        CorrectPos += 1;
                        CorrectColor += -1;
                        StateCheckTwo = 2;
                    }
                    else
                    {
                        StateCheckTwo = 1;
                    }
                }
                else
                {
                    StateCheckTwo = 0;
                }
            }
            else if (PositionCheck == AnsThree)
            {

                if (AnswerList.Contains(ColorNumber))
                {
                    if (CheckPos == 2)
                    {
                        CorrectPos += 1;
                        CorrectColor += -1;
                        StateCheckThree = 2;
                    }
                    else
                    {
                        StateCheckThree = 1;
                    }
                }
                else
                {
                    StateCheckThree = 0;
                }
            }
            else if (PositionCheck == AnsFour)
            {

                if (AnswerList.Contains(ColorNumber))
                {
                    if (CheckPos == 3)
                    {
                        CorrectPos += 1;
                        CorrectColor += -1;
                        StateCheckFour = 2;
                    }
                    else
                    {
                        StateCheckFour = 1;
                    }
                }
                else
                {
                    StateCheckFour = 0;
                }
            }
        }
    }

    public void AnswerCheck()
    {
        //CurrentLevel += 1;

        AnswerList = AnswerRequest.Request();
        CorrectColor = 0;
        CorrectPos = 0;
        ReadyColor = 0;

        foreach (var x in AnswerList)
        {
            Debug.Log(x);
        }

        /*firstColorOriginX = firstColor.GetComponent<SelectColor>().originPosX;
        firstColorOriginY = firstColor.GetComponent<SelectColor>().originPosY;
        secondColorOriginX = secondColor.GetComponent<SelectColor>().originPosX;
        secondColorOriginY = secondColor.GetComponent<SelectColor>().originPosY;
        thirdColorOriginX = thirdColor.GetComponent<SelectColor>().originPosX;
        thirdColorOriginY = thirdColor.GetComponent<SelectColor>().originPosY;
        fourthColorOriginX = fourthColor.GetComponent<SelectColor>().originPosX;
        fourthColorOriginY = fourthColor.GetComponent<SelectColor>().originPosY;
        fifthColorOriginX = fifthColor.GetComponent<SelectColor>().originPosX;
        fifthColorOriginY = fifthColor.GetComponent<SelectColor>().originPosY;
        sixthColorOriginX = sixthColor.GetComponent<SelectColor>().originPosX;
        sixthColorOriginY = sixthColor.GetComponent<SelectColor>().originPosY;*/

        if (CurrentLevel == 0)
        {
            AnsOne = OneOne;
            AnsTwo = OneTwo;
            AnsThree = OneThree;
            AnsFour = OneFour;

        }
        else if (CurrentLevel == 1)
        {
            AnsOne = TwoOne;
            AnsTwo = TwoTwo;
            AnsThree = TwoThree;
            AnsFour = TwoFour;
        }
        else if (CurrentLevel == 2)
        {
            AnsOne = ThreeOne;
            AnsTwo = ThreeTwo;
            AnsThree = ThreeThree;
            AnsFour = ThreeFour;
        }
        else if (CurrentLevel == 3)
        {
            AnsOne = FourOne;
            AnsTwo = FourTwo;
            AnsThree = FourThree;
            AnsFour = FourFour;
        }
        else if (CurrentLevel == 4)
        {
            AnsOne = FiveOne;
            AnsTwo = FiveTwo;
            AnsThree = FiveThree;
            AnsFour = FiveFour;
        }

        CheckColor(firstColor, AnsOne, 1);
        CheckColor(firstColor, AnsTwo, 1);
        CheckColor(firstColor, AnsThree, 1);
        CheckColor(firstColor, AnsFour, 1);

        CheckColor(secondColor, AnsOne, 2);
        CheckColor(secondColor, AnsTwo, 2);
        CheckColor(secondColor, AnsThree, 2);
        CheckColor(secondColor, AnsFour, 2);

        CheckColor(thirdColor, AnsOne, 3);
        CheckColor(thirdColor, AnsTwo, 3);
        CheckColor(thirdColor, AnsThree, 3);
        CheckColor(thirdColor, AnsFour, 3);

        CheckColor(fourthColor, AnsOne, 4);
        CheckColor(fourthColor, AnsTwo, 4);
        CheckColor(fourthColor, AnsThree, 4);
        CheckColor(fourthColor, AnsFour, 4);

        CheckColor(fifthColor, AnsOne, 5);
        CheckColor(fifthColor, AnsTwo, 5);
        CheckColor(fifthColor, AnsThree, 5);
        CheckColor(fifthColor, AnsFour, 5);

        CheckColor(sixthColor, AnsOne, 6);
        CheckColor(sixthColor, AnsTwo, 6);
        CheckColor(sixthColor, AnsThree, 6);
        CheckColor(sixthColor, AnsFour, 6);

        ReadyColorState = 1;
        //PV.RPC("RPC_EachReadyColor", RpcTarget.All, ReadyColorState);

        if (PV.IsMine)
        {
            //PV.RPC("RPC_AnswerCheck", RpcTarget.AllBuffered, CorrectColor, CorrectPos, ReadyColor,
            //StateCheckOne, StateCheckTwo, StateCheckThree, StateCheckFour, ColorStateOne, ColorStateTwo,
            //ColorStateThree, ColorStateFour);

            PV.RPC("RPC_EachReadyColor", RpcTarget.AllBuffered, ReadyColorState);
        }

    }
    private void EachReadyColor()
    {
        if (CurrentLevel == 0)
        {
            StateCheckColor(C_OneOne, C_OneTwo, C_OneThree, C_OneFour, StateCheckOne, StateCheckTwo, StateCheckThree, StateCheckFour);

            TwoOne.tag = "Placement";
            TwoTwo.tag = "Placement";
            TwoThree.tag = "Placement";
            TwoFour.tag = "Placement";
        }
        else if (CurrentLevel == 1)
        {
            StateCheckColor(C_TwoOne, C_TwoTwo, C_TwoThree, C_TwoFour, StateCheckOne, StateCheckTwo, StateCheckThree, StateCheckFour);

            ThreeOne.tag = "Placement";
            ThreeTwo.tag = "Placement";
            ThreeThree.tag = "Placement";
            ThreeFour.tag = "Placement";

        }
        else if (CurrentLevel == 2)
        {
            StateCheckColor(C_ThreeOne, C_ThreeTwo, C_ThreeThree, C_ThreeFour, StateCheckOne, StateCheckTwo, StateCheckThree, StateCheckFour);

            FourOne.tag = "Placement";
            FourTwo.tag = "Placement";
            FourThree.tag = "Placement";
            FourFour.tag = "Placement";


        }
        else if (CurrentLevel == 3)
        {
            StateCheckColor(C_FourOne, C_FourTwo, C_FourThree, C_FourFour, StateCheckOne, StateCheckTwo, StateCheckThree, StateCheckFour);

            FiveOne.tag = "Placement";
            FiveTwo.tag = "Placement";
            FiveThree.tag = "Placement";
            FiveFour.tag = "Placement";
        }
        else if (CurrentLevel == 4)
        {
            StateCheckColor(C_FiveOne, C_FiveTwo, C_FiveThree, C_FiveFour, StateCheckOne, StateCheckTwo, StateCheckThree, StateCheckFour);

            if (CorrectPos != 4)
            {
                SaveColor(SolveOne, SolveTwo, SolveThree, SolveFour, AnswerList[0], AnswerList[1], AnswerList[2], AnswerList[3]);
                _BulbControl.L3_1_ColorNumber = AnswerList[0];
                _BulbControl.L3_2_ColorNumber = AnswerList[1];
                _BulbControl.L3_3_ColorNumber = AnswerList[2];
                _BulbControl.L3_4_ColorNumber = AnswerList[3];
                if (PV.IsMine)
                {
                    _BulbControl.Motor_StatusNumber = 1;
                }
                EndGame = true;
                happyending = 1;
            }

        }

        if (CorrectPos == 4)
        {
            SaveColor(SolveOne, SolveTwo, SolveThree, SolveFour, AnswerList[0], AnswerList[1], AnswerList[2], AnswerList[3]);
            _BulbControl.L3_1_ColorNumber = AnswerList[0];
            _BulbControl.L3_2_ColorNumber = AnswerList[1];
            _BulbControl.L3_3_ColorNumber = AnswerList[2];
            _BulbControl.L3_4_ColorNumber = AnswerList[3];
            if (PV.IsMine)
            {
                _BulbControl.Motor_StatusNumber = 1;
            }
            EndGame = true;
            happyending = 2;
        }

        Debug.Log("correct color = " + CorrectColor);
        Debug.Log("correct position = " + CorrectPos);
        Debug.Log("Current Level = " + CurrentLevel);

        ReadyColorState = 0;
    }


    private void SaveColor(GameObject One, GameObject Two, GameObject Three, GameObject Four, int SaveOne, int SaveTwo, int SaveThree, int SaveFour)
    {
        if (SaveOne == 1)
        {
            ColorOne = firstColor.GetComponent<SpriteRenderer>().color;
        }
        else if (SaveOne == 2)
        {
            ColorOne = secondColor.GetComponent<SpriteRenderer>().color;
        }
        else if (SaveOne == 3)
        {
            ColorOne = thirdColor.GetComponent<SpriteRenderer>().color;
        }
        else if (SaveOne == 4)
        {
            ColorOne = fourthColor.GetComponent<SpriteRenderer>().color;
        }
        else if (SaveOne == 5)
        {
            ColorOne = fifthColor.GetComponent<SpriteRenderer>().color;
        }
        else if (SaveOne == 6)
        {
            ColorOne = sixthColor.GetComponent<SpriteRenderer>().color;
        }
        if (SaveTwo == 1)
        {
            ColorTwo = firstColor.GetComponent<SpriteRenderer>().color;
        }
        else if (SaveTwo == 2)
        {
            ColorTwo = secondColor.GetComponent<SpriteRenderer>().color;
        }
        else if (SaveTwo == 3)
        {
            ColorTwo = thirdColor.GetComponent<SpriteRenderer>().color;
        }
        else if (SaveTwo == 4)
        {
            ColorTwo = fourthColor.GetComponent<SpriteRenderer>().color;
        }
        else if (SaveTwo == 5)
        {
            ColorTwo = fifthColor.GetComponent<SpriteRenderer>().color;
        }
        else if (SaveTwo == 6)
        {
            ColorTwo = sixthColor.GetComponent<SpriteRenderer>().color;
        }
        if (SaveThree == 1)
        {
            ColorThree = firstColor.GetComponent<SpriteRenderer>().color;
        }
        else if (SaveThree == 2)
        {
            ColorThree = secondColor.GetComponent<SpriteRenderer>().color;
        }
        else if (SaveThree == 3)
        {
            ColorThree = thirdColor.GetComponent<SpriteRenderer>().color;
        }
        else if (SaveThree == 4)
        {
            ColorThree = fourthColor.GetComponent<SpriteRenderer>().color;
        }
        else if (SaveThree == 5)
        {
            ColorThree = fifthColor.GetComponent<SpriteRenderer>().color;
        }
        else if (SaveThree == 6)
        {
            ColorThree = sixthColor.GetComponent<SpriteRenderer>().color;
        }
        if (SaveFour == 1)
        {
            ColorFour = firstColor.GetComponent<SpriteRenderer>().color;
        }
        else if (SaveFour == 2)
        {
            ColorFour = secondColor.GetComponent<SpriteRenderer>().color;
        }
        else if (SaveFour == 3)
        {
            ColorFour = thirdColor.GetComponent<SpriteRenderer>().color;
        }
        else if (SaveFour == 4)
        {
            ColorFour = fourthColor.GetComponent<SpriteRenderer>().color;
        }
        else if (SaveFour == 5)
        {
            ColorFour = fifthColor.GetComponent<SpriteRenderer>().color;
        }
        else if (SaveFour == 6)
        {
            ColorFour = sixthColor.GetComponent<SpriteRenderer>().color;
        }

        One.GetComponent<SpriteRenderer>().color = ColorOne;
        Two.GetComponent<SpriteRenderer>().color = ColorTwo;
        Three.GetComponent<SpriteRenderer>().color = ColorThree;
        Four.GetComponent<SpriteRenderer>().color = ColorFour;

        //One.tag = "Checked";
        //Two.tag = "Checked";
        //Three.tag = "Checked";
        //Four.tag = "Checked";

    }

    private void StateCheckColor(GameObject One, GameObject Two, GameObject Three, GameObject Four, int CheckOne, int CheckTwo, int CheckThree, int CheckFour)
    {

        GreenColor = thirdColor.GetComponent<SpriteRenderer>().color;
        YellowColor = fourthColor.GetComponent<SpriteRenderer>().color;
        RedColor = sixthColor.GetComponent<SpriteRenderer>().color;

        if (CheckOne == 2)
        {
            One.GetComponent<SpriteRenderer>().color = GreenColor;
            _BulbControl.L2_1_ColorNumber = 3;
        }
        else if (CheckOne == 1)
        {
            One.GetComponent<SpriteRenderer>().color = YellowColor;
            _BulbControl.L2_1_ColorNumber = 4;
        }
        else if (CheckOne == 0)
        {
            One.GetComponent<SpriteRenderer>().color = RedColor;
            _BulbControl.L2_1_ColorNumber = 6;
        }


        if (CheckTwo == 2)
        {
            Two.GetComponent<SpriteRenderer>().color = GreenColor;
            _BulbControl.L2_2_ColorNumber = 3;
        }
        else if (CheckTwo == 1)
        {
            Two.GetComponent<SpriteRenderer>().color = YellowColor;
            _BulbControl.L2_2_ColorNumber = 4;
        }
        else if (CheckTwo == 0)
        {
            Two.GetComponent<SpriteRenderer>().color = RedColor;
            _BulbControl.L2_2_ColorNumber = 6;
        }


        if (CheckThree == 2)
        {
            Three.GetComponent<SpriteRenderer>().color = GreenColor;
            _BulbControl.L2_3_ColorNumber = 3;
        }
        else if (CheckThree == 1)
        {
            Three.GetComponent<SpriteRenderer>().color = YellowColor;
            _BulbControl.L2_3_ColorNumber = 4;
        }
        else if (CheckThree == 0)
        {
            Three.GetComponent<SpriteRenderer>().color = RedColor;
            _BulbControl.L2_3_ColorNumber = 6;
        }


        if (CheckFour == 2)
        {
            Four.GetComponent<SpriteRenderer>().color = GreenColor;
            _BulbControl.L2_4_ColorNumber = 3;
        }
        else if (CheckFour == 1)
        {
            Four.GetComponent<SpriteRenderer>().color = YellowColor;
            _BulbControl.L2_4_ColorNumber = 4;
        }
        else if (CheckFour == 0)
        {
            Four.GetComponent<SpriteRenderer>().color = RedColor;
            _BulbControl.L2_4_ColorNumber = 6;
        }
    }

    public IEnumerator ChangeToBlue()
    {
        string URL = "https://maker.ifttt.com/trigger/L_B/json/with/key/j5USrRaJXmH91nh531q3SeZw-TwNBnXkqmzVJgqqTUt";
        using (UnityWebRequest request = UnityWebRequest.Get(URL))
        {
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(request.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
        }
    }

    public IEnumerator ChangeToRed()
    {
        string URL = "https://maker.ifttt.com/trigger/L_R/json/with/key/j5USrRaJXmH91nh531q3SeZw-TwNBnXkqmzVJgqqTUt";
        using (UnityWebRequest request = UnityWebRequest.Get(URL))
        {
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(request.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
        }
    }

    public IEnumerator ChangeToGreen()
    {
        string URL = "https://maker.ifttt.com/trigger/L_G/json/with/key/j5USrRaJXmH91nh531q3SeZw-TwNBnXkqmzVJgqqTUt";
        using (UnityWebRequest request = UnityWebRequest.Get(URL))
        {
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(request.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
        }
    }

    public IEnumerator ChangeToPurple()
    {
        string URL = "https://maker.ifttt.com/trigger/L_P/json/with/key/j5USrRaJXmH91nh531q3SeZw-TwNBnXkqmzVJgqqTUt";
        using (UnityWebRequest request = UnityWebRequest.Get(URL))
        {
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(request.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
        }
    }

}