using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Event", menuName = "Event")]
public class EventSO : ScriptableObject
{
    public string eventName;
    public string description;
    public Sprite environnement;
    public float cost;
    public float frustBaisse;
    public float frustAugment;
    public float timer;
    public AudioClip soundTrack;
}
