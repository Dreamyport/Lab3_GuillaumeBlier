using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorUnlock : MonoBehaviour
{
    /* ---------------------
     * M�thodes priv�es:
     * ---------------------
     */
    private void OnTriggerEnter(Collider other) 
    {
        // On d�sactive les �l�ments lorsque la cl� entre en contact avec la porte.
        if (other.gameObject.tag == "Key") 
        {
            transform.parent.gameObject.SetActive(false);
            other.gameObject.SetActive(false);
        }
    }
}
