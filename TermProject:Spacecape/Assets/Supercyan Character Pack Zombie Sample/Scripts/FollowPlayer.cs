using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{

    public Transform target;
    NavMeshAgent nav;


    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(target.position, transform.position);
        if(dist < 50)
        nav.SetDestination(target.position);
    }
}
