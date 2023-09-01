using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class BoxDetective : MonoBehaviour
{
    [SerializeField] GameObject Enemy;
    [SerializeField] GameObject goldKey;
    [SerializeField] GameObject silverKey;

    [SerializeField] GameObject AllEnemys;
    
    [SerializeField] ParticleSystem BoxPartical;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "EnemyBox")
        {
            StartCoroutine(BoxBehavior(collision, Enemy));
        }
        else
        if(collision.gameObject.tag == "SelverKeyBox")
        {
            StartCoroutine(BoxBehavior(collision, silverKey));
        }
        else
        if (collision.gameObject.tag == "GoldKeyBox")
        {
            StartCoroutine(BoxBehavior( collision,goldKey));
        }
    }


    IEnumerator  BoxBehavior(Collision collision,GameObject obj)
    {
        GameObject ParticalTemp =
        Instantiate(BoxPartical.gameObject, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
        yield return new WaitForSeconds(0.4f);
        Destroy(collision.gameObject);
        GameObject temp = Instantiate(obj, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
        temp.SetActive(false);
        Destroy(ParticalTemp);
        temp.SetActive(true);
        
        if(obj.tag == "Enemy" )
        {
            temp.transform.parent = AllEnemys.transform;
        }
    }
    IEnumerator instantiateGameObject(GameObject obj,GameObject go)
    {
        yield return new WaitForSeconds(0.3f);
        Instantiate(Enemy, go.transform.position, go.transform.rotation);
        Debug.Log("Instantiate!");

    }
}
