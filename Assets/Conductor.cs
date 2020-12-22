using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Conductor : MonoBehaviour
{

    public Text beatCounterText;
    public float songBpm;
    public float beatsPerLoop;
    public AudioSource musicSource;

    public float dspSongTime;
    public float secPerBeat;
    public float songPosition;
    public float songPositionInBeats;
    public int completedLoops = 0;
    public float loopPositionInBeats;
    public float normalizedLoopPosition;


    // Start is called before the first frame update
    void Start()
    {
        musicSource = GetComponent<AudioSource>();
        secPerBeat = 60f / songBpm;
        dspSongTime = (float) AudioSettings.dspTime;
        musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        songPosition = (float)(AudioSettings.dspTime - dspSongTime);
        songPositionInBeats = songPosition / secPerBeat;

        if (songPositionInBeats >= (completedLoops + 1) * beatsPerLoop) {
            completedLoops++;
        }
        loopPositionInBeats = songPositionInBeats - completedLoops * beatsPerLoop;

        normalizedLoopPosition = loopPositionInBeats / beatsPerLoop;

        beatCounterText.text = "Beat Counter: " + (Mathf.FloorToInt(songPositionInBeats) + 1);
    }
}
