using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    public InputField createInput;
    public InputField joinInput;

    // le joueur 1 crée une partie avec un nom qu'il choisi
    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(createInput.text);
    }

    // pour rejoindre une partie, le joueur 2 doit connaitre le nom donné par le joueur 1
    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinInput.text);
    }

    public override void OnJoinedRoom()
    {
        //a la place de "game", mettre le nom de la scene du jeu Aita
        PhotonNetwork.LoadLevel("Game");
    }
}
