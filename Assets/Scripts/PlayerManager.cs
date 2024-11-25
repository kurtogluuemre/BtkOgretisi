using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class PlayerManager : MonoBehaviour
{
    public float health;

    public float bulletSpeed;

    bool dead = false;

    Transform muzzle;

    public Slider slider;

    public Transform bullet;

    bool mouseIsNotOverUI; // pause seçenðine týklarken ateþ etmesinin önüne geçiyoruz

    // Start is called before the first frame update
    void Start()
    {
        muzzle = transform.GetChild(1);
        slider.maxValue = health;
        slider.value = health;
    }

    // Update is called once per frame
    void Update()
    {
        mouseIsNotOverUI = EventSystem.current.currentSelectedGameObject == null; //
        if(Input.GetMouseButtonDown(0) && mouseIsNotOverUI)
        {
            ShootBullet();
        }
    }

    public void GetDamage(float damage)
    {
        if (health - damage > 0) 
        {
            health -= damage;
        }
        else 
        {
            health = 0;
        }
        slider.value = health;
        AmIDead(); 
    }

    void AmIDead () 
    {
        if(health <= 0) 
        {
            DataManager.instance.LoseProcess();
            dead = true;
            // Destroy(gameObject); bu ölmesini saðlar
        }
    }

    void ShootBullet() 
    {
        Transform tempBullet;
        tempBullet = Instantiate(bullet,muzzle.position, Quaternion.identity);
        tempBullet.GetComponent<Rigidbody2D>().AddForce(muzzle.forward * bulletSpeed);
        DataManager.instance.ShootBullet++;
    }
}
