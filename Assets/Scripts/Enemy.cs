using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI Componenetleri için

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

    private void OnTriggerEnter2D(Collider2D other) // Is trigger seçili olduðunda o collidera baþka bir colliderin yani enemiye playerin giriþ yaptýðýný
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

    private void OnTriggerStay2D(Collider2D other) // Bu colliderin içinde bulunmakta olan colliderleri tespit ederiz
    {
        
    }

    private void OnTriggerExit2D(Collider2D other) // Colliderdan çýkýþ yapan colliderlarý da bunla tespit ederiz
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
