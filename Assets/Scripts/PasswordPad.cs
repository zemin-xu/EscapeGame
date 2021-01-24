using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PasswordPad : MonoBehaviour
{
    public Transform door;
    public Transform targetPlace;
    public float doorSpeed = 0.05f;
    public bool debug = true;

    public int[] password;
    public List<TMP_Text> texts;
    private int[] input;
    private int currIndex;

    private void Start()
    {
        input = new int[4];
        input[0] = input[1] = input[2] = input[3] = 0;
        currIndex = 0;
    }

    // Start is called before the first frame update
    public void OnNumpadPressed(int i)
    {
        input[currIndex] = i;
        texts[currIndex].text = i.ToString();

        if (currIndex != 0 && currIndex % 3 == 0)
        {
            bool res = VerifyPassword();
            if (res)
            {
                StartCoroutine(OpenDoor());
                // open the door
                Debug.Log("correct");
                return;
            }
            else
            {
                currIndex = 0;
                Debug.Log("wrong");
                // wrong password, reset
                return;
            }
        }

        currIndex++;
    }

    public bool VerifyPassword()
    {
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == password[i])
                continue;
            else
                return false;
        }
        return true;
    }

    private IEnumerator OpenDoor()
    {
        while (true)
        {
            if (Vector3.Distance(door.position, targetPlace.position) < 0.01f)
                break;
            door.position = Vector3.MoveTowards(door.position, targetPlace.position, doorSpeed);
            yield return null;
        }
    }
}