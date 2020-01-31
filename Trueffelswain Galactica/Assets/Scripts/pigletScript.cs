using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pigletScript : MonoBehaviour
{
    public GameObject laser;
    public GameObject meteor1;
    public GameObject meteor2;
    public GameObject hai1;
    public SpriteRenderer feuer;
    public static Rigidbody2D pigr2d;
    public float cooldown;
    public float rotationspeed;
    public float speed;
    private float currentspeed = 0;
    private bool shooting = false;

    // Start is called before the first frame update
    void Start()
    {
        pigr2d = GetComponent<Rigidbody2D>();
        for(int i = 0; i < 40; i++)
        {
            Instantiate(meteor1, new Vector3(Random.Range(-50f, 50f), Random.Range(-50f, 50f), 0), Quaternion.identity);
            Instantiate(meteor2, new Vector3(Random.Range(-50f, 50f), Random.Range(-50f, 50f), 0), Quaternion.identity);
        }
	for(int i = 0; i < 10; i++)
	{
		Instantiate(hai1, new Vector3(Random.Range(-50f, 50f), Random.Range(-50f, 50f), 0), Quaternion.identity);
	}
    }

    // Update is called once per frame
    void Update()
    {
	var r2d = GetComponent<Rigidbody2D>();
	if (Input.GetKey("right"))
		r2d.angularVelocity = -rotationspeed;
	else if (Input.GetKey("left"))
		r2d.angularVelocity = rotationspeed;
	else
	{
		if(r2d.angularVelocity < 0)
			r2d.angularVelocity++;
		else if (r2d.angularVelocity > 0)
			r2d.angularVelocity--;
		else
			r2d.angularVelocity = 0;
	}
	if (Input.GetKey("up"))
	{
		float r = r2d.rotation - 23;
		//Debug.Log(r.ToString());
		var v = new Vector2(speed * Mathf.Cos((r/180)*Mathf.PI), speed * Mathf.Sin((r/180)*Mathf.PI));
		r2d.velocity = v;
		currentspeed = speed;
		if (feuer.flipY == true)
			feuer.flipY = false;
		else
			feuer.flipY = true;
		feuer.color = new Color(1f,1f,1f,1f);
	}
	else if (currentspeed > 0)
	{
		currentspeed = currentspeed - 0.05f;
		float r = r2d.rotation - 23;
		//Debug.Log(r.ToString());
		var v = new Vector2(currentspeed * Mathf.Cos((r/180)*Mathf.PI), currentspeed * Mathf.Sin((r/180)*Mathf.PI));
		r2d.velocity = v;
		feuer.color = new Color(1f,1f,1f,1f);
	}
	else
		r2d.velocity = new Vector2(0,0);
		feuer.color = new Color(1f,1f,1f,0.5f);
	if(Input.GetKey("space") /*&& shooting == false*/)
	{
		if(shooting == false)
		{
			shooting = true;
			StartCoroutine("shoot");
		}
	}
	else
	{
		shooting = false;
	}
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
	Debug.Log("Collission piglet");
	if (coll.gameObject.name == "hai1")
	{
		hit();
	}
    }
    void hit()
    {
	//Destroy(gameObject);
    }
    IEnumerator shoot()
    {
	while(shooting)
	{
		Debug.Log("shoot");
		Instantiate(laser, pigr2d.position, Quaternion.identity);
		yield return new WaitForSeconds(cooldown);
	}
    }
}
