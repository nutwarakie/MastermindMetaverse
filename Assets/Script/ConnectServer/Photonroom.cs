using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class Photonroom : MonoBehaviourPunCallbacks, IInRoomCallbacks
{
    //Room info
    public static Photonroom room;
    private PhotonView PV;

    public bool isGameLoaded;
    public int currentScene;

    //Player info
    Player[] photonPlayer;
    public int playersInRoom;
    public int myNumberInRoom;

    public int playerInGame;

    //Delayed start
    private bool readyToCount;
    private bool readyToStart;
    public float startingTime;
    private float lessthanMaxPlayer;
    private float atMaxPlayer;
    private float timeToStart;

    private void Awake()
    {
        if(Photonroom.room == null)
        {
            Photonroom.room = this;
        }
        else
        {
            if(Photonroom.room != this)
            {
                Destroy(Photonroom.room.gameObject);
                Photonroom.room = this;
            }
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public override void OnEnable()
    {
        base.OnEnable();
        PhotonNetwork.AddCallbackTarget(this);
        //SceneManager.sceneLoaded += OnSceneFinishedLoading;
    }

    public override void OnDisable()
    {
        base.OnDisable();
        PhotonNetwork.RemoveCallbackTarget(this);
        //SceneManager.sceneLoaded -= OnSceneFinishedLoading;
    }

    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponent<PhotonView>();
        readyToCount = false;
        readyToStart = false;
        lessthanMaxPlayer = startingTime;
        atMaxPlayer = 6;
        timeToStart = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
