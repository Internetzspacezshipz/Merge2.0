using UnityEngine;

public class CheckpointSystem : MonoBehaviour
{
    [SerializeField]
    private static int numberOfCheckpoints = 3;

    [SerializeField]
    private Checkpoint[] checkpointsBody = new Checkpoint[numberOfCheckpoints];

    [SerializeField]
    private Checkpoint[] checkpointsSoul = new Checkpoint[numberOfCheckpoints];


    private Vector2[] checkpointBodyLocation = new Vector2[numberOfCheckpoints];
    private Vector2[] checkpointSoulLocation = new Vector2[numberOfCheckpoints];

    [SerializeField]
    private Body Body;

    [SerializeField]
    private Soul Soul;


    //Singleton
    public static CheckpointSystem instance;

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Body = FindObjectOfType<Body>();
            Soul = FindObjectOfType<Soul>();

            instance = this;
            return;
        }
        Destroy(this);
    }

    public void SpawnAtCheckpoint()
    {
        Debug.Log(GameManager.instance.currentCheckpoint);

        Body.transform.position = checkpointsBody[GameManager.instance.currentCheckpoint].transform.position;
        Soul.transform.position = checkpointsSoul[GameManager.instance.currentCheckpoint].transform.position;
    }
}