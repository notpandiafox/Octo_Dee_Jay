using System.Collections;
using System.Data;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;

public class Button : MonoBehaviour
{
    private const float MOVE_DISTANCE = 0.06f;
    private const float MOVE_DURATION = 0.2f;
    private GameObject m_GameObject;
    private Sprite m_OnSprite;
    private Sprite m_OffSprite;
    private AudioClip m_Track;
    private AudioSource m_AudioSource;

    private bool m_CanPlay;

    public void initialize(GameObject buttonObject, Sprite onSprite, Sprite offSprite, AudioClip track) {
        m_GameObject = buttonObject;

        m_GameObject.AddComponent<AudioSource>();
        m_AudioSource = m_GameObject.GetComponent<AudioSource>();
        m_AudioSource.clip = track;

        m_OnSprite = onSprite;
        m_OffSprite = offSprite;

        m_CanPlay = true;
    }

    public IEnumerator playDownAnimation() {
        m_GameObject.transform.position = new Vector3(
            m_GameObject.transform.position.x,
            m_GameObject.transform.position.y - MOVE_DISTANCE
        );
        m_GameObject.GetComponent<SpriteRenderer>().sprite = m_OnSprite;
        yield return new WaitForSeconds(MOVE_DURATION);
        m_GameObject.transform.position = new Vector3(
            m_GameObject.transform.position.x,
            m_GameObject.transform.position.y + MOVE_DISTANCE
        );
        m_GameObject.GetComponent<SpriteRenderer>().sprite = m_OffSprite;
    }
    public void playEffect() {
        if (m_CanPlay) {
            m_CanPlay = false;
            m_AudioSource.Play();
            StartCoroutine(playDownAnimation());
        }
    } 
    public void free() {
        m_CanPlay = true;
    }
}
