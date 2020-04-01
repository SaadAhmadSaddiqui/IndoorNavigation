using UnityEngine.Audio;
using UnityEngine;


[System.Serializable] //done so that the custom class shows up in the unity inspector
public class Sound 
{ // code written by syed usman arif on 1st April 2020
  //this script is used to create the schema or the structure of sounds used in this project

    public string name;

    public AudioClip clip; // a container to put audio files in

    [Range(0f,5f)] public float volume;
    [Range(0.1f,3f)] public float pitch;

    [HideInInspector] public AudioSource source; //audiosource variable to store all this informatiom. hidden in inspector because we dont want to access it from outside


}
