using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;

public class AgenteEquilibrista : Agent
{
    public GameObject bola;
    private Rigidbody rigidBola;
    private EnvironmentParameters parameters;
    public override void Initialize()
    {
        rigidBola = bola.GetComponent<Rigidbody>();
        parameters = Academy.Instance.EnvironmentParameters;
    }

    public override void OnEpisodeBegin()
    {
      gameObject.transform.Rotate(Vector3.right, Random.Range(-10, 10));
      gameObject.transform.Rotate(Vector3.forward, Random.Range(-10, 10));
    }
    public override void Heuristic(float[] actionsOut)
    {
        actionsOut[0] = Input.GetAxis("Horizontal");
        actionsOut[1] = Input.GetAxis("Vertical");
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        // Agente 
        sensor.AddObservation(gameObject.transform.rotation.x); // 1
        sensor.AddObservation(gameObject.transform.rotation.y); // 2
        // La bola
        sensor.AddObservation(bola.transform.position - gameObject.transform.position); // 5
        sensor.AddObservation(rigidBola.velocity); // 8
    }

    public override void OnActionReceived(float[] vectorAction)
    {
        gameObject.transform.rotation = Quaternion.Euler(vectorAction[0], 0, vectorAction[1]); 
        EndEpisode();
    }
}
