using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatIndicator : MonoBehaviour
{
    public GameObject background;
    public Conductor conductor;
    public float beat = 1;

    float initialXPos;

    // Start is called before the first frame update
    void Start()
    {
        initialXPos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        float scale = 0;
        if (beat > 1) {
            scale = conductor.loopPositionInBeats / (beat - 1); 
            //gameObject.transform.position = new Vector3(Mathf.Lerp(initialXPos, background.transform.position.x, conductor.loopPositionInBeats / (beat-1)), transform.position.y, transform.position.z);
        } else {
            scale = conductor.loopPositionInBeats / conductor.beatsPerLoop; 
        }
        gameObject.transform.position = new Vector3(Mathf.Lerp(initialXPos, background.transform.position.x, scale), transform.position.y, transform.position.z);
        if (scale >= 1) {
            transform.localScale = Vector3.zero;
        } else {
            transform.localScale = Vector3.one;
        }
    }
}
