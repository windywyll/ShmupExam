using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    private float life;
    private int score;

    [SerializeField]
    private bool elite;
    private Player player;

    private GameObject[] PowerUp;

    void OnTriggerEnter2D(Collider2D col)
    {
        Transform _root = col.transform.parent.parent;

        if (_root.tag == "PlayerProjectile")
        {
            float _lifeLost = 0;

            if (_root.name.StartsWith("Laser"))
                _lifeLost = _root.GetComponent<LaserBehaviour>().GetDamage();

            if (_root.name.StartsWith("Bullet"))
                _lifeLost = _root.GetComponent<BulletBehaviour>().GetDamage();

            if (_root.name.StartsWith("Missile"))
                _lifeLost = _root.GetComponent<MissileBehaviour>().GetDamage();

            LoseLife(_lifeLost);

            if (life <= 0)
            {
                Destroy(_root.gameObject);
                Destroy(gameObject);


            }
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        Transform _root = col.transform.parent.parent;

        if (_root.tag == "PlayerProjectile")
        {
            float _lifeLost = 0;

            if (_root.name == "Laser")
            {
                _lifeLost = _root.GetComponent<LaserBehaviour>().GetDamage();
            }

            LoseLife(_lifeLost);
        }
    }

    // Use this for initialization
    void Start () {
        life = 2;
        score = 1000;

        if (elite)
        {
            life += 8;
            score += 2542;
        }

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}

    private void LoseLife(float _lifeLost)
    {
        life -= _lifeLost;

        if (life <= 0)
        {
            player.AddScore(score);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
