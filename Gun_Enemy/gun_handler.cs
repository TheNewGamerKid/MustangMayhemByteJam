using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun_handler : MonoBehaviour
{
    public Sprite Pistol;
    public Sprite Rifle;
    public int type;

    // Start is called before the first frame update

    void Start()
    {
        SpriteRenderer spriteRender = gameObject.GetComponent<SpriteRenderer>();
        type = Random.Range(1, 3);
        if(type == 1) {
            spriteRender.sprite = Pistol;
        } else {
            spriteRender.sprite = Rifle;
        }
    }

    // Update is called once per frame

    void Update()
    {
        
    }
}
