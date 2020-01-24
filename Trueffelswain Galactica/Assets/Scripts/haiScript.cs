using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class haiScript : MonoBehaviour
{
    public float speed;
    public int health;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
	transform.position = Vector2.MoveTowards(transform.position, pigletScript.pigr2d.position, speed);
	transform.right = pigletScript.pigr2d.position - (Vector2)transform.position;

    }
    void OnTriggerEnter2D(Collider2D coll)
    {
	Debug.Log("Colission Hai");
	if (coll.gameObject.name == "laser(Clone)")
	{
		health --;
		if (health == 0)
			Destroy(gameObject);
	}
    }
}
