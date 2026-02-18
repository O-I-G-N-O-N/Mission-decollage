using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CockpitTablet : MonoBehaviour
{

    public GameObject RocketBaseState;
    public GameObject RocketDamagedRight;
    public GameObject RocketDamagedLeft;
    public GameObject RocketDamagedMain;
    public GameObject RocketDamagedEngine;

    // Start is called before the first frame update
    void Start()
    {
        RocketBaseState.SetActive(true);
        RocketDamagedEngine.SetActive(false);
        RocketDamagedLeft.SetActive(false);
        RocketDamagedRight.SetActive(false);
        RocketDamagedMain.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
