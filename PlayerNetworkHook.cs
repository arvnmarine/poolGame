using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerNetworkHook : NetworkBehaviour {

    public GameObject chatPointer;
    
    
    // Use this for initialization
    void Start () {
        chatPointer = GameObject.Find("chatMemory");
        if (!isLocalPlayer)
        {
            return;
            
        } else
        {
            chatPointer.GetComponent<Chat>().playerPointer = this.gameObject;
            this.GetComponent<Camera>().enabled = true;
            this.GetComponent<MouseLook>().enabled = true;
            this.GetComponent<Move>().enabled = true;
            this.GetComponent<CharacterController>().enabled = true;

        }
        Debug.Log(isLocalPlayer);

	}

    void OnConnectedToServer()
    {
    }



    [Command]
    public void CmdChatMess_clientToServer(string mess)
    {
        Debug.Log("server received");
        RpcChatMess_serverToAllClient(mess);
    }


    [ClientRpc]
    public void RpcChatMess_serverToAllClient(string mess)
    {
        Debug.Log("client received");
        
        chatPointer.GetComponent<Chat>().chatList.Add(mess);
    }
}
