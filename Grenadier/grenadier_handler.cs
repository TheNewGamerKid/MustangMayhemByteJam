using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenadier_handler : MonoBehaviour
{
    public int type;
    public GameObject[] Grenade;
    private GameObject newGrenade;
    private float GrenadeTime = -40f;
    private float playerXDifference;
    private float playerYDifference;
    private float playerHypotenuse;
    private Vector3 playerPosition;
    private float health = 20f;

    // Start is called before the first frame update
    void Start()
    {
        type = Random.Range(1, 3);
        Debug.Log(type);
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = GameObject.Find("Player").transform.position;
        playerXDifference = playerPosition.x - transform.position.x;
        playerYDifference = playerPosition.y - transform.position.y;

        float angle = Mathf.Atan2(playerYDifference, playerXDifference) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(this.transform.rotation.x, this.transform.rotation.y, angle);
        Vector3 position = new Vector3(this.transform.position.x, this.transform.position.y + 2, this.transform.position.z);
        if(Time.time - GrenadeTime > 45) {
            GrenadeTime = Time.time;
            newGrenade = Instantiate(Grenade[type - 1], position, rotation);
        }

        GameObject[] attacks = GameObject.FindGameObjectsWithTag("Player_Attacks");
        
        foreach(GameObject attack in attacks) {
            float x = gameObject.transform.position.x - attack.transform.position.x;
            float y = gameObject.transform.position.y - attack.transform.position.y;
            float hypotenuse = Mathf.Sqrt(Mathf.Pow(Mathf.Abs(x), 2) + Mathf.Pow(y, 2));

            Debug.Log(hypotenuse);

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
