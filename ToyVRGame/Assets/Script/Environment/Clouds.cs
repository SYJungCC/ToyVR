using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour {

    float random = 0.0f;
    Vector3 originalPosition; 
    private void Start()
    {
        originalPosition = transform.position;
        random = Random.Range(0.15f, 0.2f);
    }
    // Update is called once per frame
    void Update () {

        transform.Translate(0, 0, random);
		
	}

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Sky"))
        {
            Debug.Log("kkk");

            random = Random.Range(0.15f, 0.2f);
            this.transform.position = originalPosition;
        }
    }
}
