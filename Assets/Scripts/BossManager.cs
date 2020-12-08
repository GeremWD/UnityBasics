using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    public UIManager uiManager;
    public Transform spawner1, spawner2;
    public GameObject missilePrefab, deathPrefab;
    public Material bossMaterial;
    public float maxLife = 0.6f;

    private GameObject player;
    private float life;
    private Color originalColor;

    // Start is called before the first frame update
    void Start()
    {
        originalColor = Color.white;
        resetColor();
        uiManager.transform.Find("BossBar").gameObject.SetActive(true);
        GetComponentInChildren<Light>().enabled = true;
        life = maxLife;
        player = GameObject.Find("Player");
        InvokeRepeating("Shoot1", 2f, 1f);
        InvokeRepeating("Shoot2", 2.5f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);
    }

    void Shoot1()
    {
        Shoot(spawner1);
    }

    void Shoot2()
    {
        Shoot(spawner2);
    }

    void Shoot(Transform spawner)
    {
        GameObject missile = Instantiate(missilePrefab, spawner.position, spawner.rotation);
        missile.transform.LookAt(player.transform);
    }

    public void hurt(float value)
    {
        bossMaterial.color = Color.red;
        Invoke("resetColor", 0.3f);

        life -= value;
        if(life < 0f)
        {
            resetColor();
            life = 0f;
            uiManager.setBossLife(0f);
            GameObject deathClone = Instantiate(deathPrefab, transform.position, Quaternion.Euler(0, 0, 0));
            Object.Destroy(deathClone, deathClone.GetComponent<ParticleSystem>().main.duration - 0.5f);
            uiManager.PrepareWin();
            Object.Destroy(this.gameObject);
            return;
        }
        uiManager.setBossLife(life / maxLife);
    }

    void resetColor()
    {
        bossMaterial.color = originalColor;
    }
}
