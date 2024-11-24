using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.UIElements;

public class Record : MonoBehaviour
{
    private const float timePassing = 1f;
    public AudioSource song;
    public AudioSource scratch;
    public KeyCode scrubBack;
    public Vector3 myPosition;
    private bool isRightHanded = false;

    void Start()
    { 
        myPosition = transform.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(scrubBack))
        {
            song.time = (song.time - timePassing);
            scratch.Play();
            
            if(isRightHanded)                
                gameObject.GetComponent<AnimationPopUp>().PlayAnimation();
            
            
            StartCoroutine(Mute(timePassing));
        }
    }
    
    
    private IEnumerator Mute(float timePassing)
    {
        song.mute = true;
        yield return new WaitForSeconds(timePassing);
        song.mute = false;
    }
}
