using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerNetworkHook : NetworkBehaviour {


    
	// Use this for initialization
	void Start () {
		if (!isLocalPlayer)
        {
            //return;
            
        } else
        {
            this.GetComponent<Camera>().enabled = true;
            this.GetComponent<MouseLook>().enabled = true;
            this.GetComponent<Move>().enabled = true;
            this.GetComponent<CharacterController>().enabled = true;
            
        }
	}

    void OnConnectedToServer()
    {
    }

        // Update is called once per frame
        void Update () {
		
	}
}
