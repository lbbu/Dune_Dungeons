using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class BoxDetective : MonoBehaviour
{
    [SerializeField] GameObject Enemy;

    [SerializeField] ParticleSystem EnemyBoxPartical;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "EnemyBox")
        {
            StartCoroutine(BoxBehavior(EnemyBoxPartical, collision, Enemy));

        }
        else
        {

        }
    }


    IEnumerator  BoxBehavior(ParticleSystem Particle,Collision collision,GameObject obj)
    {
        Particle.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        GameObject temp = Instantiate(Enemy, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
        temp.SetActive(false);
        Destroy(collision.gameObject);
        temp.SetActive(true);
    }
    IEnumerator instantiateGameObject(GameObject obj,GameObject go)
    {
        yield return new WaitForSeconds(0.3f);
        Instantiate(Enemy, go.transform.position, go.transform.rotation);
        Debug.Log("Instantiate!");

    }
}
