using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour {

    public int moveSpeed = 20;
    public float maxY;
    public float minY;

    bool moveUp = true;
	// Update is called once per frame
	void Update () {
        if (moveUp)
        {
            if (this.transform.position.y < maxY)
                transform.Translate(Vector3.up * Time.deltaTime * moveSpeed);
            else
                moveUp = false;
        }
        else
        {
            if (this.transform.position.y > minY)
                transform.Translate(Vector3.down * Time.deltaTime * moveSpeed);
            else
                moveUp = true;
        }
	}
}
