using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun_enemy_handler : MonoBehaviour
{

    public float despawnTime = 5f;
    public float reloadTime = 5f;
    public float speed = 2.5f;
    public Sprite Pistol;
    public Sprite Rifle;
    public GameObject Bullet;
    public float cyclicRate;
    public float accuracy;
    public float magCap;
    public float sight;
    public int type;

    private GameObject newInstance;
    private Vector3 playerPosition;
    private float numShots = 0f;
    private float health = 40f;
    private float xDifference;
    private float yDifference;
    private float time;
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

        MovementHandler();
        DamageHandler();
    }

    void MovementHandler() {
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
    }

    void DamageHandler() {
        GameObject[] attacks = GameObject.FindGameObjectsWithTag("Player_Attacks");
        
        foreach(GameObject attack in attacks) {
            float x = gameObject.transform.position.x - attack.transform.position.x;
            float y = gameObject.transform.position.y - attack.transform.position.y;
            float hypotenuse = Mathf.Sqrt(Mathf.Pow(Mathf.Abs(x), 2) + Mathf.Pow(y, 2));

            if(hypotenuse < 1f) {
                health -= 20f;
                Destroy(attack);
            }
        }

        if(health <= 0f) {
            Destroy(gameObject);
        }
    }
}
