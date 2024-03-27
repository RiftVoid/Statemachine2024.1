using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public Transform player;

    private RandomColour randomColour;
    
    public enum States
    {
        Run,
        Patrol,
        Idle,
    }

    public States state = States.Run;

    private void Start()
    {
        NextState();
        randomColour = GetComponent<RandomColour>();
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
            case States.Idle:
                StartCoroutine(IdleState());
                break;
        }
    }

    IEnumerator IdleState()
    {
        float startTime = Time.time;
        while (state == States.Idle)
        {
            randomColour.PickRandom();
            yield return new WaitForSeconds(0.1f);
            if(Time.time - startTime > 3f) 
            {
                state = States.Patrol;
            }
        } 
        NextState();
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
                state = States.Idle;
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
            Vector3 directionToPlayer = player.position - transform.position;
            directionToPlayer.Normalize();
            //-1 to 1
            //Dot product parameters have to be "normalized"
            float result = Vector3.Dot(transform.right, directionToPlayer);
            if (result > 0.95f)
            {
                state = States.Run;
            }
            yield return null;
        }
        NextState();
    }
}
