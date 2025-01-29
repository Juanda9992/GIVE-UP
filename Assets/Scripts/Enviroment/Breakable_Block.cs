using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable_Block : MonoBehaviour, IRevertable
{
    [SerializeField] private float breakTime;
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.transform.CompareTag("Player"))
        {
            StartCoroutine(nameof(DisableBlock));
        }    
    }

    public void RevertObject()
    {
        gameObject.SetActive(true);
    }

    private IEnumerator DisableBlock()
    {
        yield return new WaitForSeconds(breakTime);
        gameObject.SetActive(false);
    }
}
