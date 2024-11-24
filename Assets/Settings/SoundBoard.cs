using System.Collections.Generic;
using UnityEngine;

public class SoundBoard
{
    private Dictionary<KeyCode, Button> m_Buttons;
    public SoundBoard(Dictionary<KeyCode, Button> buttons) {
        m_Buttons = buttons;
    }
    public void triggerButton(KeyCode key) {
        if (m_Buttons.ContainsKey(key)) {
            m_Buttons[key].playEffect();
        }
    }
    public void freeButton(KeyCode key) {
        if (m_Buttons.ContainsKey(key)) {
            m_Buttons[key].free();
        }
    }
}
