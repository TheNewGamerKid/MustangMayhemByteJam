using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player_handler : MonoBehaviour
{
    public Rigidbody2D rb;
    public float jumpAmount = 10;
    public float speed = 5;
    public float flightSpeed = 10;
    public bool flight = false;
    public double curHealth = 0;
    public double maxHealth = 1;
    public double healthBar = 1;
    public double healthNumber;
    private bool isGrounded = true;
    private Vector3 playerPosition;
    private GameObject[] attacks;
    private float xDifference;
    private float yDifference;
    private float hypotenuse;
    public float accuracy = 5f;
    public float magCap = 7f;
    public float reloadTime = 5f;
    public float cyclicRate = .25f;
    public float despawnTime = 500f;
    public GameObject Bullet1;

    private GameObject newInstance;
    private float numShots = 0f;
    private float time = .5f;
    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = GameObject.Find("Player").transform.position;
        attacks = GameObject.FindGameObjectsWithTag("Enemy_Attack");
        foreach (GameObject attack in attacks)
        {
            xDifference = playerPosition.x - attack.transform.position.x;
            yDifference = playerPosition.y - attack.transform.position.y;
            hypotenuse = Mathf.Sqrt(Mathf.Pow(Mathf.Abs(xDifference), 2) + Mathf.Pow(yDifference, 2));
            if (hypotenuse < 1)
            {
                Destroy(attack);

                if(attack.name == "Bullet(Clone)") {
                    DamagePlayer(.05);
                }
            
                if(attack.name == "Rocket(Clone)") {
                    DamagePlayer(.30);
                }
            
                if(attack.name == "Knife_Left(Clone)") {
                    DamagePlayer(.45);
                }
                if(attack.name == "Knife_Right(Clone)") {
                    DamagePlayer(.45);
                }
            
                if(attack.name == "Knife_Up(Clone)") {
                    DamagePlayer(.45);
                }

        

                if (attack.name == "Bullet(Clone)")
                {
                    DamagePlayer(.05);
                }

                if (attack.name == "Rocket(Clone)")
                {
                    DamagePlayer(.30);
                }

                if (attack.name == "Knife_Left(Clone)")
                {
                    DamagePlayer(.45);
                }
                if (attack.name == "Knife_Right(Clone)")
                {
                    DamagePlayer(.45);
                }

                if (attack.name == "Knife_Up(Clone)")
                {
                    DamagePlayer(.45);
                }



            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {

            DamagePlayer(.50);
        }

        if (Input.GetMouseButtonDown(0))
        {
            CreatePrefab();
        }

        //death stuff
        if (curHealth < 0) {
            SceneManager.LoadScene("Dead");
        }
        MovementHandler();

    }
    //Movement stuff
    void MovementHandler()
    {
        if (Input.GetKeyDown(KeyCode.W) && isGrounded && flight == false)
        {
            rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (flight == false)
            {
                GetComponent<Rigidbody2D>().gravityScale = 0;
                rb.AddForce(-rb.velocity, ForceMode2D.Impulse);
            }
            else
            {
                GetComponent<Rigidbody2D>().gravityScale = 1;
            }
            flight = !flight;
        }

        if (Input.GetKey(KeyCode.W) && flight)
        {
            transform.position += transform.up * flightSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S) && flight)
        {
            transform.position += -transform.up * flightSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += -transform.right * speed * Time.deltaTime;
        }
    }

    public void DamagePlayer(double damage)
    {
        {
            curHealth -= damage;


            healthBar = curHealth;

            healthNumber = healthBar;



        }
    }

    void CreatePrefab()
    {
            Quaternion rotation = Quaternion.Euler(this.transform.rotation.x, this.transform.rotation.y, 10);       
            numShots++;            
            newInstance = Instantiate(Bullet1);
            Destroy(newInstance, despawnTime);
    }


        void OnCollisionEnter2D(Collision2D targetObj)
        {
            isGrounded = true;
        }

        void OnCollisionExit2D()
        {
            isGrounded = false;
        }
}