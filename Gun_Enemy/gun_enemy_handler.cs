using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun_enemy_handler : MonoBehaviour
{
    public float sight = 20f;
    public float speed = 2.5f;
    public float accuracy = 5f;
    public float magCap = 7f;
    public float reloadTime = 5f;
    public float cyclicRate = .25f;
    public float despawnTime = 5f;
    public GameObject Bullet;
    private Vector3 playerPosition;
    private GameObject newInstance;
    private float numShots = 0f;
    private float time = .5f;
    private float xDifference;
    private float yDifference;
    private float hypotenuse;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = GameObject.Find("Player").transform.position;
        xDifference = playerPosition.x - transform.position.x;
        yDifference = playerPosition.y - transform.position.y;
        hypotenuse = Mathf.Sqrt(Mathf.Pow(Mathf.Abs(xDifference), 2) + Mathf.Pow(yDifference, 2));

        if(hypotenuse <= sight && hypotenuse >= 10) {
            if(playerPosition.x > transform.position.x) {
                transform.position += transform.right * speed * Time.deltaTime;
            }

            if(playerPosition.x < transform.position.x) {
                transform.position += -transform.right * speed * Time.deltaTime;
            }
        } else if(hypotenuse <= 7.5) {
            if(playerPosition.x > transform.position.x) {
                transform.position += -transform.right * speed * Time.deltaTime;
            }

            if(playerPosition.x < transform.position.x) {
                transform.position += transform.right * speed * Time.deltaTime;
            }
        }

        if(hypotenuse <= 10) {
            if(magCap > numShots) {
                CreatePrefab();
            }
        }

        if(magCap == numShots) {
            if(Time.time - time > reloadTime) {
                numShots = 0;
            }
        }
    }

    void CreatePrefab() {
        float spread = Random.Range(-accuracy, accuracy);
        float angle = Mathf.Atan2(yDifference, xDifference) * Mathf.Rad2Deg - 90 + spread;
        Quaternion rotation = Quaternion.Euler(this.transform.rotation.x, this.transform.rotation.y, angle);
        if(Time.time - time > cyclicRate) {
            time = Time.time;
            numShots++;
            newInstance = Instantiate(Bullet, this.transform.position, rotation);
            Destroy(newInstance, despawnTime);
        }
    }
}
