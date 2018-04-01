using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Chat : MonoBehaviour {


    private string curMess;
    public List<string> chatList = new List<string>();
    public GameObject playerPointer;

    private void Start()
    {
        //Debug.Log(isLocalPlayer);
        //Debug.Log(isServer);
    }

    



    // Update is called once per frame
    void Update()
    {
        if (chatList.Count > 5)
        {
            chatList.RemoveAt(0);
        }
    }


    private void OnGUI()
    {
       

       
        

        using (var areaScope = new GUILayout.AreaScope(new Rect(Screen.width - 130, 10, 100, 1000)))
        {
            

             
                curMess = GUILayout.TextField(curMess);



                if (GUILayout.Button("Send"))
                {
                    if (!string.IsNullOrEmpty(curMess.Trim()))
                    {


                        playerPointer.GetComponent<PlayerNetworkHook>().CmdChatMess_clientToServer(curMess);

                        curMess = string.Empty;
                    }
                }

            

                

            
            

            foreach (string st in chatList)
            {
                GUILayout.Label(st);
            }
        }

        
    }
    
    
    
}
