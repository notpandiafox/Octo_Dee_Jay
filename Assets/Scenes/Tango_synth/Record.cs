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
    public int bpm;
    public Vector3 myPosition;
    public ArmLeft armLeft;
    public ArmRight armRight;
    private bool isRightHanded = false;

    void Start()
    { 
        myPosition = transform.position;
        armLeft.transform.parent.transform.position = myPosition;
    }

    void Update()
    {
        if (Input.GetKeyDown(scrubBack))
        {
            song.time = (song.time - timePassing);
            scratch.Play();
            
            if(isRightHanded)
                armLeft.scratchAnimation.Play();
            else
                armRight.scratchAnimation.Play();
            
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
