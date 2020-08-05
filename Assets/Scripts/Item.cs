using UnityEngine;
using System.Collections;
using Invector.vCharacterController;

public class Item : MonoBehaviour
{
    AudioSource _audioSource;
    public AudioClip _audioClip;
    public GameObject _particle;

    public enum ItemType { Main, Bonus1, Bonus2, Coin, Gem, Glass, Wood, Metal };

    public ItemType myType;

    public bool willSpin = true;
    public float SpinRate = 1.0f;
    public bool SpinX = false;
    public bool SpinY = false;
    public bool SpinZ = true;



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

            //stop timer
            PuzzleTimer.instance.finished = true;
            // trigger item collected
            InteractionManager.SetItemFound((int)myType);
        }
    }

    private void Update()
    {

        if (willSpin)
        {
            var spinAmount = (SpinRate * 50) * Time.deltaTime;
            transform.Rotate(SpinX ? spinAmount : 0, SpinY ? spinAmount : 0, SpinZ ? spinAmount : 0);
        }
    }
}

