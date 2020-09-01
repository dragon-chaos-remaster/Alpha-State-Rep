using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Photon.Realtime;
public class PlayerListing : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;

    //public RoomInfo RoomInfo { get; private set; }
    [SerializeField] Player player;
    public void SetPlayerInfo(Player player)
    {
        this.player = player;
        text.text = player.NickName;
    }
}
