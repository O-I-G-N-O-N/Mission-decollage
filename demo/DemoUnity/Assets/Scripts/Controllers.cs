using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controllers : MonoBehaviour
{


    [Header("Scripts")]
    public HeatEnergy HeatEnergy;
    public FirstPersRocket FirstPersRocket;

    [Header("Buttons")]
    public bool Button1 = false;
    public bool Button2 = false;
    public bool Button3 = false;
    public bool Button4 = false;
    public bool Button5 = false;
    public bool Button6 = false;
    public bool TurningButton1 = false;
    public bool TurningButton2 = false;
    public bool TurningButton3 = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // ACTIVATION DES BOUTONS

        // BOUTON 1 -- BOUCLIERS
        if (Input.GetKey(KeyCode.Alpha1))
    {
        Button1 = true;
    } else
        {
            Button1 = false;
        }

        // BOUTON 2 -- LUMIÈRES
        if (Input.GetKeyDown(KeyCode.Alpha2))
    {
        Button2 = true;
        Debug.Log(Button2);
    } else
        {
            Button2 = false;
        }


        // BOUTON 3 -- RADAR
        if (Input.GetKeyDown(KeyCode.Alpha3))
    {
        Button3 = true;
        Debug.Log(Button3);
    } else
        {
            Button3 = false;
        }


        // BOUTON 4 -- MORSE
        if (Input.GetKeyDown(KeyCode.Alpha4))
    {
        Button4 = true;
        Debug.Log(Button4);
    } else
        {
            Button4 = false;
        }


        // BOUTON 5 -- MORSE
        if (Input.GetKeyDown(KeyCode.Alpha5))
    {
        Button5 = true;
        Debug.Log(Button5);
    } else
        {
            Button5 = false;
        }


        // BOUTON 6 -- MORSE
        if (Input.GetKeyDown(KeyCode.Alpha6))
    {
        Button6 = true;
        Debug.Log(Button6);
    } else
        {
            Button6 = false;
        }


        // TURNING BUTTON 1 -- DRIFT
        if (Input.GetKey(KeyCode.Alpha7))
    {
        TurningButton1 = true;
        Debug.Log(TurningButton1);
    } else
        {
            TurningButton1 = false;
        }


        // TURNING BUTTON 2 -- RECHARGEMENT D'ÉNERGIE
        if (Input.GetKey(KeyCode.Alpha8))
    {
        TurningButton2 = true;
        Debug.Log(TurningButton1);
    } else
        {
            TurningButton2 = false;
        }


        // TURNING BUTTON 3 -- REFROIDISSEMENT MOTEUR
        if (Input.GetKey(KeyCode.Alpha9))
    {
        TurningButton3 = true;
        Debug.Log(TurningButton1);
    } else
        {
            TurningButton3 = false;
        }
    }
}
