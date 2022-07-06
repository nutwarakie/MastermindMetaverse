using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class finishgame : MonoBehaviour
{

    [SerializeField]
    private int GameScene;

    private float waitTimeLoadScene;

    private PhotonView PV;

    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponent<PhotonView>();
        PhotonNetwork.AutomaticallySyncScene = true;

        waitTimeLoadScene = 2f;
        //GameScene = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(CheckAnswer.EndGame)
        {

            if (PV.IsMine)
            {
                if(CheckAnswer.happyending == 2)
                {
                    GameScene = 2;
                }
                else if(CheckAnswer.happyending == 1)
                {
                    GameScene = 3;
                }


                //PhotonNetwork.AutomaticallySyncScene = true;
                //PhotonNetwork.LoadLevel(GameScene);

                StartCoroutine(waitforLoadScene());
            }

            CheckAnswer.EndGame = false;

        }
    }

    IEnumerator waitforLoadScene()
    {
        yield return new WaitForSeconds(waitTimeLoadScene);


        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.LoadLevel(GameScene);
    }
}
