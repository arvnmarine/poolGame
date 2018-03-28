using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Chat : NetworkBehaviour {

    public List<string> chatList = new List<string>();
    private string curMess;

    
    private void OnGUI()
    {
        GUILayout.BeginHorizontal(GUILayout.Width(250));
        curMess = GUILayout.TextField(curMess);
        if (GUILayout.Button("Send"))
        {
            if (!string.IsNullOrEmpty(curMess.Trim()))
            {
                CmdChatMess_clientToServer(curMess);
                curMess = string.Empty;
            }
        }
        GUILayout.EndHorizontal();
        foreach (string st in chatList)
        {
            GUILayout.Label(st);
        }
    }
    
    [Command]
    public void CmdChatMess_clientToServer(string mess)
    {
        RpcChatMess_serverToAllClient(mess);
    }
    
    
    [ClientRpc]
    public void RpcChatMess_serverToAllClient(string mess)
    {
        chatList.Add(mess);
    }
    
}
