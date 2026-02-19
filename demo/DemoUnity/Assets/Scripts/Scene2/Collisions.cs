using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour
{


    public HeatEnergy HeatEnergy;
    public ParticleSystem ObstacleDestruction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Permet de réellement enlever la barre de vie lorsqu'elle atteint 0
        if (HeatEnergy.Health <= 0) {
            HeatEnergy.HealthFill.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Détecte la collision sans bouclier
        if (other.CompareTag("Player") && gameObject.CompareTag("Obstacles") && !HeatEnergy.ShieldActive)
        {
            Debug.Log("collision!");
            Destroy(gameObject);
            ObstacleDestruction.Play();
            HeatEnergy.Health -= 34;
        } else if (other.CompareTag("Player") && gameObject.CompareTag("Obstacles") && HeatEnergy.ShieldActive)
        {
            Debug.Log("Protégé par le bouclier!");
            Destroy(gameObject);
            HeatEnergy.Health -= 23;
        }
    }
}
