using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 200f;
    [SerializeField] float rotationThrust = 1f;
    [SerializeField] AudioClip mainEngine;

    [SerializeField] ParticleSystem mainEngineParticles;
    [SerializeField] ParticleSystem leftThrustParticle;
    [SerializeField] ParticleSystem rightThrustParticle;
    Rigidbody rigidbody;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        thrustProcess();
        rotateProcess();
    }

    void thrustProcess()
    {
        if(Input.GetKey(KeyCode.W))
        {
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
       
    }

    void StartThrusting()
    {
        rigidbody.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
            if(!audioSource.isPlaying)
            {
            audioSource.PlayOneShot(mainEngine);
            }
            if(!mainEngineParticles.isPlaying)
            {
               mainEngineParticles.Play();
            }
    }

    void StopThrusting()
    {
        audioSource.Stop();
        mainEngineParticles.Stop(); 
    }

    
    void rotateProcess()
    {
        if(Input.GetKey(KeyCode.A))
        {
            rotateLeft();
        }
        
        else if(Input.GetKey(KeyCode.D))
        {
          rotateRight();
        }
        else
        {
           stopRotation();
        }
    }

    void rotateLeft()
        {
            ApplyRotation(rotationThrust);
            if(!rightThrustParticle.isPlaying)
            {
              rightThrustParticle.Play();
            }
        }
    
    void rotateRight()
    {
         ApplyRotation(-rotationThrust);
           if(!leftThrustParticle.isPlaying)
            {
               leftThrustParticle.Play();
            }
    }

    void stopRotation()
    {
        rightThrustParticle.Stop();
        leftThrustParticle.Stop();
    }

    
    void rotateright()
    {

    }
    void ApplyRotation(float rotationThisFrame )
    {
        rigidbody.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rigidbody.freezeRotation= false;
    }
}
