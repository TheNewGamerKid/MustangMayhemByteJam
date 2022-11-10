using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeHandler : MonoBehaviour
{

    public float totalTime = 5f;
    public float timeElapsed = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update(){
        if(timeElapsed < totalTime) {
            timeElapsed = Time.time;
            GetComponent<TMPro.TextMeshPro>().text = Mathf.Ceil(totalTime - timeElapsed).ToString();
        }
       

    }
}
