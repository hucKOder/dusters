using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CollisionDeath : MonoBehaviour
{
    public bool DestroyOnDeath = true;
    public int[] TriggerLayers;
    public float DeathVelocity;
    public ParticleSystem CollisionParticle;
    public ParticleSystem DeathParticle;

    private AudioSource ads;

    public AudioClip DeathAudio;
    public float DeathAudioVolume = 1.0f;
    public AudioClip ColissionAudio;
    public float ColissionAudioVolume = 1.0f;

    public Behaviour[] ComponentsToDisable;
    public bool IsDead { get; private set; } = false;

    private void Awake()
    {
        ads = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("impact velocity was " + collision.relativeVelocity.magnitude);

        if (TriggerLayers != null && TriggerLayers.Contains(collision.gameObject.layer))
        {
            if (ColissionAudio != null)
                ads.PlayOneShot(ColissionAudio, ColissionAudioVolume);

            if (CollisionParticle != null)
                CollisionParticle.Play();

            if (IsDead) return;

            if (collision.relativeVelocity.magnitude > DeathVelocity)
            {
                if (DeathAudio != null)
                    ads.PlayOneShot(DeathAudio, DeathAudioVolume);

                if (DeathParticle != null)
                    DeathParticle.Play();

                if (ComponentsToDisable != null)
                    foreach (var component in ComponentsToDisable)
                        component.enabled = false;

                var r = GetComponent<Rigidbody>();
                if (r != null)
                {
                    r.isKinematic = false;
                    r.freezeRotation = false;
                    r.useGravity = true;
                }

                var ani = GetComponent<Animator>();
                if (ani != null)
                    ani.enabled = false;

                IsDead = true;
                Debug.Log("Impactg fatal");
                if (DestroyOnDeath)
                    Destroy(gameObject, 0.5f);
            }
        }
    }
}
