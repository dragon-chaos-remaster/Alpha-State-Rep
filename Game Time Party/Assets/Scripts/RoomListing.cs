﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Photon.Realtime;
public class PlayerListing : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    
    public Player RoomInfo { get; private set; }
    public void SetRoom(Player roomInfo)
    {
        RoomInfo = roomInfo;
        text.text = roomInfo.MaxPlayers + ", " + roomInfo.Name;
    }
}
