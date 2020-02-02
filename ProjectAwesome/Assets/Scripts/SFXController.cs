using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXController : MonoBehaviour
{
    [SerializeField] AudioClip[] damage;
    [SerializeField] AudioClip[] hit;
    [SerializeField] GameState state;

    AudioClip player;
    AudioSource source;

    private void Start()
    {
        source = gameObject.GetComponent<AudioSource>();
    }

    int GetSet()
    {
        return state.scoreList.Count;
    }

    public void PlayDamage() {
        int set = GetSet();

        if (set == 0)
        {
            player = damage[0];
        }
        else if (set == 1)
        {
            player = damage[1];
        }
        else
        {
            player = damage[2];
        }

        source.PlayOneShot(player,1f);
    }

    public void PlayHit()
    {
        int set = GetSet();

        if (set == 0)
        {
            player= hit[0];
        }
        else if (set == 1)
        {
            player = hit[1];
        }
        else
        {
            player = hit[2];
        }

        source.PlayOneShot(player,1f);
    }
}
