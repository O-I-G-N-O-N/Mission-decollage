using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpin : MonoBehaviour
{

    public float speed = 50f;
    private Vector3 randomDirection;
    // Start is called before the first frame update
    void Start()
    {
        randomDirection = Random.onUnitSphere;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(randomDirection * speed * Time.deltaTime);
    }
}
