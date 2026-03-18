using NUnit.Framework.Constraints;
using System.Collections;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{


    public GameObject ballsplittwo;
    public GameObject ballsplitthree;
    public GameObject ballonehp;
    public GameObject balltwohp;
    public float respawnTime2split = 30.0f;
    public float respawnTime3split = 40.0f;
    public float respawnTimeonehp = 10f;
    public float respawnTimetwohp = 15f;

    Vector2 pos = new Vector2(0f, 4f);



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(powerupRandom2split());
        StartCoroutine(powerupRandom3split());
        StartCoroutine(powerup1HP());
        StartCoroutine(powerup2HP());

    }
    public void spawnCore2split()
    {

        GameObject a = Instantiate(ballsplittwo) as GameObject;
        a.transform.position = pos;

    }

    public void spawnCore3split()
    {

        GameObject a = Instantiate(ballsplitthree) as GameObject;
        a.transform.position = pos;

    }
    public void spawn1HP()
    {

        GameObject a = Instantiate(ballonehp) as GameObject;
        a.transform.position = pos;

    }

    public void spawn2HP()
    {

        GameObject a = Instantiate(balltwohp) as GameObject;
        a.transform.position = pos;

    }

    // Update is called once per frame
    void Update()
    {
        //Invoke("spawnCore", 1);
        //five hundred balls

    }
    IEnumerator powerupRandom2split()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime2split);
            spawnCore2split();
        }
    }

    IEnumerator powerupRandom3split()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime3split);
            spawnCore3split();
        }
    }

    IEnumerator powerup1HP()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTimeonehp);
            spawn1HP();
        }
    }

    IEnumerator powerup2HP()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTimetwohp);
            spawn2HP();
        }
    }
}
