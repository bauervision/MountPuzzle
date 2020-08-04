using UnityEngine;
using System.Collections;
using Invector.vCharacterController;

public class Item : MonoBehaviour
{
    AudioSource _audioSource;
    public AudioClip _audioClip;
    public GameObject _particle;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !_audioSource.isPlaying)
        {
            Renderer[] renderers = GetComponentsInChildren<Renderer>();
            foreach (Renderer r in renderers)
                r.enabled = false;

            _audioSource.PlayOneShot(_audioClip);
            Destroy(gameObject, _audioClip.length);

            PuzzleTimer.instance.finished = true;
            InteractionManager.SetMainItemFound();
        }
    }
}

