using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocket_handler : MonoBehaviour
{
    public float speed = 2.5f;
    private Vector3 playerPosition;
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
        transform.position += transform.right * speed * Time.deltaTime;
        playerPosition = GameObject.Find("Player").transform.position;
        xDifference = playerPosition.x - transform.position.x;
        yDifference = playerPosition.y - transform.position.y;
        hypotenuse = Mathf.Sqrt(Mathf.Pow(Mathf.Abs(xDifference), 2) + Mathf.Pow(yDifference, 2));

        float angle = Mathf.Atan2(yDifference, xDifference) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(this.transform.rotation.x, this.transform.rotation.y, angle);
        transform.rotation = rotation;
    }
}
