using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]

    public GameObject applePrefab;
    public GameObject goldApplePrefab;
    public GameObject poisonApplePrefab;
    public float speed = 1f;
    public float leftAndRightEdge = 10f;
    public float changeDirChance = 0.1f;
    public float appleDropDelay = 1f;
    public float goldAppleDropDelay = 3f;
    public float poisonAppleDropDelay = 3f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DropApple", 2f);
        Invoke("DropGoldApple", 3f);
        Invoke("DropPoisonApple", 5f);


    }

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", appleDropDelay);
    }
    void DropGoldApple()
    {
        GameObject goldApple = Instantiate<GameObject>(goldApplePrefab);
        goldApple.transform.position = transform.position;
        Invoke("DropGoldApple", goldAppleDropDelay);
    }
    void DropPoisonApple()
    {
        GameObject poisonApple = Instantiate<GameObject>(poisonApplePrefab);
        poisonApple.transform.position = transform.position;
        Invoke("DropPoisonApple", poisonAppleDropDelay);
    }    
    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if(pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);
        } 
        else if(pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);
        }
        else if(Random.value < changeDirChance)
        {
            speed *= -1;
        }
    }

    void FixedUpdate()
    {
        if(Random.value < changeDirChance)
        {
            speed *= -1;
        }
    }
}
