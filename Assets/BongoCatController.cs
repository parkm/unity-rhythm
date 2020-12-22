using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BongoCatController : MonoBehaviour
{
    public Conductor conductor;
    public HitTypeText hitTypeTextPrefab;
    public Sprite down;
    public Sprite up;
    public Sprite ldown;
    public Sprite rdown;

    public AudioSource bongoAudioSource;
    public AudioClip bongoA;
    public AudioClip bongoB;

    SpriteRenderer renderer;

    bool rmouseDown = false;
    bool lmouseDown = false;

    public enum HitType {
        Perfect,
        Good,
        Meh
    }
    public float perfectHitLeeway = 0.05f;
    public float goodHitLeeway = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        lmouseDown = Input.GetMouseButton(0);
        rmouseDown = Input.GetMouseButton(1);

        if (Input.GetKey(KeyCode.Space)) {
            renderer.sprite = down;
        } else if (lmouseDown) {
            renderer.sprite = ldown;
        } else if (rmouseDown) {
            renderer.sprite = rdown;
        }

        if (lmouseDown && rmouseDown) {
            renderer.sprite = down;
        }

        if (!Input.anyKey) {
            renderer.sprite = up;
        }

        if (Input.GetMouseButtonDown(0)) {
            bongoAudioSource.PlayOneShot(bongoA);
            HandleHit();
        }
        if (Input.GetMouseButtonDown(1)) {
            bongoAudioSource.PlayOneShot(bongoB);
            HandleHit();
        }
    }

    void HandleHit() {
        float beat = conductor.loopPositionInBeats % 1;
        string hitType = "meh";
        HitTypeText htt = Instantiate(hitTypeTextPrefab);
        if (beat < perfectHitLeeway) {
            hitType = "perfect";
        } else if (beat < goodHitLeeway) {
            hitType = "good";
        }
        Debug.Log(hitType + ": " + beat);
        htt.InitText(hitType);
    }
}
