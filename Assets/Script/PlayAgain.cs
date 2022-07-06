using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayAgain : MonoBehaviour
{
    [SerializeField]
    private int GameScene;

    private PhotonView PV;

    public GameObject Newgamebutton;

    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponent<PhotonView>();
        PhotonNetwork.AutomaticallySyncScene = true;
        //GameScene = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (PV.IsMine)
        {
            Newgamebutton.SetActive(true);
        }
    }

    public void NewGame()
    {
        if (PV.IsMine)
        {
            PhotonNetwork.AutomaticallySyncScene = true;
            PhotonNetwork.LoadLevel(GameScene);
        }
    }
}
