using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class large_explosion_handler : MonoBehaviour
{
    private float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - time > .1) {
            Destroy(gameObject);
        }
    }
}
