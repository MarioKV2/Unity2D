using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownUI : MonoBehaviour {

	public float timeLeft = 0.0f;

	public Text myText;

    public bool pause = false;
	
	// Update is called once per frame
	void Update () {
        if (pause == false)
        {
            timeLeft += Time.deltaTime;
        }
		myText.text =  timeLeft.ToString ("0");
	}

	public float ReturnResult()
	{
		return timeLeft;
	}
}
