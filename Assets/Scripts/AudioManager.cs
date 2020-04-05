using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    //this script was written by syed usman arif on 1st april 2020

    public Sound[] sounds; //reference to the class 'sound', this is an array - meaning that muliple audio clips can be added with options of volume and pitch
    public static AudioManager instance;


    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds) //iterate through each element in the sounds array
        {
            // code below assings the audio source and their volume and pitch properties
            s.source = gameObject.AddComponent<AudioSource>();   
            s.source.clip = s.clip;


            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
        
    }

    void Start()
    {
        FindObjectOfType<AudioManager>().Play("scanqr"); //on start of this scene play the welcome sound
    }

    public void Play(string name) //public method to play the sounds with the name of the audio clip as parameter
    {
        Sound s = Array.Find(sounds, sound => sound.name == name); //find the sound with the name that is matching with the sounds available in the sounds array
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play(); //plays the founded sound
    }
}
