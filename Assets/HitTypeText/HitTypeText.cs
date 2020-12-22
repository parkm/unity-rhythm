using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTypeText : MonoBehaviour
{

    public Sprite mehText;
    public Sprite goodText;
    public Sprite perfectText;

    SpriteRenderer renderer;

    public float speed = 1.0f;
    public float lifeTime = 1.0f;
    float lifeTimer = 0;

    public void InitText(string hitType) {
        Dictionary<string, Sprite> map = new Dictionary<string, Sprite>(){
            { "meh", mehText },
            { "good", goodText },
            { "perfect", perfectText },
        };
        renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = map[hitType];
    }

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        lifeTimer += Time.deltaTime;
        float lifeRatio = lifeTimer / lifeTime;
        Color newColor = renderer.color;
        newColor.a = 1-lifeRatio;
        renderer.color = newColor;

        if (lifeTimer >= lifeTime) {
            Destroy(this.gameObject);
        }

        Vector3 newPos = transform.position;
        newPos.y += (this.speed * Time.deltaTime);
        this.transform.position = newPos;
    }
}
