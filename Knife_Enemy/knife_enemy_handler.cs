using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knife_enemy_handler : MonoBehaviour
{
    public float speed = 2.5f;
    public float time;
    public float sight = 7.5f;
    public GameObject Enemy_Attack_Left;
    public GameObject Enemy_Attack_Right;
    public GameObject Enemy_Attack_Up;
    private GameObject newInstance;
    private bool ran_left = false;
    private bool ran_right = false;
    private bool ran_up = false;
    private float xDifference;
    private float yDifference;
    private Vector3 playerPosition;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = GameObject.Find("Player").transform.position;
        xDifference = playerPosition.x - transform.position.x;
        yDifference = Mathf.Abs(playerPosition.y - transform.position.y);

        if(Mathf.Sqrt(Mathf.Pow(Mathf.Abs(xDifference), 2) + Mathf.Pow(yDifference, 2)) <= sight) {
            if(playerPosition.x > transform.position.x) {
                transform.position += transform.right * speed * Time.deltaTime;
            }

            if(playerPosition.x < transform.position.x) {
                transform.position += -transform.right * speed * Time.deltaTime;
            }
        }

        if(yDifference <= 1 && xDifference >= -2 && xDifference <= -.55 && GameObject.Find("Enemy_Attack_Up(Clone)") == null && GameObject.Find("Enemy_Attack_Left(Clone)") == null && GameObject.Find("Enemy_Attack_Right(Clone)") == null) {
            if(ran_left == false) {
                ran_left = true;
                CreatePrefabLeft();
            }

            if(Time.time - time > 3) {
                CreatePrefabLeft();
            }
        } else if(Time.time - time > 1) {
            Destroy(newInstance);
        }

        if(yDifference <= 1 && xDifference <= 2 && xDifference >= .55 && GameObject.Find("Enemy_Attack_Up(Clone)") == null && GameObject.Find("Enemy_Attack_Left(Clone)") == null && GameObject.Find("Enemy_Attack_Right(Clone)") == null) {
            if(ran_right == false) {
                ran_right = true;
                CreatePrefabRight();
            }

            if(Time.time - time > 3) {
                CreatePrefabRight();
            }
        } else if(Time.time - time > 1) {
            Destroy(newInstance);
        }

        if(yDifference >= 1 && yDifference <= 2 && Mathf.Abs(xDifference) <= 1 && GameObject.Find("Enemy_Attack_Up(Clone)") == null && GameObject.Find("Enemy_Attack_Left(Clone)") == null && GameObject.Find("Enemy_Attack_Right(Clone)") == null) {
            if(ran_up == false) {
                ran_up = true;
                CreatePrefabUp();
            }

            if(Time.time - time > 3) {
                CreatePrefabUp();
            }
        } else if(Time.time - time > 1) {
            Destroy(newInstance);
        }

        void CreatePrefabLeft() {
            time = Time.time;
            newInstance = Instantiate(Enemy_Attack_Left, this.transform, false );
        }

        void CreatePrefabUp() {
            time = Time.time;
            newInstance = Instantiate(Enemy_Attack_Up, this.transform, false );
        }

        void CreatePrefabRight() {
            time = Time.time;
            newInstance = Instantiate(Enemy_Attack_Right, this.transform, false );
        }
    }
}
