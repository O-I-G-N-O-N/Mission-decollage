using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using extOSC;

public class Controllers : MonoBehaviour
{
    [Header("OSC")]
    public OSCReceiver oscReceiver;

    [Header("Scripts")]
    public HeatEnergy HeatEnergy;
    public FirstPersRocket FirstPersRocket;

    [Header("UI")]
    public GameObject minimap;
    public GameObject lightsObject; // ← OBJET LUMIERES A ACTIVER/DESACTIVER

    // ─────────────────────────────────────────────
    // États internes OSC maintenus
    // ─────────────────────────────────────────────
    private bool osc_Button1 = false;
    private bool osc_Button4 = false;
    private bool osc_Button5 = false;
    private bool osc_Button6 = false;
    private bool osc_TurningButton1 = false;
    private bool osc_TurningButton2 = false;
    private bool osc_TurningButton3 = false;

    private bool lock_Switch1 = false;
    private bool lock_Switch2 = false;
    private bool lock_Switch3 = false;

    // ─────────────────────────────────────────────
    // États publics
    // ─────────────────────────────────────────────
    [Header("Boutons")]
    public bool Button1 = false;
    public bool Button2 = false; // LUMIERES (état direct)
    public bool Button3 = false; // RADAR (état direct)
    public bool Button4 = false;
    public bool Button5 = false;
    public bool Button6 = false;

    [Header("Boutons rotatifs")]
    public bool TurningButton1 = false;
    public bool TurningButton2 = false;
    public bool TurningButton3 = false;

    [Header("Switchs")]
    public bool FlipSwitch1 = false;
    public bool FlipSwitch2 = false;
    public bool FlipSwitch3 = false;

    [Header("Sliders")]
    public Slider RightSlider;
    public Slider MainSlider;
    public Slider LeftSlider;

    // ─────────────────────────────────────────────
    // START
    // ─────────────────────────────────────────────
    void Start()
    {
        if (oscReceiver == null)
        {
            Debug.LogError("[Controllers] OSCReceiver non assigné !");
            return;
        }

        // ── DEVICE 1 ─────────────────────────────

        oscReceiver.Bind("/device1/input1", msg =>
        {
            osc_Button1 = ReadBool(msg);
        });

        // LUMIERES – ETAT DIRECT 0/1
        oscReceiver.Bind("/device1/input2", TraiterOscLumieres);

        oscReceiver.Bind("/device1/input3", msg =>
        {
            bool pressed = ReadBool(msg);
            if (pressed && !lock_Switch1)
            {
                FlipSwitch1 = !FlipSwitch1;
                lock_Switch1 = true;
            }
            else if (!pressed)
            {
                lock_Switch1 = false;
            }
        });

        oscReceiver.Bind("/device1/input4", msg =>
        {
            osc_TurningButton1 = ReadBool(msg);
        });

        // ── DEVICE 2 ─────────────────────────────

        // RADAR – ETAT DIRECT 0/1
        oscReceiver.Bind("/device2/input1", TraiterOscRadar);

        oscReceiver.Bind("/device2/input2", msg =>
        {
            osc_Button4 = ReadBool(msg);
        });

        oscReceiver.Bind("/device2/input3", msg =>
        {
            bool pressed = ReadBool(msg);
            if (pressed && !lock_Switch2)
            {
                FlipSwitch2 = !FlipSwitch2;
                lock_Switch2 = true;
            }
            else if (!pressed)
            {
                lock_Switch2 = false;
            }
        });

        oscReceiver.Bind("/device2/input4", msg =>
        {
            osc_TurningButton2 = ReadBool(msg);
        });

        // ── DEVICE 3 ─────────────────────────────

        oscReceiver.Bind("/device3/input1", msg =>
        {
            osc_Button5 = ReadBool(msg);
        });

        oscReceiver.Bind("/device3/input2", msg =>
        {
            osc_Button6 = ReadBool(msg);
        });

        oscReceiver.Bind("/device3/input3", msg =>
        {
            bool pressed = ReadBool(msg);
            if (pressed && !lock_Switch3)
            {
                FlipSwitch3 = !FlipSwitch3;
                lock_Switch3 = true;
            }
            else if (!pressed)
            {
                lock_Switch3 = false;
            }
        });

        oscReceiver.Bind("/device3/input4", msg =>
        {
            osc_TurningButton3 = ReadBool(msg);
        });
    }

    // ─────────────────────────────────────────────
    // UPDATE (CLAVIER = ETAT DIRECT)
    // ─────────────────────────────────────────────
    void Update()
    {
        Button1 = Input.GetKey(KeyCode.Alpha1) || osc_Button1;
        Button4 = Input.GetKey(KeyCode.Alpha4) || osc_Button4;
        Button5 = Input.GetKey(KeyCode.Alpha5) || osc_Button5;
        Button6 = Input.GetKey(KeyCode.Alpha6) || osc_Button6;

        TurningButton1 = Input.GetKey(KeyCode.Alpha7) || osc_TurningButton1;
        TurningButton2 = Input.GetKey(KeyCode.Alpha8) || osc_TurningButton2;
        TurningButton3 = Input.GetKey(KeyCode.Alpha9) || osc_TurningButton3;

        // LUMIERES clavier (maintenu)
        if (Input.GetKey(KeyCode.Alpha2))
        {
            Button2 = true;
            if (lightsObject != null)
                lightsObject.SetActive(true);
        }
        else
        {
            Button2 = false;
            if (lightsObject != null)
                lightsObject.SetActive(false);
        }

        // RADAR clavier (maintenu)
        if (Input.GetKey(KeyCode.Alpha3))
        {
            Button3 = true;
            if (minimap != null)
                minimap.SetActive(true);
        }
        else
        {
            Button3 = false;
            if (minimap != null)
                minimap.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.I)) FlipSwitch1 = !FlipSwitch1;
        if (Input.GetKeyDown(KeyCode.O)) FlipSwitch2 = !FlipSwitch2;
        if (Input.GetKeyDown(KeyCode.P)) FlipSwitch3 = !FlipSwitch3;
    }

    // ─────────────────────────────────────────────
    // OSC RADAR
    // ─────────────────────────────────────────────
    void TraiterOscRadar(OSCMessage message)
    {
        if (!IsValidInt(message)) return;

        int valeur = message.Values[0].IntValue;

        Button3 = valeur == 1;

        if (minimap != null)
            minimap.SetActive(Button3);
    }

    // ─────────────────────────────────────────────
    // OSC LUMIERES
    // ─────────────────────────────────────────────
    void TraiterOscLumieres(OSCMessage message)
    {
        if (!IsValidInt(message)) return;

        int valeur = message.Values[0].IntValue;

        Button2 = valeur == 1;

        if (lightsObject != null)
            lightsObject.SetActive(Button2);
    }

    // ─────────────────────────────────────────────
    // HELPERS
    // ─────────────────────────────────────────────
    private bool ReadBool(OSCMessage message)
    {
        if (message.Values == null || message.Values.Count == 0) return false;

        var val = message.Values[0];

        if (val.Type == OSCValueType.Int)
            return val.IntValue != 0;

        if (val.Type == OSCValueType.Float)
            return val.FloatValue > 0.5f;

        return false;
    }

    private bool IsValidInt(OSCMessage message)
    {
        if (message.Values.Count == 0) return false;
        if (message.Values[0].Type != OSCValueType.Int) return false;
        return true;
    }
}