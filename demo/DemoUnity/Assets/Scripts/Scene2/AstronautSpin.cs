using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstronautSpin : MonoBehaviour
{

    public float speed = 100f;
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
