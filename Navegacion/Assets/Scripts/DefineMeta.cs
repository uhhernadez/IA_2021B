using UnityEngine;
using UnityEngine.AI;

public class DefineMeta : MonoBehaviour
{
    public Transform meta;
    public NavMeshAgent agente;
    
    void Start()
    {
        agente.SetDestination(meta.position);
        NavMeshPathStatus status = agente.pathStatus;
        Debug.Log(status);
    }

    // Update is called once per frame
    void Update()
    { 
    }
}
