using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserScript : MonoBehaviour
{
    public int speed = 6;
    //public static Rigidbody2D pigr2d;
    // Start is called before the first frame update
    void Start()
    {
	var r2d = GetComponent<Rigidbody2D>();
	r2d.rotation = pigletScript.pigr2d.rotation - 23 - 90;
	var p = /*pigletScript.pig*/r2d.position;
	//r2d.position = new Vector2(0f * Mathf.Cos((p.x/180)*Mathf.PI), 0f * Mathf.Sin((p.y/180)*Mathf.PI));
    }

    // Update is called once per frame
    void Update()
    {
	var r2d = GetComponent<Rigidbody2D>();
	float r = r2d.rotation + 90;
	float s = (float)speed;
	var v = new Vector2(s * Mathf.Cos((r/180)*Mathf.PI), s * Mathf.Sin((r/180)*Mathf.PI));
	r2d.velocity = v;
    }

    void OnBecameInvisible()
    {
	Destroy(gameObject);
    }
}
