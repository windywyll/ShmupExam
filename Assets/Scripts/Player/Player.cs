using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private int life;
    private int score;
    private PlayerWeapon weaponManager;
    private float startDelayInvulnerability, delayInvulnerability;
    private float speed;
    private Rigidbody2D rBody;
    private Transform player;
    private Vector3 originalPosition;

    void OnTriggerEnter2D(Collider2D col)
    {
        Transform _root = col.transform.parent.parent;

        if(_root.tag == "Enemy" || _root.tag == "EnemyProjectile" || _root.tag == "Boss")
        {
            if (startDelayInvulnerability + delayInvulnerability > Time.time)
                return;

            Reset();

            if (!_root.tag.StartsWith("Boss"))
            {
                Destroy(_root.gameObject);
            }
            else
            {
                //make 10 of damage;
            }
        }

        if(_root.tag == "PowerUp")
        {
            string _powerup = _root.name;

            if(_powerup.StartsWith("BulletPU"))
            {
                weaponManager.changeWeapon(Weapons.BULLET);
            }

            if (_powerup.StartsWith("LaserPU"))
            {
                weaponManager.changeWeapon(Weapons.LAZER);
            }

            if (_powerup.StartsWith("MissilePU"))
            {
                weaponManager.changeWeapon(Weapons.MISSILE);
            }

            Destroy(_root.gameObject);
        }
    }

    // Use this for initialization
    void Awake () {
        life = 3;
        score = 0;
        startDelayInvulnerability = -1;
        delayInvulnerability = 1.5f;
        speed = 5;
        rBody = GetComponent<Rigidbody2D>();
        player = transform;
        weaponManager = GetComponent<PlayerWeapon>();
        originalPosition = player.position;
	}
	
	// Update is called once per frame
	void Update () {
        AutoFire();

        //Debug.Log(score);
	}

    void Reset()
    {
        player.position = originalPosition;
        life--;
        startDelayInvulnerability = Time.time;

        if (life == 0)
            Destroy(gameObject);
    }

    public void Move(Vector2 _direction)
    {
        rBody.velocity = _direction * speed;
    }

    private void AutoFire()
    {
        weaponManager.Shoot();
    }

    public void AddScore(int _points)
    {
        score += _points;
    }
}
