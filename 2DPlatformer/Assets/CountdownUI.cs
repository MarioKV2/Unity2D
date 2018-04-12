using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownUI : MonoBehaviour {

	float timeLeft = 0.0f;

	public Text myText;


	
	// Update is called once per frame
	void Update () {
		timeLeft += Time.deltaTime;
		myText.text =  timeLeft.ToString ("0");
	}

	public float ReturnResult()
	{
		return timeLeft;
	}
}
