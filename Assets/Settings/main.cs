using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class main : MonoBehaviour
{
    private GameObject m_GameObject;
    private AudioSource m_AudioSource;
    private AudioClip m_AudioClip;

    private SoundBoard m_SoundBoard;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_GameObject = new GameObject("m_Game Object");
        m_GameObject.AddComponent<AudioSource>();
        m_AudioSource = m_GameObject.GetComponent<AudioSource>();
        m_AudioClip = Resources.Load<AudioClip>("audio/MAIN THEME");

        m_AudioSource.loop = true;
        m_AudioSource.clip = m_AudioClip;
        m_AudioSource.Play();

        Dictionary<KeyCode, Button> buttons = new Dictionary<KeyCode, Button>();

        Button U_Button = m_GameObject.AddComponent<Button>();
        U_Button.initialize(
            GameObject.FindGameObjectWithTag("U_BUTTON"),
            Resources.Load<Sprite>("sprites/buttons/U_ON"),
            Resources.Load<Sprite>("sprites/buttons/U_OFF"),
            Resources.Load<AudioClip>("audio/HI-HAT")
        );
        buttons.Add(KeyCode.U, U_Button);

        Button I_Button = m_GameObject.AddComponent<Button>();
        I_Button.initialize(
            GameObject.FindGameObjectWithTag("I_BUTTON"),
            Resources.Load<Sprite>("sprites/buttons/I_ON"),
            Resources.Load<Sprite>("sprites/buttons/I_OFF"),
            Resources.Load<AudioClip>("audio/SNARE")
        );
        buttons.Add(KeyCode.I, I_Button);

        Button O_Button = m_GameObject.AddComponent<Button>();
        O_Button.initialize(
            GameObject.FindGameObjectWithTag("O_BUTTON"),
            Resources.Load<Sprite>("sprites/buttons/O_ON"),
            Resources.Load<Sprite>("sprites/buttons/O_OFF"),
            Resources.Load<AudioClip>("audio/HI-HAT-OPEN")
        );
        buttons.Add(KeyCode.O, O_Button);

        Button J_Button = m_GameObject.AddComponent<Button>();
        J_Button.initialize(
            GameObject.FindGameObjectWithTag("J_BUTTON"),
            Resources.Load<Sprite>("sprites/buttons/J_ON"),
            Resources.Load<Sprite>("sprites/buttons/J_OFF"),
            Resources.Load<AudioClip>("audio/RIM")
        );
        buttons.Add(KeyCode.J, J_Button);

        Button K_Button = m_GameObject.AddComponent<Button>();
        K_Button.initialize(
            GameObject.FindGameObjectWithTag("K_BUTTON"),
            Resources.Load<Sprite>("sprites/buttons/K_ON"),
            Resources.Load<Sprite>("sprites/buttons/K_OFF"),
            Resources.Load<AudioClip>("audio/KICK")
        );
        buttons.Add(KeyCode.K, K_Button);

        Button L_Button = m_GameObject.AddComponent<Button>();
        L_Button.initialize(
            GameObject.FindGameObjectWithTag("L_BUTTON"),
            Resources.Load<Sprite>("sprites/buttons/L_ON"),
            Resources.Load<Sprite>("sprites/buttons/L_OFF"),
            Resources.Load<AudioClip>("audio/CLAP")
        );
        buttons.Add(KeyCode.L, L_Button);

        Button T_Button = m_GameObject.AddComponent<Button>();
        T_Button.initialize(
            GameObject.FindGameObjectWithTag("T_BUTTON"),
            Resources.Load<Sprite>("sprites/buttons/T_ON"),
            Resources.Load<Sprite>("sprites/buttons/T_OFF"),
            Resources.Load<AudioClip>("audio/CLAP")
        );
        buttons.Add(KeyCode.T, T_Button);
        
        Button R_Button = m_GameObject.AddComponent<Button>();
        R_Button.initialize(
            GameObject.FindGameObjectWithTag("R_BUTTON"),
            Resources.Load<Sprite>("sprites/buttons/R_ON"),
            Resources.Load<Sprite>("sprites/buttons/R_OFF"),
            Resources.Load<AudioClip>("audio/CLAP")
        );
        buttons.Add(KeyCode.R, R_Button);

        m_SoundBoard = new SoundBoard(buttons);
    }
    void OnGUI() {
        Event currentEvent = Event.current;
        if (currentEvent.isKey) {
            if (currentEvent.keyCode == KeyCode.U || 
                currentEvent.keyCode == KeyCode.I ||
                currentEvent.keyCode == KeyCode.O ||
                currentEvent.keyCode == KeyCode.J ||
                currentEvent.keyCode == KeyCode.K ||
                currentEvent.keyCode == KeyCode.L ||
                currentEvent.keyCode == KeyCode.R ||
                currentEvent.keyCode == KeyCode.T
                ) {
                    m_SoundBoard.triggerButton(currentEvent.keyCode);
                    StartCoroutine(addDelay(currentEvent.keyCode));
            } 
        }
    }
    public IEnumerator addDelay(KeyCode key) {
        yield return new WaitForSecondsRealtime(0.2f);
        m_SoundBoard.freeButton(key);
    }
    void Update()
    {
    }
}