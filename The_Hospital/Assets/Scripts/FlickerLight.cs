using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FlickerLight : MonoBehaviour
{
    private bool isFlickering = false;
    public float timeDelay;
    
    public float minRangeDelay =.01f;
    public float maxRangeDelay = .2f;

    public float minLight = 1f;

    public float maxLight =2f;


    public float minRange = 1f;
    public float maxRange =10f;



    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        if(isFlickering == false) {
            
            StartCoroutine(changeLightInstense());
            StartCoroutine(changeRange());
            StartCoroutine(Flicker());
        }
    }
    IEnumerator Flicker() {

        isFlickering = true;
        this.gameObject.GetComponent<Light>().enabled = false;
        
        timeDelay = Random.Range(minRangeDelay,maxRangeDelay);//change the float values to determine how often is the delay

        yield return new WaitForSeconds(timeDelay);
        this.gameObject.GetComponent<Light>().enabled = true; // same here
        timeDelay = Random.Range(minRangeDelay, maxRangeDelay);
        yield return new WaitForSeconds(timeDelay);
        isFlickering=false;
    }
    //since isFlickering switches back and forth
    // got it here https://www.youtube.com/watch?v=JuvY0fYVPM0
    // note script doesn't worked for baked lights
    IEnumerator changeLightInstense() {
      Light currentLight = this.gameObject.GetComponent<Light>();

      float genLight=Random.Range(minLight,maxLight);
      //yield return new WaitForSeconds(timeDelay);
      //this.gameObject.GetComponent;
      currentLight.intensity = genLight;
      yield return new WaitForSeconds(timeDelay);
      
    }
    IEnumerator changeRange() {
        Light currentLight = this.gameObject.GetComponent<Light>();
        float changeRange = Random.Range(minRange,maxRange);
        currentLight.range = changeRange;
        yield return new WaitForSeconds(timeDelay);

    }
}
