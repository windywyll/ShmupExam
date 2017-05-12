using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour {

    private int damage;
    private int speed;
    private int lifeSpan;
    private float startDeathTimer;
    private GameObject owner;
    private Rigidbody2D rBody;

	// Use this for initialization
	void Start () {
        damage = 3;
        speed = 7;
        lifeSpan = 3;
        rBody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {

        Move();

        if(startDeathTimer + lifeSpan < Time.time)
        {
            Destroy(gameObject);
        }
	}

    private void Move()
    {
        rBody.velocity = transform.up * speed;
    }

    public void SetOwner(GameObject _owner)
    {
        owner = _owner;

        startDeathTimer = Time.time;

        if (owner.tag == "Player")
        {
            owner.GetComponent<PlayerWeapon>().StartCoolDown();
        }
        else if (owner.tag == "Enemy")
        {
            if (owner.name.StartsWith("EnemyBulletSimple"))
            {
                owner.GetComponent<EnemyBulletWeapon>().StartCoolDown();
            }
            else if(owner.name.StartsWith("EnemyBulletOmni"))
            {
                //owner.GetComponent<EnemyOmniWeapon>().StartCoolDown();
            }
        }
    }

    public int GetDamage()
    {
        return damage;
    }
}
