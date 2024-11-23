using System.Collections;
using System.Data;
using UnityEngine;

public class Button : MonoBehaviour
{
    private const float MOVE_DISTANCE = 3f;
    private const float MOVE_DURATION = 0.1f;
    private GameObject m_GameObject;
    private Sprite m_OnSprite;
    private Sprite m_OffSprite;
    private AudioClip m_Track;
    private AudioSource m_AudioSource;

    public Button(GameObject buttonObject, Sprite onSprite, Sprite offSprite, AudioClip track) {
        m_GameObject = buttonObject;

        m_AudioSource = new AudioSource();
        m_AudioSource.clip = track;

        m_OnSprite = onSprite;
        m_OffSprite = offSprite;
    }

    public IEnumerator playDownAnimation() {
        m_GameObject.transform.position = new Vector3(
            m_GameObject.transform.position.x,
            m_GameObject.transform.position.y - MOVE_DISTANCE
        );
        m_GameObject.GetComponent<SpriteRenderer>().sprite = m_OnSprite;
        yield return new WaitForSeconds(MOVE_DURATION);
    }
    public void playEffect() {
        m_AudioSource.Play();
        StartCoroutine(playDownAnimation());
        m_GameObject.transform.position = new Vector3(
            m_GameObject.transform.position.x,
            m_GameObject.transform.position.y + MOVE_DISTANCE
        );
        m_GameObject.GetComponent<SpriteRenderer>().sprite = m_OffSprite;
    } 
}
