using extOSC;

using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using UnityEngine.UI;
 


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
    


    [Header("Sliders // Propulseurs")]

    public Slider RightSlider;

    public Slider MainSlider;

    public Slider LeftSlider;

    [Header("Switch à capot")]

    public bool FlipSwitch1 = false;

    public bool FlipSwitch2 = false;

    public bool FlipSwitch3 = false;
 
    public OSCReceiver oscReceiver;

    private int etatEnMemoire = 0; // L'état initial est défini comme "bouton relâché"
    private int etatEnMemoire2 = 0;
 
 
    // Start is called before the first frame update

    void Start()

    {
        oscReceiver.Bind("/device1/input1", TraiterOscRepair2);
        oscReceiver.Bind("/device1/input2", TraiterOscRepair1);
        oscReceiver.Bind("/device3/input1", TraiterOscBouclier);
        oscReceiver.Bind("/device3/input2", TraiterOscRadar);
        oscReceiver.Bind("/device2/input1", TraiterOscRepair3);
        oscReceiver.Bind("/device1/input3", TraiterOscRecharge);
        oscReceiver.Bind("/device2/input3", TraiterOscDrift);
        oscReceiver.Bind("/device3/input3", TraiterOscRefroidissement);
        oscReceiver.Bind("/device1/input4", TraiterOscFlipSwitch3);
        oscReceiver.Bind("/device2/input4", TraiterOscFlipSwitch2);
        oscReceiver.Bind("/device3/input4", TraiterOscFlipSwitch1);
        oscReceiver.Bind("/device2/input2", TraiterOscLumiere);
    }
 
    void TraiterOscRadar(OSCMessage message)

    {

        // Si le message n'a pas d'argument ou l'argument n'est pas un Int on l'ignore

        if (message.Values.Count == 0)

        {

            Debug.Log("No value in OSC message");

            return;

        }
 
        if (message.Values[0].Type != OSCValueType.Int)

        {

            Debug.Log("Value in message is not an Int");

            return;

        }
 
        // Récupérer la valeur de l’angle depuis le message OSC

        int value = message.Values[0].IntValue;
 
        int nouveauEtat = value; // REMPLACER ici les ... par le code qui récupère la nouvelle donnée du flux
 
        if (etatEnMemoire != nouveauEtat)

        {

            etatEnMemoire = nouveauEtat;
 
            if (nouveauEtat == 1)

            {

                // METTRE ici le code exécuté lorsque le bouton est appuyé
                Button3 = true;

            }

            else

            {

                // METTRE ici le code exécuté lorsque le bouton est relâché

                Button3 = false;

            }

        }
 
 
    }

    void TraiterOscBouclier(OSCMessage message)

    {

        // Si le message n'a pas d'argument ou l'argument n'est pas un Int on l'ignore

        if (message.Values.Count == 0)

        {

            Debug.Log("No value in OSC message");

            return;

        }
 
        if (message.Values[0].Type != OSCValueType.Int)

        {

            Debug.Log("Value in message is not an Int");

            return;

        }
 
        // Récupérer la valeur de l’angle depuis le message OSC

        int value = message.Values[0].IntValue;
 
        if (value == 1)

            {
                Button1 = true;
            }
            
            else

            {

                // METTRE ici le code exécuté lorsque le bouton est relâché

                Button1 = false;

            }
    }

    void TraiterOscLumiere(OSCMessage message)

    {
                // Si le message n'a pas d'argument ou l'argument n'est pas un Int on l'ignore

        if (message.Values.Count == 0)

        {

            Debug.Log("No value in OSC message");

            return;

        }
 
        if (message.Values[0].Type != OSCValueType.Int)

        {

            Debug.Log("Value in message is not an Int");

            return;

        }
 
        // Récupérer la valeur de l’angle depuis le message OSC

        int value = message.Values[0].IntValue;
 
        int nouveauEtat = value; // REMPLACER ici les ... par le code qui récupère la nouvelle donnée du flux
 
        if (etatEnMemoire2 != nouveauEtat)

        {

            etatEnMemoire2 = nouveauEtat;
 
            if (nouveauEtat == 1)

            {

                // METTRE ici le code exécuté lorsque le bouton est appuyé
                Button2 = true;

            }

            else

            {

                // METTRE ici le code exécuté lorsque le bouton est relâché

                Button2 = false;

            }

        }
    }

    void TraiterOscFlipSwitch1(OSCMessage message)

    {

        // Si le message n'a pas d'argument ou l'argument n'est pas un Int on l'ignore

        if (message.Values.Count == 0)

        {

            Debug.Log("No value in OSC message");

            return;

        }
 
        if (message.Values[0].Type != OSCValueType.Int)

        {

            Debug.Log("Value in message is not an Int");

            return;

        }
 
        // Récupérer la valeur de l’angle depuis le message OSC

        int value = message.Values[0].IntValue;
 
        int nouveauEtat = value; // REMPLACER ici les ... par le code qui récupère la nouvelle donnée du flux
 
            if (nouveauEtat == 1)

            {

                // METTRE ici le code exécuté lorsque le bouton est appuyé
                FlipSwitch1 = true;
            }

            else

            {

                // METTRE ici le code exécuté lorsque le bouton est relâché

                FlipSwitch1 = false;

            }

        
    }

    void TraiterOscFlipSwitch2(OSCMessage message)

    {

        // Si le message n'a pas d'argument ou l'argument n'est pas un Int on l'ignore

        if (message.Values.Count == 0)

        {

            Debug.Log("No value in OSC message");

            return;

        }
 
        if (message.Values[0].Type != OSCValueType.Int)

        {

            Debug.Log("Value in message is not an Int");

            return;

        }
 
        // Récupérer la valeur de l’angle depuis le message OSC

        int value = message.Values[0].IntValue;
 
        int nouveauEtat = value; // REMPLACER ici les ... par le code qui récupère la nouvelle donnée du flux
 
            if (nouveauEtat == 1)

            {

                // METTRE ici le code exécuté lorsque le bouton est appuyé
                FlipSwitch2 = true;

            }

            else

            {

                // METTRE ici le code exécuté lorsque le bouton est relâché

                FlipSwitch2 = false;

            }

        
    }

    void TraiterOscFlipSwitch3(OSCMessage message)

    {

        // Si le message n'a pas d'argument ou l'argument n'est pas un Int on l'ignore

        if (message.Values.Count == 0)

        {

            Debug.Log("No value in OSC message");

            return;

        }
 
        if (message.Values[0].Type != OSCValueType.Int)

        {

            Debug.Log("Value in message is not an Int");

            return;

        }
 
        // Récupérer la valeur de l’angle depuis le message OSC

        int value = message.Values[0].IntValue;
 
        int nouveauEtat = value; // REMPLACER ici les ... par le code qui récupère la nouvelle donnée du flux

            if (nouveauEtat == 1)

            {

                // METTRE ici le code exécuté lorsque le bouton est appuyé
                FlipSwitch3 = true;

            }

            else

            {

                // METTRE ici le code exécuté lorsque le bouton est relâché

                FlipSwitch3 = false;

            }

    }

    void TraiterOscRecharge(OSCMessage message)

    {

        // Si le message n'a pas d'argument ou l'argument n'est pas un Int on l'ignore

        if (message.Values.Count == 0)

        {

            Debug.Log("No value in OSC message");

            return;

        }
 
        if (message.Values[0].Type != OSCValueType.Int)

        {

            Debug.Log("Value in message is not an Int");

            return;

        }
 
        // Récupérer la valeur de l’angle depuis le message OSC

        int value = message.Values[0].IntValue;
 
        if (value == 1)

            {
                TurningButton2 = true;
            }
            
            else

            {

                // METTRE ici le code exécuté lorsque le bouton est relâché

                TurningButton2 = false;

            }
    }

    void TraiterOscRefroidissement(OSCMessage message)

    {

        // Si le message n'a pas d'argument ou l'argument n'est pas un Int on l'ignore

        if (message.Values.Count == 0)

        {

            Debug.Log("No value in OSC message");

            return;

        }
 
        if (message.Values[0].Type != OSCValueType.Int)

        {

            Debug.Log("Value in message is not an Int");

            return;

        }
 
        // Récupérer la valeur de l’angle depuis le message OSC

        int value = message.Values[0].IntValue;
 
        if (value == 1)

            {
                TurningButton3 = true;
            }
            
            else

            {

                // METTRE ici le code exécuté lorsque le bouton est relâché

                TurningButton3 = false;

            }
    }

    void TraiterOscDrift(OSCMessage message)

    {

        // Si le message n'a pas d'argument ou l'argument n'est pas un Int on l'ignore

        if (message.Values.Count == 0)

        {

            Debug.Log("No value in OSC message");

            return;

        }
 
        if (message.Values[0].Type != OSCValueType.Int)

        {

            Debug.Log("Value in message is not an Int");

            return;

        }
 
        // Récupérer la valeur de l’angle depuis le message OSC

        int value = message.Values[0].IntValue;
 
        if (value == 1)

            {
                TurningButton1 = true;
            }
            
            else

            {

                // METTRE ici le code exécuté lorsque le bouton est relâché

                TurningButton1 = false;

            }
    }

    void TraiterOscRepair1(OSCMessage message)

    {

        // Si le message n'a pas d'argument ou l'argument n'est pas un Int on l'ignore

        if (message.Values.Count == 0)

        {

            Debug.Log("No value in OSC message");

            return;

        }
 
        if (message.Values[0].Type != OSCValueType.Int)

        {

            Debug.Log("Value in message is not an Int");

            return;

        }
 
        // Récupérer la valeur de l’angle depuis le message OSC

        int value = message.Values[0].IntValue;
 
        if (value == 1)

            {
                Button4 = true;
            }
            
            else

            {

                // METTRE ici le code exécuté lorsque le bouton est relâché

                Button4 = false;

            }
    }

    void TraiterOscRepair2(OSCMessage message)

    {

        // Si le message n'a pas d'argument ou l'argument n'est pas un Int on l'ignore

        if (message.Values.Count == 0)

        {

            Debug.Log("No value in OSC message");

            return;

        }
 
        if (message.Values[0].Type != OSCValueType.Int)

        {

            Debug.Log("Value in message is not an Int");

            return;

        }
 
        // Récupérer la valeur de l’angle depuis le message OSC

        int value = message.Values[0].IntValue;
 
        if (value == 1)

            {
                Button5 = true;
            }
            
            else

            {

                // METTRE ici le code exécuté lorsque le bouton est relâché

                Button5 = false;

            }
    }

    void TraiterOscRepair3(OSCMessage message)

    {

        // Si le message n'a pas d'argument ou l'argument n'est pas un Int on l'ignore

        if (message.Values.Count == 0)

        {

            Debug.Log("No value in OSC message");

            return;

        }
 
        if (message.Values[0].Type != OSCValueType.Int)

        {

            Debug.Log("Value in message is not an Int");

            return;

        }
 
        // Récupérer la valeur de l’angle depuis le message OSC

        int value = message.Values[0].IntValue;
 
        if (value == 1)

            {
                Button6 = true;
            }
            
            else

            {

                // METTRE ici le code exécuté lorsque le bouton est relâché

                Button6 = false;

            }
    }
 
 
    // Update is called once per frame

    void Update()

    {

        // ACTIVATION DES BOUTONS

        // BOUTON 1 -- BOUCLIERS

    //    if (Input.GetKey(KeyCode.Alpha1))
//
    //{
//
    //    Button1 = true;
//
    //} else
//
    //    {
//
    //        Button1 = false;
//
    //    }

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

    } else

        {

            TurningButton1 = false;

        }


        // TURNING BUTTON 2 -- RECHARGEMENT D'ÉNERGIE

    //    if (Input.GetKey(KeyCode.Alpha8))
