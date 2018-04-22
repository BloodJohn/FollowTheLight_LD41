using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class ExitLevel : MonoBehaviour
{
    public float maxDist2 = 10f;
    public NavMeshAgent boy;
    public string nextSceneName;

    // Update is called once per frame
    void Update()
    {
        var dist2 = (boy.transform.position - transform.position).sqrMagnitude;

        if (dist2 <= maxDist2 && !string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
            nextSceneName = string.Empty;
        }
    }
}
