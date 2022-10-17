using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class artillery_marker_handler : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject ArtilleryStrike;
    private Vector3 location;
    private float time = 0;
    private GameObject newArtilleryStrike;
    private int numStrikes;
    // Start is called before the first frame update
    void Start()
    {
        rb.AddForce(transform.right * 10, ForceMode2D.Impulse);
        numStrikes = Random.Range(3, 7);
    }

    // Update is called once per frame
    void Update()
    {
        location = transform.position;
        if(Time.time - time > 12.5) {
            float totalStrikeSize = numStrikes * 10;
            location = new Vector3(transform.position.x - (totalStrikeSize / 2) + 500, transform.position.y + 500, 0);
            Quaternion rotation = Quaternion.Euler(this.transform.rotation.x, this.transform.rotation.y, -315);
            for(int i = 0; i < numStrikes; i++) {
                newArtilleryStrike = Instantiate(ArtilleryStrike, location, rotation);
                location = new Vector3(transform.position.x - (totalStrikeSize / 2) + 500 + ((i + 1) * 10), transform.position.y + 500, 0);
            }
            Destroy(GameObject.Find("Artillery_Marker(Clone)"));
        }
    }
}
