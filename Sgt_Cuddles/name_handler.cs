using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class name_handler : MonoBehaviour
{
    private string[] rank = {"Major", "Lt.", "Sgt.", "Cpl.", "Colonel", "General", "Cpt."};
    private string[] name = {"Cuddles", "Fluffles", "Squeaks", "Tiny"};
    // Start is called before the first frame update
    void Start()
    {
        int randRank = Random.Range(0, rank.Length);
        int randName = Random.Range(0, name.Length);
        GetComponent<TMPro.TextMeshPro>().text = rank[randRank] + " " + name[randName];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
