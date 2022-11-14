using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_attack_handler : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    void Start()
    {
        rb.AddForce(transform.up * 10, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
