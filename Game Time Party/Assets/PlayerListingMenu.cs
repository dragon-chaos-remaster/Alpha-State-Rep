using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerListingMenu : MonoBehaviourPunCallbacks
{
    [SerializeField] Transform content;
    [SerializeField] PlayerListing playerListing;

    List<PlayerListing> _listing = new List<PlayerListing>();

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        PlayerListing listing = Instantiate(playerListing, content);
        if (listing != null)
        {
            listing.SetRoom(info);
            _listing.Add(listing);
        }
    }
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        
    }
    public override void OnRoomListUpdate(List<Player> roomList)
    {
        foreach (Player info in roomList)
        {
            //Salas Removidas da Lista
            if (info.RemovedFromList)
            {
                int index = _listing.FindIndex(x => x.RoomInfo.Name == info.Name);
                if (index != -1)
                {
                    Destroy(_listing[index].gameObject);
                    _listing.RemoveAt(index);
                }
            }
            //Salas adicionadas da lista
            else
            {
                PlayerListing listing = Instantiate(playerListing, content);
                if (listing != null)
                {
                    listing.SetRoom(info);
                    _listing.Add(listing);
                }
            }

        }
    }
}
