using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour {
    private GameObject m_AudioGameObject;
    private AudioSource m_AudioSourceTheme;
    private AudioSource m_AudioSourceSoundEffect;

    public void playGame() {
        StartCoroutine(changeScene());
    }
    public IEnumerator changeScene() {
        m_AudioSourceSoundEffect.Play();
        yield return new WaitForSeconds(0.6f);
        SceneManager.LoadScene("GameScreen");
    }


    void Start() {
        m_AudioGameObject = new GameObject("m_AudioGameObject");
        m_AudioGameObject.AddComponent<AudioSource>();
        m_AudioSourceTheme = m_AudioGameObject.GetComponent<AudioSource>();
        m_AudioSourceTheme.loop = true;
        m_AudioSourceTheme.clip = Resources.Load<AudioClip>("audio/MAIN THEME");
        m_AudioSourceTheme.Play();

        m_AudioGameObject.AddComponent<AudioSource>();
        m_AudioSourceSoundEffect = m_AudioGameObject.GetComponents<AudioSource>()[1];
        m_AudioSourceSoundEffect.clip = Resources.Load<AudioClip>("audio/START BUTTON");
    }
}