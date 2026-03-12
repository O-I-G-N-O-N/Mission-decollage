using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLimits : MonoBehaviour
{

    public HeatEnergy HeatEnergy;
    public GameObject WarningDialogueBox;
    public Image WarningDialogueBoxImage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (CompareTag("WarningZone"))
        {
            StartCoroutine(Warning());
        }
                
        if (CompareTag("DeathZone"))
        {
            HeatEnergy.GameIsOver = true;
        }
    }


    IEnumerator Warning()
    {
        WarningDialogueBox.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        WarningDialogueBoxImage.color = new Color(255, 0, 0);
        yield return new WaitForSeconds(0.5f);
        WarningDialogueBoxImage.color = new Color(255, 255, 255);
        yield return new WaitForSeconds(0.5f);
        WarningDialogueBoxImage.color = new Color(255, 0, 0);
        yield return new WaitForSeconds(0.5f);
        WarningDialogueBoxImage.color = new Color(255, 255, 255);
        yield return new WaitForSeconds(0.5f);
        WarningDialogueBoxImage.color = new Color(255, 0, 0);
        yield return new WaitForSeconds(0.5f);
        WarningDialogueBoxImage.color = new Color(255, 255, 255);
        yield return new WaitForSeconds(0.5f);
        WarningDialogueBoxImage.color = new Color(255, 0, 0);
        yield return new WaitForSeconds(0.5f);
        WarningDialogueBoxImage.color = new Color(255, 255, 255);
        yield return new WaitForSeconds(0.5f);
        WarningDialogueBoxImage.color = new Color(255, 0, 0);
        yield return new WaitForSeconds(0.5f);
        WarningDialogueBoxImage.color = new Color(255, 255, 255);
        yield return new WaitForSeconds(0.5f);
        WarningDialogueBoxImage.color = new Color(255, 0, 0);
        yield return new WaitForSeconds(0.5f);
        WarningDialogueBox.SetActive(false);
        yield return null;
    }
}
