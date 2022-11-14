using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player_handler : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject Bullet;
    public float jumpAmount = 10;
    public float speed = 5;
    public float flightSpeed = 10;
    public bool flight = false;
    public float health = 100f;
    public float despawnTime = 5f;
    private bool isGrounded = true;
    private Vector3 playerPosition;
    private GameObject newInstance;
    private GameObject[] attacks;
    private GameObject[] explosions;
    private Vector2 mousePos;
    private float xDifference;
    private float mouseXDif;
    private float yDifference;
    private float mouseYDif;
    private float hypotenuse; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = GameObject.Find("Player").transform.position;
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - playerPosition;

        if(Input.GetMouseButtonDown(0)) {
            CreatePrefab();
        }

        attacks = GameObject.FindGameObjectsWithTag("Enemy_Attack");
        explosions = GameObject.FindGameObjectsWithTag("Explosion");
        foreach(GameObject explosion in explosions) {
            float a = playerPosition.x - explosion.transform.position.x;
            float b = playerPosition.y - explosion.transform.position.y;
            float hypotenuse = Mathf.Sqrt(Mathf.Pow(Mathf.Abs(a), 2) + Mathf.Pow(b, 2));

            if(explosion.name == "Large_Explosion(Clone)") {
                if(hypotenuse < 5) {
                    float damage;
                    if(40 / hypotenuse > 90) {
                        damage = 90f;
                    } else {
                        damage = Mathf.Round((160 / hypotenuse) / 10) * 10;
                    }
                    health -= damage;
                }
            }
        }
        foreach(GameObject attack in attacks) {
            xDifference = playerPosition.x - attack.transform.position.x;
            yDifference = playerPosition.y - attack.transform.position.y;
            hypotenuse = Mathf.Sqrt(Mathf.Pow(Mathf.Abs(xDifference), 2) + Mathf.Pow(yDifference, 2));
            if(hypotenuse < 1) {
                Destroy(attack);
                if(attack.name == "Bullet(Clone)") {
                    health -= 5;
                }
                if(attack.name == "Rocket(Clone)") {
                    health -= 30;
                }
                if(attack.name == "Knife_Left(Clone)") {
                    health -= 45;
                }
                if(attack.name == "Knife_Right(Clone)") {
                    health -= 45;
                }
                if(attack.name == "Knife_Up(Clone)") {
                    health -= 45;
                }
            }
        }
        
        //death stuff
        if(health < 0) {
            SceneManager.LoadScene("Ded");
        }
        MovementHandler();
        
    }
        //Movement stuff
    void MovementHandler() {
        if(Input.GetKeyDown(KeyCode.W) && isGrounded && flight == false) {
            rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
        }

        if(Input.GetKeyDown(KeyCode.Q)) {
            if(flight == false) {
                GetComponent<Rigidbody2D>().gravityScale = 0;
                rb.AddForce(-rb.velocity, ForceMode2D.Impulse);
            } else {
                GetComponent<Rigidbody2D>().gravityScale = 1;
            }
            flight = !flight;
        }

        if(Input.GetKey(KeyCode.W) && flight) {
            transform.position += transform.up * flightSpeed * Time.deltaTime;
        }

        if(Input.GetKey(KeyCode.S) && flight) {
            transform.position += -transform.up * flightSpeed * Time.deltaTime;
        }

        if(Input.GetKey(KeyCode.D)) {
            transform.position += transform.right * speed * Time.deltaTime;
        }

        if(Input.GetKey(KeyCode.A)) {
            transform.position += -transform.right * speed * Time.deltaTime;
        }
    }

    void OnCollisionEnter2D(Collision2D targetObj){
        isGrounded = true;
        rb.velocity = Vector3.zero;
    }

    void OnCollisionExit2D(){
        isGrounded = false;
    }

    void CreatePrefab() {
        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg - 90;
        Quaternion rotation = Quaternion.Euler(this.transform.rotation.x, this.transform.rotation.y, angle);
        newInstance = Instantiate(Bullet, this.transform.position, rotation);
        Destroy(newInstance, despawnTime);
    }
}
