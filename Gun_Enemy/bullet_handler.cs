using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_handler : MonoBehaviour
{
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.AddForce(transform.up * 10, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
