﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class RoomListingMenu : MonoBehaviourPunCallbacks
{
    [SerializeField] Transform content;
    [SerializeField] PlayerListing roomListing;

    List<PlayerListing> _listing = new List<PlayerListing>();
    public override void OnRoomListUpdate(List<Player> roomList)
    {
        foreach (Player info in roomList) 
        {
            //Salas Removidas da Lista
            if (info.RemovedFromList)
            {
                int index = _listing.FindIndex(x => x.RoomInfo.Name == info.Name);
                if(index != -1)
                {
                    Destroy(_listing[index].gameObject);
                    _listing.RemoveAt(index);
                }
            }
            //Salas adicionadas da lista
            else
            {
                PlayerListing listing = Instantiate(roomListing, content);
                if (listing != null)
                {
                    listing.SetRoom(info);
                    _listing.Add(listing);
                }
            }
        
        }
    }
}
