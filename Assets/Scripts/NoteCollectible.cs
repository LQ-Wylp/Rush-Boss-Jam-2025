using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NoteCollectible : MonoBehaviour
{
    // Variable pour jouer un son ou déclencher un événement à la collecte
    public AudioClip collectSound;
    public GameObject visuel;
    public GameObject visuel2D;

    [Header("Effects")]
    public UnityEvent unityEvent;
    public GameObject bullet;
   

    private void OnTriggerEnter(Collider other)
    {
        // Vérifie si l'objet qui entre dans le trigger a le tag "Player"
        if (other.CompareTag("Player"))
        {
            // Joue un son de collecte si défini
            if (collectSound != null)
            {
                AudioSource.PlayClipAtPoint(collectSound, transform.position);
            }

            GameManager.gameManager.playerNote.AddNote(this);
            Destroy(visuel);
            gameObject.GetComponent<Collider>().enabled = false;
        }
    }

    public void Effect()
    {
        unityEvent.Invoke();
        if(bullet){
            GameObject note = Instantiate(bullet, transform.position, Quaternion.identity);
            note.GetComponent<NoteBullet>().Initialize(GameManager.gameManager.playerTransform.position, GameManager.gameManager.bossTransform.position);
        }
        Destroy(this.gameObject);
    }
}
