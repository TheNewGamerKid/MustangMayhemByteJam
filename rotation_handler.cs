using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation_handler : MonoBehaviour
{

    public GameObject Gun;

    private float spread;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        spread = Gun.GetComponent<gun_barrel_handler>().spread;
        Transform Player = GameObject.Find("Player").transform;

        float xDif = Player.position.x - transform.position.x;
        float yDif = Player.position.y - transform.position.y;
        float Zangle = Mathf.Atan2(yDif, xDif) * Mathf.Rad2Deg + 180 + spread;
        float Xangle = 0;

        if(xDif > 0) {
            Xangle = 180;
            Zangle = -Zangle;
        } 

        Quaternion rotation = Quaternion.Euler(Xangle, 0, Zangle);
        transform.rotation = rotation;
    }
}
