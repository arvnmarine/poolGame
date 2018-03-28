using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class score : MonoBehaviour {


    public Text textScore;
	// Use this for initialization
	void Start () {
		
	}
	
    void SetText(string s)
    {
        textScore.text = s;
    }

	// Update is called once per frame
	void Update () {
        SetText("10");

    }
}
