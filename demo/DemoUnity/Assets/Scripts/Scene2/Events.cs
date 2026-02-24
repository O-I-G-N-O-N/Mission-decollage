using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Events : MonoBehaviour
{

    public bool DialogueOccuring = false;
    

    [Header("Event State")]
    public bool EventOccuring = false;
    public int DamageAmount = 0;
    public bool RepairInProgress = false;
    public bool EngineRepairHalf = false;

    private int ButtonPicker = 0;
    private int EventPicker = 0;
    public int sequenceLength = 5;
    private Queue<IEnumerator> repairQueue = new Queue<IEnumerator>();

    [Header("References")]
    public FirstPersRocket FirstPersRocket;
    public Controllers Controllers;
    public CockpitTablet CockpitTablet;
    public TextMeshProUGUI DialogueUI;
    public GameObject DialogueBox;
    private Image dialogueBoxImage;

    [Header("Audio")]
    public AudioSource EngineBreakAudioSource;
    public AudioSource EngineRightBreakAudioSource;
    public AudioSource EngineLeftBreakAudioSource; 

    // Start is called before the first frame update
    void Start()
    {
        EventPicker = Random.Range(0, 5);
        dialogueBoxImage = DialogueBox.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        // Démarre un nouvel event si aucun en cours
        if (!EventOccuring && DamageAmount < 4)
        {
            StartCoroutine(EventHappening());
            EventOccuring = true;
        }

        if (DialogueOccuring) {
            DialogueBox.gameObject.SetActive(true);
        } else {
            DialogueBox.gameObject.SetActive(false);
        }
    }


    IEnumerator EventHappening()
    {
        yield return new WaitForSeconds(25f);
        Debug.Log("5 secondes passées, check event...");

        EventPicker = Random.Range(0, 5);

            if (EventPicker == 0 && !FirstPersRocket.DamagedMainReactor)
        {
            EventOccuring = false;
            DialogueOccuring = true;
            DamageAmount += 1;
            CockpitTablet.RocketDamagedMain.SetActive(true);
            FirstPersRocket.DamagedMainReactor = true;
            // JAD mettre ici le son de moteur qui brise
            if (EngineBreakAudioSource != null)
                EngineBreakAudioSource.Play();
            Controllers.MainSlider.value = 0;
            repairQueue.Enqueue(RepairMain());
            if (!RepairInProgress)
            {
                StartCoroutine(RepairSequence());
            }
        }
        else if (EventPicker == 1 && !FirstPersRocket.DamagedRightReactor)
        {
            EventOccuring = false;
            DialogueOccuring = true;
            DamageAmount += 1;
            CockpitTablet.RocketDamagedRight.SetActive(true);
            FirstPersRocket.DamagedRightReactor = true;
            // JAD mettre ici le son de moteur qui brise
            if (EngineRightBreakAudioSource != null)
                EngineRightBreakAudioSource.Play();
            Controllers.RightSlider.value = 0;
            repairQueue.Enqueue(RepairRight());
            if (!RepairInProgress)
            {
                StartCoroutine(RepairSequence());
            }
        }
        else if (EventPicker == 2 && !FirstPersRocket.DamagedLeftReactor)
        {
            EventOccuring = false;
            DialogueOccuring = true;
            DamageAmount += 1;
            CockpitTablet.RocketDamagedLeft.SetActive(true);
            FirstPersRocket.DamagedLeftReactor = true;
            // JAD mettre ici le son de moteur qui brise
            if (EngineLeftBreakAudioSource != null)
                EngineLeftBreakAudioSource.Play();
            Controllers.LeftSlider.value = 0;
            repairQueue.Enqueue(RepairLeft());
                if (!RepairInProgress)
            {
                StartCoroutine(RepairSequence());
            }
        } else if (EventPicker == 3) 
        {
            EventOccuring = false;
            DialogueOccuring = true;
            DamageAmount += 1;
            CockpitTablet.RocketDamagedEngine.SetActive(true);
            FirstPersRocket.DamagedEngine = true;
            Controllers.LeftSlider.value = 0;
            Controllers.RightSlider.value = 0;
            Controllers.MainSlider.value = 0;
            repairQueue.Enqueue(RepairEngine());
                if (!RepairInProgress)
            {
                StartCoroutine(RepairSequence());
            }
        }
        else
        {
            EventOccuring = false;
        }
        
    }


        IEnumerator RepairSequence()
    {
        if (RepairInProgress) yield break;

    while (repairQueue.Count > 0)
    {
        RepairInProgress = true;

        yield return StartCoroutine(repairQueue.Dequeue());

        RepairInProgress = false;
        DialogueOccuring = false;
    }
    }


    // --- Séquences de réparation ---
    IEnumerator RepairMain()
    {
    //DÉBUTE LA SÉQUENCE
    DialogueOccuring = true;
    Debug.Log("Dégâts: " + DamageAmount);
    DialogueUI.text = "MALFONCTION DU PROPULSEUR PRINCIPAL. ACTION REQUISE";
    yield return new WaitForSeconds(1f);
    sequenceLength = Random.Range(3, 10);

    // LOOP À TRAVERS LES BOUTONS ALÉATOIRE QUE L'USER VA DEVOIR APPUYER
    for (int i = 0; i < sequenceLength; i++)
    {
        yield return new WaitForSeconds(0.2f);
        dialogueBoxImage.color = new Color(1f, 1f, 1f);
        ButtonPicker = Random.Range(0, 3);

        int correctButton = -1; 

        switch (ButtonPicker)
        {
            case 0: 
                DialogueUI.text = "Appuyez sur le bouton vert!";
                correctButton = 4;
                break;
            case 1: 
                DialogueUI.text = "Appuyez sur le bouton rouge!";
                correctButton = 5;
                break;
            case 2: 
                DialogueUI.text = "Appuyez sur le bouton bleu!";
                correctButton = 6;
                break;
        }

        // Wait until the correct button is pressed or the wrong button is pressed
        bool correctInput = false;

        // Tant que correctInput est faux, ce code roule
        while (!correctInput)
        {
            if (correctButton == 4 && Controllers.Button4) correctInput = true;
            else if (correctButton == 5 && Controllers.Button5) correctInput = true;
            else if (correctButton == 6 && Controllers.Button6) correctInput = true;

            // Check for wrong input (If any other button is pressed, handle it)
            if ((correctButton != 4 && Controllers.Button4) || 
                (correctButton != 5 && Controllers.Button5) || 
                (correctButton != 6 && Controllers.Button6))
            {
                // Handle wrong input (show message, etc.)
                dialogueBoxImage.color = new Color(1f, 0f, 0f);
                DialogueUI.text = "Mauvais bouton ! Récupération des données en cours...";
                yield return new WaitForSeconds(2f); // Add a short delay for the error message
                break; // Break out of the current button press loop and move to the next sequence
            }

            yield return null; // Wait for the next frame to check again
        }

        // COULEUR DE LA BOITE DE DIALOGUE
        dialogueBoxImage.color = new Color(0f, 1f, 0f);
        Debug.Log("Dégâts: " + DamageAmount);
    }

    // Final message after the repair sequence
    dialogueBoxImage.color = new Color(1f, 1f, 1f);
    DialogueUI.text = "Restabilisation du propulseur principal réussie !";
    FirstPersRocket.DamagedMainReactor = false;
    DamageAmount -= 1;
    CockpitTablet.RocketDamagedMain.SetActive(false);

    yield return new WaitForSeconds(1f);
}

    IEnumerator RepairRight()
    {
    //DÉBUTE LA SÉQUENCE
    DialogueOccuring = true;
    Debug.Log("Dégâts: " + DamageAmount);
    DialogueUI.text = "MALFONCTION DU PROPULSEUR DROIT. ACTION REQUISE";
    yield return new WaitForSeconds(1f);
    sequenceLength = Random.Range(3, 10);

    // LOOP À TRAVERS LES BOUTONS ALÉATOIRE QUE L'USER VA DEVOIR APPUYER
    for (int i = 0; i < sequenceLength; i++)
    {
        yield return new WaitForSeconds(0.2f);
        dialogueBoxImage.color = new Color(1f, 1f, 1f);
        ButtonPicker = Random.Range(0, 3);

        int correctButton = -1; 

        switch (ButtonPicker)
        {
            case 0: 
                DialogueUI.text = "Appuyez sur le bouton vert!";
                correctButton = 4;
                break;
            case 1: 
                DialogueUI.text = "Appuyez sur le bouton rouge!";
                correctButton = 5;
                break;
            case 2: 
                DialogueUI.text = "Appuyez sur le bouton bleu!";
                correctButton = 6;
                break;
        }

        // Wait until the correct button is pressed or the wrong button is pressed
        bool correctInput = false;

        // Tant que correctInput est faux, ce code roule
        while (!correctInput)
        {
            if (correctButton == 4 && Controllers.Button4) correctInput = true;
            else if (correctButton == 5 && Controllers.Button5) correctInput = true;
            else if (correctButton == 6 && Controllers.Button6) correctInput = true;

            // Check for wrong input (If any other button is pressed, handle it)
            if ((correctButton != 4 && Controllers.Button4) || 
                (correctButton != 5 && Controllers.Button5) || 
                (correctButton != 6 && Controllers.Button6))
            {
                // Handle wrong input (show message, etc.)
                dialogueBoxImage.color = new Color(1f, 0f, 0f);
                DialogueUI.text = "Mauvais bouton ! Récupération des données en cours...";
                yield return new WaitForSeconds(2f); // Add a short delay for the error message
                break; // Break out of the current button press loop and move to the next sequence
            }

            yield return null; // Wait for the next frame to check again
        }

        // COULEUR DE LA BOITE DE DIALOGUE
        dialogueBoxImage.color = new Color(0f, 1f, 0f);
        Debug.Log("Dégâts: " + DamageAmount);
    }

    // Final message after the repair sequence
    dialogueBoxImage.color = new Color(1f, 1f, 1f);
    DialogueUI.text = "Restabilisation du propulseur droit réussie !";
    FirstPersRocket.DamagedRightReactor = false;
    DamageAmount -= 1;
    CockpitTablet.RocketDamagedRight.SetActive(false);

    yield return new WaitForSeconds(1f);
}

    IEnumerator RepairLeft()
{
    //DÉBUTE LA SÉQUENCE
    DialogueOccuring = true;
    Debug.Log("Dégâts: " + DamageAmount);
    DialogueUI.text = "MALFONCTION DU PROPULSEUR GAUCHE. ACTION REQUISE";
    yield return new WaitForSeconds(1f);
    sequenceLength = Random.Range(3, 10);

    // LOOP À TRAVERS LES BOUTONS ALÉATOIRE QUE L'USER VA DEVOIR APPUYER
    for (int i = 0; i < sequenceLength; i++)
    {
        yield return new WaitForSeconds(0.2f);
        dialogueBoxImage.color = new Color(1f, 1f, 1f);
        ButtonPicker = Random.Range(0, 3);

        int correctButton = -1; 

        switch (ButtonPicker)
        {
            case 0: 
                DialogueUI.text = "Appuyez sur le bouton vert!";
                correctButton = 4;
                break;
            case 1: 
                DialogueUI.text = "Appuyez sur le bouton rouge!";
                correctButton = 5;
                break;
            case 2: 
                DialogueUI.text = "Appuyez sur le bouton bleu!";
                correctButton = 6;
                break;
        }

        // Wait until the correct button is pressed or the wrong button is pressed
        bool correctInput = false;

        // Tant que correctInput est faux, ce code roule
        while (!correctInput)
        {
            if (correctButton == 4 && Controllers.Button4) correctInput = true;
            else if (correctButton == 5 && Controllers.Button5) correctInput = true;
            else if (correctButton == 6 && Controllers.Button6) correctInput = true;

            // Check for wrong input (If any other button is pressed, handle it)
            if ((correctButton != 4 && Controllers.Button4) || 
                (correctButton != 5 && Controllers.Button5) || 
                (correctButton != 6 && Controllers.Button6))
            {
                // Handle wrong input (show message, etc.)
                dialogueBoxImage.color = new Color(1f, 0f, 0f);
                DialogueUI.text = "Mauvais bouton ! Récupération des données en cours...";
                yield return new WaitForSeconds(2f); // Add a short delay for the error message
                break; // Break out of the current button press loop and move to the next sequence
            }

            yield return null; // Wait for the next frame to check again
        }

        // COULEUR DE LA BOITE DE DIALOGUE
        dialogueBoxImage.color = new Color(0f, 1f, 0f);
        Debug.Log("Dégâts: " + DamageAmount);
    }

    // Final message after the repair sequence
    dialogueBoxImage.color = new Color(1f, 1f, 1f);
    DialogueUI.text = "Restabilisation du propulseur gauche réussie !";
    FirstPersRocket.DamagedLeftReactor = false;
    DamageAmount -= 1;
    CockpitTablet.RocketDamagedLeft.SetActive(false);

    yield return new WaitForSeconds(1f);
}


    IEnumerator RepairEngine()
    {
        DialogueOccuring = true;
        Debug.Log("Ça part");
        DialogueUI.text = "MALFONCTION DU MOTEUR. ACTION IMMÉDIATE REQUISE";
        DialogueUI.text = "DÉSACTIVEZ LES PROPULSEURS ET REMETTEZ LES À ZÉRO";
        while (FirstPersRocket.DamagedEngine) 
        {
            if (!Controllers.FlipSwitch1 && !Controllers.FlipSwitch3 && Controllers.MainSlider.value == 0 && Controllers.RightSlider.value == 0 && Controllers.LeftSlider.value == 0) 
                {
                    EngineRepairHalf = true;
                    DialogueUI.text = "RÉACTIVEZ LES PROPULSEURS";
                }

            if (Controllers.FlipSwitch1 && Controllers.FlipSwitch3 && EngineRepairHalf)
                {
                    FirstPersRocket.DamagedEngine = false;
                    FirstPersRocket.DamagedLeftReactor = false;
                    FirstPersRocket.DamagedMainReactor = false;
                    FirstPersRocket.DamagedRightReactor = false;
                }
        yield return null;
        }

        DialogueUI.text = "RÉACTIVATION DU MOTEUR RÉUSSIE !";
        EngineRepairHalf = false;
        DamageAmount -= 1;
        CockpitTablet.RocketDamagedEngine.SetActive(false);
        yield return new WaitForSeconds(1f);
    }
}
