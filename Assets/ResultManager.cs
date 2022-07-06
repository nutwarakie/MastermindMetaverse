using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{
    [SerializeField]
    private Text TextRound;

    [SerializeField]
    private Text TextWin;

    [SerializeField]
    private Text TextLose;

    [SerializeField]
    private GameObject HistoryPanel;
    // Start is called before the first frame update
    void Start()
    {


        if (CheckAnswer.happyending == 2)
        {
            RoundResult.WinCount += 1;
        }
        else if (CheckAnswer.happyending == 1)
        {
            RoundResult.LoseCount += 1;
        }

        RoundResult.RoundPlayed += 1;

        ResultList();
    }

    public void ResultList()
    {
        //CustomMatchmakingRoomController.RoundPlayed += 1;
        TextRound.text = RoundResult.RoundPlayed.ToString();
        TextWin.text = RoundResult.WinCount.ToString();
        TextLose.text = RoundResult.LoseCount.ToString();
    }

    public void closeHistoryPanel()
    {
        HistoryPanel.SetActive(false);
    }

    public void openHistoryPanel()
    {
        HistoryPanel.SetActive(true);
    }
}
