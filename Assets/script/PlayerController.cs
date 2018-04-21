using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public Camera camera;
    public GameObject floor;
    public NavMeshAgent navAgent;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.LogFormat("click {0} {1}", 128*Input.mousePosition.x/Screen.width, 128*Input.mousePosition.y/Screen.height);

            RaycastHit hitInfo;
            var ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hitInfo)&& hitInfo.collider.name == floor.name)
            {
                //Debug.LogFormat("hit {0} {1}", hitInfo.collider.name, hitInfo.point);
                navAgent.destination = hitInfo.point;
            }
        }
    }
}
