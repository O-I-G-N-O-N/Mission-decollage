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

    private int ButtonPicker = 0;
    private int EventPicker = 0;
    public int sequenceLength = 5;

    [Header("References")]
    public FirstPersRocket FirstPersRocket;
    public Controllers Controllers;
    public TextMeshProUGUI DialogueUI;
    public GameObject DialogueBox;
    private Image dialogueBoxImage;

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
        if (!EventOccuring)
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
        yield return new WaitForSeconds(20f);
        Debug.Log("5 secondes passées, check event...");

        EventPicker = Random.Range(0, 5);

        if (EventPicker == 0)
        {
            DialogueOccuring = true;
            DialogueUI.text = "MALFONCTION DU PROPULSEUR PRINCIPAL. ACTION REQUISE";
            FirstPersRocket.DamagedMainReactor = true;
            Controllers.MainSlider.value = 0;
            StartCoroutine(RepairMain());
        }
        else if (EventPicker == 1)
        {
            DialogueOccuring = true;
            DialogueUI.text = "MALFONCTION DU PROPULSEUR DROIT. ACTION REQUISE";
            FirstPersRocket.DamagedRightReactor = true;
            Controllers.RightSlider.value = 0;
            StartCoroutine(RepairRight());
        }
        else if (EventPicker == 2)
        {
            DialogueOccuring = true;
            DialogueUI.text = "MALFONCTION DU PROPULSEUR GAUCHE. ACTION REQUISE";
            FirstPersRocket.DamagedLeftReactor = true;
            Controllers.LeftSlider.value = 0;
            StartCoroutine(RepairLeft());
        }
        else
        {
            EventOccuring = false;
            DialogueOccuring = false;
        }

        
    }


    // --- Séquences de réparation ---
    IEnumerator RepairMain()
    {
    //DÉBUTE LA SÉQUENCE
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
                DialogueUI.text = "Appuyez sur le bouton 4!";
                correctButton = 4;
                break;
            case 1: 
                DialogueUI.text = "Appuyez sur le bouton 5!";
                correctButton = 5;
                break;
            case 2: 
                DialogueUI.text = "Appuyez sur le bouton 6!";
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
    }

    // Final message after the repair sequence
    dialogueBoxImage.color = new Color(1f, 1f, 1f);
    DialogueUI.text = "Réparation du propulseur principal réussie !";
    FirstPersRocket.DamagedMainReactor = false;

    yield return new WaitForSeconds(1f);
    DialogueOccuring = false;
    EventOccuring = false;
}

    IEnumerator RepairRight()
    {
    //DÉBUTE LA SÉQUENCE
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
                DialogueUI.text = "Appuyez sur le bouton 4!";
                correctButton = 4;
                break;
            case 1: 
                DialogueUI.text = "Appuyez sur le bouton 5!";
                correctButton = 5;
                break;
            case 2: 
                DialogueUI.text = "Appuyez sur le bouton 6!";
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
    }

    // Final message after the repair sequence
    dialogueBoxImage.color = new Color(1f, 1f, 1f);
    DialogueUI.text = "Réparation du propulseur droit réussie !";
    FirstPersRocket.DamagedRightReactor = false;

    yield return new WaitForSeconds(1f);
    DialogueOccuring = false;
    EventOccuring = false;
}

    IEnumerator RepairLeft()
{
    //DÉBUTE LA SÉQUENCE
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
                DialogueUI.text = "Appuyez sur le bouton 4!";
                correctButton = 4;
                break;
            case 1: 
                DialogueUI.text = "Appuyez sur le bouton 5!";
                correctButton = 5;
                break;
            case 2: 
                DialogueUI.text = "Appuyez sur le bouton 6!";
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
    }

    // Final message after the repair sequence
    dialogueBoxImage.color = new Color(1f, 1f, 1f);
    DialogueUI.text = "Réparation du propulseur gauche réussie !";
    FirstPersRocket.DamagedLeftReactor = false;

    yield return new WaitForSeconds(1f);
    DialogueOccuring = false;
    EventOccuring = false;
}
}
