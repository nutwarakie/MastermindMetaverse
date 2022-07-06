using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarSetup : MonoBehaviour
{
    public static AvatarSetup avatarSetup;
    public Transform[] startAvatar;

    private void OnEnable()
    {
        if(AvatarSetup.avatarSetup == null)
        {
            AvatarSetup.avatarSetup = this;
        }
    }
}
