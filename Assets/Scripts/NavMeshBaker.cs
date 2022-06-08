using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class NavMeshBaker : MonoBehaviour
{
    public NavMeshSurface[] surfaces;

    NavMeshAgent navMeshAgent;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = BaseCanvas._baseCanvas.agent;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            surfaces[1].BuildNavMesh();
            navMeshAgent.agentTypeID = 0;
        }
    }
}
