﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject block;
    public Transform generationPoint;
    public float randomBlock;
    public float gemRate;
    private bool hasGem;
    // Start is called before the first frame update
    void Start()
    {
        if ((UnityEngine.Random.Range(0f, 1f)) <= gemRate)
        {
            hasGem = true;
        }
        else
        {
            hasGem = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Get().score == 0 )
        {
            if (transform.position.y < generationPoint.position.y-8f)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 8f, transform.position.z);
                randomBlock = 3;
                GameObject go = ObjectPool.instance.GetPooledObject(randomBlock.ToString());

                go.transform.position = transform.position;
            }
            
        }
        else if (GameManager.Get().score > 0 && GameManager.Get().score < 10)
        {
            if (transform.position.y < generationPoint.position.y)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 8f, transform.position.z);
                randomBlock = Random.Range(1, 6);
                GameObject go = ObjectPool.instance.GetPooledObject(randomBlock.ToString());
                HasGem();
                go.transform.position = transform.position;
            }
        }
        else if (GameManager.Get().score >= 10 && GameManager.Get().score < 20)
        {
            if (transform.position.y < generationPoint.position.y)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 8f, transform.position.z);
                randomBlock = Random.Range(1, 13);
                GameObject go = ObjectPool.instance.GetPooledObject(randomBlock.ToString());
                HasGem();
                go.transform.position = transform.position;
            }
        }
        else if (GameManager.Get().score >= 20 )
        {
            if (transform.position.y < generationPoint.position.y)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 8f, transform.position.z);
                randomBlock = Random.Range(1, 17);
                GameObject go = ObjectPool.instance.GetPooledObject(randomBlock.ToString());
                HasGem();
                go.transform.position = transform.position;
            }
        }
    }

    public void HasGem()
    {
        if ((Random.Range(0f, 1f)) <= gemRate)
        {
            hasGem = true;
        }
        else
        {
            hasGem = false;
        }

        if (hasGem)
        {
            GameObject go = ObjectPool.instance.GetPooledObject("Gem");

            go.transform.position = new Vector3(transform.position.x + Random.Range(-5f, 5f), transform.position.y + 3f, transform.position.z);
        }
        
    }
}
