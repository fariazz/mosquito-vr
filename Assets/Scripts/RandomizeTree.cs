using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeTree : MonoBehaviour {

    // Minimum and maximum values for scale
    public float minScale = 0.7f;
    public float maxScale = 2.5f;
    
	// Use this for initialization
	void Start () {

        // Random scale value
        float scale = Random.Range(minScale, maxScale);
        
        // Change scale
        transform.localScale = new Vector3(scale, scale, scale);

        // Random rotation about Y
        float rotationY = Random.Range(0, 360);

        // Rotate about Y
        transform.Rotate(0, rotationY, 0, Space.World);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
