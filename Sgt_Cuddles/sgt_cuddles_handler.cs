using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sgt_cuddles_handler : MonoBehaviour
{
    public float sight = 25f;
    public float speed = 3f;
    public float despawnTime = 10f;
    public GameObject FireBall;
    public GameObject ArtilleryMarker;
    private Vector3 playerPosition;
    private Vector3 artilleryMarkerPosition;
    private GameObject newFireBall;
    private GameObject newArtilleryMarker;
    private float fireBallTime = -4f;
    private float artilleryTime = -40f;
    private float playerXDifference;
    private float playerYDifference;
    private float artilleryXDifference;
    private float artilleryYDifference;
    private float artilleryHypotenuse;
    private float playerHypotenuse;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MovementHandler();

        if(playerHypotenuse <= 7.5) {
            BreathFire();
        }

        if(playerHypotenuse <= 20 && playerHypotenuse >= 5) {
            markArtillery();
        }
    }

    void markArtillery() {
        float angle = Mathf.Atan2(playerYDifference, playerXDifference) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(this.transform.rotation.x, this.transform.rotation.y, angle);
        Vector3 position = new Vector3(this.transform.position.x, this.transform.position.y + 2, this.transform.position.z);
        if(Time.time - artilleryTime > 45) {
            artilleryTime = Time.time;
            newArtilleryMarker = Instantiate(ArtilleryMarker, position, rotation);
        }
    }

    void MovementHandler() {
        playerPosition = GameObject.Find("Player").transform.position;
        if(GameObject.Find("Artillery_Marker(Clone)") != null) {
            artilleryMarkerPosition = GameObject.Find("Artillery_Marker(Clone)").transform.position;
        }
        playerXDifference = playerPosition.x - transform.position.x;
        artilleryXDifference = artilleryMarkerPosition.x - transform.position.x;
        playerYDifference = playerPosition.y - transform.position.y;
        artilleryYDifference = artilleryMarkerPosition.y - transform.position.y;
        playerHypotenuse = Mathf.Sqrt(Mathf.Pow(Mathf.Abs(playerXDifference), 2) + Mathf.Pow(playerYDifference, 2));
        artilleryHypotenuse = Mathf.Sqrt(Mathf.Pow(Mathf.Abs(artilleryXDifference), 2) + Mathf.Pow(artilleryYDifference, 2));

        if(artilleryHypotenuse <= 30 && GameObject.Find("Artillery_Marker(Clone)") != null) {
                if(artilleryMarkerPosition.x > transform.position.x) {
                    transform.position += -transform.right * speed * Time.deltaTime;
                }
    
                if(artilleryMarkerPosition.x < transform.position.x) {
                    transform.position += transform.right * speed * Time.deltaTime;
                }
        } else {
            if(playerHypotenuse <= sight && playerHypotenuse >= 10 && GameObject.Find("Fire_Breath") == null) {
                if(playerPosition.x > transform.position.x) {
                    transform.position += transform.right * speed * Time.deltaTime;
                }

                if(playerPosition.x < transform.position.x) {
                    transform.position += -transform.right * speed * Time.deltaTime;
                }
            } else if(playerHypotenuse <= 2.5 && GameObject.Find("Fire_Breath") == null) {
                if(playerPosition.x > transform.position.x) {
                    transform.position += -transform.right * speed * Time.deltaTime;
                }

                if(playerPosition.x < transform.position.x) {
                    transform.position += transform.right * speed * Time.deltaTime;
                }
            }
        }
    }

    void BreathFire() {
        float angle = Mathf.Atan2(playerYDifference, playerXDifference) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(this.transform.rotation.x, this.transform.rotation.y, angle);
        if(Time.time - fireBallTime > 5) {
            fireBallTime = Time.time;
            newFireBall = Instantiate(FireBall, this.transform.position, rotation);
            Destroy(newFireBall, despawnTime);
        }
    }
}
