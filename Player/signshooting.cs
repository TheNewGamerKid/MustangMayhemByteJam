using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class signshooting : MonoBehaviour
{
    public float fireRate = 0;
    public float Damage = 5;
    public static LayerMask whatToHit;
    public GameObject newInstance;
    public gun_enemy_handler geh = new gun_enemy_handler();

    private float timeToFire = 0;
    public static Transform firePoint;
    public GameObject Bullet;
    public float despawnTime = 5f;
    // Start is called before the first frame update
    void Awake()
    {
        Bullet = transform.Find("thrown sign");
        firePoint = transform.Find("FirePoint");
        if (firePoint == null)
        {
            Debug.LogError("No FirePoint. What?");
        }
    }

    public float offset;

    void Update()
    {
        Shoot();
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        if (fireRate == 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Shoot();
            }
        }

        else
        {
            if (Input.GetMouseButton(0) && Time.time > timeToFire)
            {
                timeToFire = Time.time + 1 / fireRate;
                Shoot();
            }
        }

    }
    void Shoot()
    {
        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition - firePointPosition, 100, whatToHit);
        Debug.DrawLine(firePointPosition, (mousePosition - firePointPosition) * 100, Color.blue);
        geh.Update();
        if (hit.collider != null)
        {
            Debug.DrawLine(firePointPosition, hit.point, Color.red);

        }
    }
}
