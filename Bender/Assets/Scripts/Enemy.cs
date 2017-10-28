using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public GameObject player;
    public float speed;
    public float hp;
    public float damage;
    public bool chasePlayer = true;
    public float damageRange = 1f;

    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (chasePlayer)
        {
            ChasePlayer();
        }
	}

    public void ChasePlayer()
    {
        transform.LookAt(player.transform);
        Vector3 directionVector = player.transform.position - transform.position;
        transform.position += directionVector.normalized * speed * Time.deltaTime;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            //collision.transform.GetComponent<Player>().Attacked();
            Destroy(gameObject);
        }
    }

}
