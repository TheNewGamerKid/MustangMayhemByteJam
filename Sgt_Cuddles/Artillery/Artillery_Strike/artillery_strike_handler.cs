using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class artillery_strike_handler : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        rb.AddForce(-transform.right * 200, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D()
    {
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
