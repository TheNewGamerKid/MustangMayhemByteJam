using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocket_enemy_handler : MonoBehaviour
{
    public float sight = 20f;
    public float speed = 2.5f;
    public float lockSpeed = 5f;
    public float flightTime = 5f;
    public GameObject Rocket;
    private Vector3 playerPosition;
    public GameObject newInstance;
    private float xDifference;
    private float yDifference;
    private float hypotenuse;
    private float time = 4f;
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
        if(hypotenuse <= sight) {
            if(Input.GetKey(KeyCode.W) == false && Input.GetKey(KeyCode.D) == false && Input.GetKey(KeyCode.S) == false && Input.GetKey(KeyCode.A) == false) {
                if(Time.time - time > lockSpeed) {
                    float angle = Mathf.Atan2(yDifference, xDifference) * Mathf.Rad2Deg;
                    Quaternion rotation = Quaternion.Euler(this.transform.rotation.x, this.transform.rotation.y, angle);
                    time = Time.time;
                    newInstance = Instantiate(Rocket, this.transform.position, rotation);
                    Destroy(newInstance, flightTime);
                }
            }
        }
    }
}
