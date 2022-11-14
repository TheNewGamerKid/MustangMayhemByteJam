using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun_barrel_handler : MonoBehaviour
{
    public float despawnTime = 5f;
    public float reloadTime = 5f;
    public float accuracy;
    public float cyclicRate;
    public float magCap;
    public float range;
    public GameObject Bullet;
    public GameObject Gun;
    public float spread;
    public float numShots = 0f;

    private GameObject newInstance;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Gun.GetComponent<SpriteRenderer>().sprite);
        if(Gun.GetComponent<gun_handler>().type == 1) {
            accuracy = 5f;
            range = 30f;
            magCap = 7f;
            cyclicRate = .25f;
        } else {
            accuracy = 15f;
            range = 15f;
            magCap = 30f;
            cyclicRate = .1f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosition = GameObject.Find("Player").transform.position;
        float xDif = playerPosition.x - transform.position.x;
        float yDif = playerPosition.y - transform.position.y;
        float hypotenuse = Mathf.Sqrt(Mathf.Pow(Mathf.Abs(xDif), 2) + Mathf.Pow(yDif, 2));

        if(hypotenuse <= range) {
            if(magCap > numShots) {
                spread = Random.Range(-accuracy, accuracy);
                float angle = Mathf.Atan2(yDif, xDif) * Mathf.Rad2Deg - 90 + spread;
                float xPos = transform.position.x;
                float yPos = transform.position.y;

                Vector2 pos = new Vector2(xPos, yPos);
                Quaternion rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, angle);
                if(Time.time - time > cyclicRate) {
                    time = Time.time;
                    numShots++;
                    newInstance = Instantiate(Bullet, pos, rotation);
                    Destroy(newInstance, despawnTime);
                }
            }
        }

        if(magCap == numShots) {
            if(Time.time - time > reloadTime) {
                numShots = 0;
            }
        }
    }
}
