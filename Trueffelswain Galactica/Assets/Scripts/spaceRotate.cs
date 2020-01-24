using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceRotate : MonoBehaviour
{
    public bool randomized;
    public Sprite sprites;
    // Start is called before the first frame update
    void Start()
    {
        var r2d = GetComponent<Rigidbody2D>();
	r2d.angularVelocity = 1;
	var sr = GetComponent<SpriteRenderer>();
	string spriteName = "space" + Random.Range(1,4);
	Debug.Log(spriteName.ToString());
	if(randomized == true)
	{
		sprites = Resources.Load<Sprite>(spriteName);
		Debug.Log(sprites);
		sr.sprite = sprites;
	}
    }

    // Update is called once per frame
    void Update()
    {
        var r2d = GetComponent<Rigidbody2D>();
	r2d.angularVelocity = 0.3f;
    }
}
