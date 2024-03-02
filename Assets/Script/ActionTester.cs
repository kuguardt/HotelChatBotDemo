using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionTester : MonoBehaviour
{
    public Vector3 movingDirection;
    public Rigidbody rb;

    public float movingDuration;
    public void testing()
    {
        Debug.Log("ACTION!!!");
    }

    public void testingGoal()
    {
        Debug.Log("GOAL COMPLETE!!!");
    }

    public void testingGoal2(string goal)
    {
        Debug.Log("GOAL COMPLETE!!! : " + goal);

        StartCoroutine(movingCharacter());
    }

    public void EmotionChange(string text1, string text2)
    {
        Debug.Log("Emotion Change!!!");
        Debug.Log("text1 = " + text1);
        Debug.Log("text2 = " + text2);
        //StartCoroutine(movingCharacter());
    }

    public IEnumerator movingCharacter()
    {
        rb.velocity = movingDirection;
        yield return new WaitForSeconds(movingDuration);
        rb.velocity = new Vector3(0,0,0);
    }
}
