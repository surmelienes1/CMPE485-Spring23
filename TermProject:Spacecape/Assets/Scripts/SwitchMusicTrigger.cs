using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMusicTrigger : MonoBehaviour
{

    public AudioClip newTrack;

    private AudioManager theAM;

    // Start is called before the first frame update
    void Start()
    {

        theAM = FindObjectOfType<AudioManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("myPlayer"))
        {
            if(newTrack != null)
            {
                theAM.ChangeBGM(newTrack);
            }
        }
    }

}
