using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    public float speed;
    public float hurtingDistance;
    public float damage;

    public GameObject deathPrefab;
    public GameObject explosionPrefab;

    private PlayerManager player;
    private BossManager boss;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerManager>();
        GameObject bossObject = GameObject.Find("Boss");
        if(bossObject)
            boss = GameObject.Find("Boss").GetComponent<BossManager>();
        Invoke("die", 3f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += speed * transform.forward * Time.deltaTime;
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            GameObject deathClone = Instantiate(deathPrefab, col.transform.position, Quaternion.Euler(0, 0, 0));
            Object.Destroy(deathClone, deathClone.GetComponent<ParticleSystem>().main.duration - 0.5f);
            Object.Destroy(col.gameObject);
        }
        Vector3 explosionPoint = transform.position + 0.75f * transform.forward;
        GameObject explosionClone = Instantiate(explosionPrefab, explosionPoint, Quaternion.Euler(0, 0, 0));
        explosionClone.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

        if (Vector3.Distance(explosionPoint, player.transform.position) < hurtingDistance)
        {
            player.hurt(damage);
        }

        if (boss && col.gameObject.tag == "Boss")
        {
            boss.hurt(damage);
        }
        
        Object.Destroy(explosionClone, explosionClone.GetComponent<ParticleSystem>().main.duration - 0.5f);
        Object.Destroy(this.gameObject);
    }

    void die()
    {
        Object.Destroy(this.gameObject);
    }
}
