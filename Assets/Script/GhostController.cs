using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent;
    public GameObject player;
    private int counter;
    private int ghosts = 3;

    // Update is called once per frame
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }
    void Update()
    {
        if (agent.isOnNavMesh == false)
        {                  
            agent.Warp(player.transform.position);
        }
        agent.SetDestination(player.transform.position);
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.name == "PlayerCapsule")
        {
            if (ghosts == 3) 
            {
                if (counter < 20) {
                    ScoreSystem.dots -= 1;
                    counter += 1;
                } else {
                    ghosts -= 1;
                    Destroy(gameObject);
                    ScoreSystem.dots += 25;
                }
            } else if (ghosts == 2) {
                if (counter < 35) {
                    ScoreSystem.dots -= 1;
                    counter += 1;
                } else {
                    ghosts -= 1;
                    Destroy(gameObject);
                    ScoreSystem.dots += 45;
                }
            } else {
                if (counter < 50) {
                    ScoreSystem.dots -= 1;
                    counter+=1;
                } else {
                    ghosts -= 1;
                    Destroy(gameObject);
                    ScoreSystem.dots += 65;
                }
            }
        }
    }
}
