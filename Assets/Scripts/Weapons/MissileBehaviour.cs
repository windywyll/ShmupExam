using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileBehaviour : MonoBehaviour {

    private int damage;
    private int speed;
    private int lifeSpan;
    private float startDeathTimer;
    private GameObject owner;
    private Rigidbody2D rBody;
    private bool foundNearest;
    private Vector3 direction;

    private Transform nearest;

    // Use this for initialization
    void Start () {
        damage = 8;
        speed = 2;
        lifeSpan = 5;
        startDeathTimer = Time.time;
        rBody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {

        Move();

        if (startDeathTimer + lifeSpan < Time.time)
        {
            Destroy(gameObject);
        }
    }

    private void Move()
    {
        direction = nearest.position - transform.position;
        direction.Normalize();
        rBody.velocity = direction * speed;
    }

    public void SetOwner(GameObject _owner)
    {
        owner = _owner;

        owner.GetComponent<PlayerWeapon>().StartCoolDown();
    }

    public int GetDamage()
    {
        return damage;
    }
}
