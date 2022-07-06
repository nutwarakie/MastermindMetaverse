using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RandomAnswer : MonoBehaviour
{
    private PhotonView PV;
    private GameObject firstColor;
    private GameObject secondColor;
    private GameObject thirdColor;
    private GameObject fourthColor;
    private GameObject fifthColor;
    private GameObject sixthColor;

    private List<int> RandomAnswerState = new List<int>();
    public List<int> AnswerState = new List<int>();
    // Start is called before the first frame update
    public int Ans1;
    public int Ans2;
    public int Ans3;
    public int Ans4;

    public int Answer_1;
    public int Answer_2;
    public int Answer_3;
    public int Answer_4;

    private List<int> NewList = new List<int>();
    void Start()
    {

        RandomAnswerState.Add(1);
        RandomAnswerState.Add(2);
        RandomAnswerState.Add(3);
        RandomAnswerState.Add(4);
        RandomAnswerState.Add(5);
        RandomAnswerState.Add(6);


        GetRandomElements(RandomAnswerState, 4);

        PV = GetComponent<PhotonView>();
        if (PV.IsMine)
        {
            PV.RPC("RPC_SendAnswer", RpcTarget.All, Ans1, Ans2, Ans3, Ans4);
        }

    }

    public List<int> Request()
    {
        List<int> NewList = new List<int>();

        Answer_1 = Ans1;
        Answer_2 = Ans2;
        Answer_3 = Ans3;
        Answer_4 = Ans4;

        NewList.Add(Answer_1);
        NewList.Add(Answer_2);
        NewList.Add(Answer_3);
        NewList.Add(Answer_4);

        /*foreach (var x in NewList)
        {
            Debug.Log(x);
        }*/

        return NewList;

    }

    public void GetRandomElements(List<int> RandomList, int count)
    {

        for (int i = 0; i < count; i++)
        {
            int randomNum = Random.Range(0, RandomList.Count);
            int printRandom = RandomList[randomNum];
            AnswerState.Add(printRandom);
            RandomList.Remove(printRandom);

        }

        Ans1 = AnswerState[0];
        Ans2 = AnswerState[1];
        Ans3 = AnswerState[2];
        Ans4 = AnswerState[3];

        /*foreach (var x in AnswerState)
        {
            Debug.Log(x);
        }*/
    }
    [PunRPC]
    void RPC_SendAnswer(int Value1, int Value2, int Value3, int Value4)
    {
        Ans1 = Value1;
        Ans2 = Value2;
        Ans3 = Value3;
        Ans4 = Value4;

        /*Debug.Log(Ans1);
        Debug.Log(Ans2);
        Debug.Log(Ans3);
        Debug.Log(Ans4);*/
    }
}
