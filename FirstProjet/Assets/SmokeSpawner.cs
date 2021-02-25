using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeSpawner : MonoBehaviour
{
    public ParticleSystem smokeEffect;

    // Start is called before the first frame update
    void Start()
    {
        smokeEffect.Stop();
    }

    private void OnMouseDown()
    {
        if (smokeEffect.isPlaying)
        {
            smokeEffect.Stop();
        }
        else
        {
            smokeEffect.Play();
        }
    }
}
