using Photon.Pun;
using System.IO;
using UnityEngine;

public class GameSetupController : MonoBehaviour
{
    // This script will be added to any multiplayer scene
    void Start()
    {
        CreatePlayer(); //Create a networked player object for each player that loads into the multiplayer scenes.

        //int number = Random.Range(0, AvatarSetup.avatarSetup.startAvatar.Length);
    }

    private void CreatePlayer()
    {
        Debug.Log("Creating Player");
        //PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PhotonPlayer"), Vector3.zero, Quaternion.identity);

        int number = Random.Range(0, AvatarSetup.avatarSetup.startAvatar.Length);
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PhotonPlayer"), AvatarSetup.avatarSetup.startAvatar[number].position, AvatarSetup.avatarSetup.startAvatar[number].rotation);
    }
}
