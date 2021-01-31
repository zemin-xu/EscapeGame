using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    public bool hasKey = false;

    public GameObject key;

    public Transform top;

    public void OnKeyGrabbed()
    {
        hasKey = true;
    }

    public void OnLockAttempted()
    {
        if (hasKey)
        {
            StartCoroutine(OpenBox());
        }
        else
        {
            // cannot open
        }
    }

    private IEnumerator OpenBox()
    {
        key.SetActive(false);
        int i = 0;
        while (i < 45)
        {
            top.Rotate(new Vector3(0, -1, 0));
            i++;
            yield return null;
        }
        gameObject.SetActive(false);
    }
}