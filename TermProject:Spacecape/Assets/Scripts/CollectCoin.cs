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

    public AudioClip coinSound;

    public CoinHandler coinHandler;

    public static int coinValue = 0;

    // Start is called before the first frame update
    void Start()
    {
        coinHandler = GameObject.Find("Canvas").GetComponent<CoinHandler>();

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
        else
        {
            float dist = Vector3.Distance(transform.position, playerObject.transform.position);
            if (dist < 3f)
            {
                AudioSource.PlayClipAtPoint(coinSound, playerObject.position);
                Destroy(gameObject);
                coinValue++;
            }
        }

        if(coinValue == 4)
        {
            if (key != null)
            key.SetActive(true);

            coinHandler.level = 6;
        }

        if(coinValue == 6)
        {
            gumball.SetActive(true);

            coinHandler.level = 7;
        }

        if (coinValue == 7)
        {
            penny.SetActive(true);
            patrick.SetActive(true);

            coinHandler.level = 8;
        }
        
        if (coinValue == 8)
        {
            carrie.SetActive(true);
            bananajoe.SetActive(true);

            coinHandler.level = 9;
        }

        if (coinValue == 9)
        {
            joanna.SetActive(true);
            daisy.SetActive(true);

            coinHandler.level = 10;
        }

        if (coinValue == 10)
        {
            yuki.SetActive(true);
            lucy.SetActive(true);
        }

        coinHandler.coins = coinValue;

    }
}
