using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public BGM musicBGM;
    // Start is called before the first frame update

    void Start()
    {
        
    }

    private void Awake()
    {
        SingletonManager.Register(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playMusic()
    {
        musicBGM.musicFile.Play();
    }
}
