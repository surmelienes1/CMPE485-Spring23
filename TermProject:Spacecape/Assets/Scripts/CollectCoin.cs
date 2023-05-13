using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{

    public GameObject key;

    public GameObject gumball;

    public GameObject penny;

    public GameObject patrick;

    public GameObject carrie;

    public GameObject bananajoe;

    public GameObject joanna;

    public GameObject daisy;

    public GameObject yuki;

    public GameObject lucy;

    public Transform playerObject;

    public static int coinValue = 0;

    // Start is called before the first frame update
    void Start()
    {
        key.SetActive(false);
        gumball.SetActive(false);
        penny.SetActive(false);
        patrick.SetActive(false);
        carrie.SetActive(false);
        bananajoe.SetActive(false);
        joanna.SetActive(false);
        daisy.SetActive(false);
        yuki.SetActive(false);
        lucy.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerObject == null)
        {
            coinValue = 0;
        }

        float dist = Vector3.Distance(transform.position, playerObject.transform.position);
        if (dist < 3f)
        {
            Destroy(gameObject);
            coinValue++;
        }

        if(coinValue == 4)
        {
            if (key != null)
            key.SetActive(true);
        }

        if(coinValue == 6)
        {
            gumball.SetActive(true);
        }

        if (coinValue == 7)
        {
            penny.SetActive(true);
            patrick.SetActive(true);
        }
        
        if (coinValue == 8)
        {
            carrie.SetActive(true);
            bananajoe.SetActive(true);
        }

        if (coinValue == 9)
        {
            joanna.SetActive(true);
            daisy.SetActive(true);
        }

        if (coinValue == 10)
        {
            yuki.SetActive(true);
            lucy.SetActive(true);
        }

    }
}
