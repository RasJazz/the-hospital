using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerLight : MonoBehaviour
{
    private bool isFlickering = false;
    public float timeDelay;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        if(isFlickering == false) {
            StartCoroutine(Flicker());
        }
    }
    IEnumerator Flicker() {
        isFlickering = true;
        this.gameObject.GetComponent<Light>().enabled = false;

        timeDelay = Random.Range(.01f,.2f);//change the float values to determine how often is the delay

        yield return new WaitForSeconds(timeDelay);
        this.gameObject.GetComponent<Light>().enabled = true; // same here
        timeDelay = Random.Range(0.1f, .2f);
        yield return new WaitForSeconds(timeDelay);
        isFlickering=false;
    }
    //since isFlickering switches back and forth
    // got it here https://www.youtube.com/watch?v=JuvY0fYVPM0
    // note script doesn't worked for baked lights, mixed seem to work here
}
