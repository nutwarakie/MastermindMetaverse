using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class Test : MonoBehaviour
{
    private PhotonView PV;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("HELLO");
        PV = GetComponent<PhotonView>();
        Debug.Log(PV);
        System.Console.WriteLine(PV);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
