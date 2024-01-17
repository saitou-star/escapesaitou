using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySE : MonoBehaviour
{

    [SerializeField]
    private AudioSource SE;
    // Start is called before the first frame update
    public void PlayAoudioSE()
    {
        SE.Play();
    }

}
