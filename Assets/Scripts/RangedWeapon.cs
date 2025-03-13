﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RangedWeapon : Weapon
{
    public RangedWeapon(int damage_min, int damage_max, int range) : base(damage_min, damage_max, range)
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame



    public float offset;
    public GameObject projectile;
    //public GameObject shotEffect;
    public Transform shotPoint;
    public Animator camAnim;
    private float timeBtwShots;
    public float startTimeBtwShots;

    private void Update()
    {
        // Handles the weapon rotation
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        if (timeBtwShots <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                //Instantiate(shotEffect, shotPoint.position, Quaternion.identity);
                //camAnim.SetTrigger("shake");
                Instantiate(projectile, shotPoint.position, transform.rotation);
                timeBtwShots = startTimeBtwShots;
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }


    }
}