//
    //{
//
    //    TurningButton2 = true;
//
    //    Debug.Log(TurningButton1);
//
    //} else
//
    //    {
//
    //        TurningButton2 = false;
//
    //    }


        // TURNING BUTTON 3 -- REFROIDISSEMENT MOTEUR

    //    if (Input.GetKey(KeyCode.Alpha9))
//
    //{
//
    //    TurningButton3 = true;
//
    //    Debug.Log(TurningButton1);
//
    //} else
//
    //    {
//
    //        TurningButton3 = false;
//
    //    }


        //if (Input.GetKeyDown(KeyCode.I) && !FlipSwitch1)
//
        //{
//
        //    FlipSwitch1 = true;
//
        //    Debug.Log("active switch 1");
//
        //} else if (Input.GetKeyDown(KeyCode.I) && FlipSwitch1){
//
        //    FlipSwitch1 = false;
//
        //    Debug.Log("inactive switch 1");
//
        //}
//
        //if (Input.GetKeyDown(KeyCode.O) && !FlipSwitch2)
//
        //{
//
        //    FlipSwitch2 = true;
//
        //    Debug.Log("active switch 2");
//
        //} else if (Input.GetKeyDown(KeyCode.O) && FlipSwitch2){
//
        //    FlipSwitch2 = false;
//
        //    Debug.Log("inactive switch 2");
//
        //}
//
        //if (Input.GetKeyDown(KeyCode.P) && !FlipSwitch3)
//
        //{
//
        //    FlipSwitch3 = true;
//
        //    Debug.Log("active switch 3");
//
        //} else if (Input.GetKeyDown(KeyCode.P) && FlipSwitch3){
//
        //    FlipSwitch3 = false;
//
        //    Debug.Log("inactive switch 3");
//
        //}


    }


}
 