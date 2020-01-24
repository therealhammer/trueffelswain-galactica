using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteorScript : MonoBehaviour
{
    private Rigidbody2D meteorr2d;
    // Start is called before the first frame update
    void Start()
    {
        meteorr2d = GetComponent<Rigidbody2D>();
        meteorr2d.AddTorque(Random.Range(-30f, 30f));
    }

    // Update is called once per frame
    void Update()
    {
    }
}
