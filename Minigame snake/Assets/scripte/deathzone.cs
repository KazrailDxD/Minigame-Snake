using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathzone : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
        }

        if (other.CompareTag("food"))
        {
            Destroy(other.gameObject);
        }
    }
}
