using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public enum States
    {
        Run,
        Patrol,
    }

    public States state = States.Run;

    private void Start()
    {
        NextState();
    }

    void NextState()
    {
        switch(state)
        {
            case States.Run:
                StartCoroutine(RunState());
                break;
            case States.Patrol:
                StartCoroutine(PatrolState());
                break;
        }
    }
    
    IEnumerator RunState()
    {
        float startTime = Time.time;
        while (state == States.Run)
        {
            float wave = Mathf.Sin(Time.time * 30f) * 0.1f + 1f;
            float wave2 = Mathf.Cos(Time.time * 30f) * 0.1f + 1f;
            transform.localScale = new Vector3(wave, wave2, wave);

            float shimmy = Mathf.Sin(Time.time * 30f) * 0.9f + 0.3f;

            transform.position += transform.right * shimmy * Time.deltaTime;
            
            if(Time.time - startTime > 3f) 
            {
                state = States.Patrol;
            }
            yield return null;
        }
        NextState();
    }

    IEnumerator PatrolState()
    {
        while(state == States.Patrol)
        {
            transform.rotation *= Quaternion.Euler(0f,50f * Time.deltaTime,0f);

            yield return null;
        }
        NextState();
    }
}
