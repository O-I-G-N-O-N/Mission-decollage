using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindZones : MonoBehaviour
{

    public GameObject Player;
    // Start is called before the first frame updatepublic float rotationSpeed = 50f;
    private bool inWindZone = false;
    public float WindDirection = 1;

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (CompareTag("WindZone"))
        {
            Debug.Log("WINDZONE ENTER");
            inWindZone = true;
            WindDirection = Random.value < 0.5f ? -1f : 1f;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (CompareTag("WindZone"))
        {
            Debug.Log("WINDZONE EXIT");
            inWindZone = false;
        }
    }

    void Update()
    {
        if (inWindZone)
        {
            Player.transform.Rotate(Vector3.forward * 4f * -WindDirection * Time.deltaTime);
            Player.transform.Translate(Vector3.right * 40f * WindDirection * Time.deltaTime);
        }
    }
}
