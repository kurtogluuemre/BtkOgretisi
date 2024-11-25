using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI Componenetleri i�in

public class Enemy : MonoBehaviour
{
    public float health;
    public float damage;

    

    bool colliderBusy = false;

    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = health;
        slider.value = health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) // Is trigger se�ili oldu�unda o collidera ba�ka bir colliderin yani enemiye playerin giri� yapt���n�
    {
        if (other.tag == "Player" && !colliderBusy)
        {
            colliderBusy = true;  
            other.GetComponent<PlayerManager>().GetDamage(damage);
        }

        if (other.tag == "Bullet")
        {
            GetDamage(other.GetComponent<BulletManager>().bulletDamage);
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D other) // Bu colliderin i�inde bulunmakta olan colliderleri tespit ederiz
    {
        
    }

    private void OnTriggerExit2D(Collider2D other) // Colliderdan ��k�� yapan colliderlar� da bunla tespit ederiz
    {
        if (other.tag == "Player")
        {
            colliderBusy = false ; 
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

    void AmIDead()
    {
        if (health <= 0)
        {
            DataManager.instance.EnemyKilled++;
            Destroy(gameObject);
        }
    }
}
