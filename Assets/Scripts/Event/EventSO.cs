using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Event", menuName = "Event")]
public class EventSO : ScriptableObject
{
    public string eventName;
    public string description;
    public Canvas environnement;
    public float cost;
    public float frustBaisse;
    public float frustAugment;
    public AudioClip soundTrack;
}
