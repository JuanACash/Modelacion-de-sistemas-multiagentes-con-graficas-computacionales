using UnityEngine;

public class RobotDestroyerSimple : MonoBehaviour
{
    public float speed = 3f;
    public float destroyDistance = 1.2f;

    private GameObject currentTarget;

    void Update()
    {
        if (currentTarget == null)
        {
            FindNewTarget();
            return;
        }

        Vector3 dir = (currentTarget.transform.position - transform.position).normalized;
        transform.position += dir * speed * Time.deltaTime;

        float distance = Vector3.Distance(transform.position, currentTarget.transform.position);

        if (distance <= destroyDistance)
        {
            Destroy(currentTarget);
            currentTarget = null;
        }
    }

    void FindNewTarget()
    {
        GameObject[] infectados = GameObject.FindGameObjectsWithTag("Infectado");

        if (infectados.Length == 0)
        {
            currentTarget = null;
            return;
        }

        float minDist = Mathf.Infinity;
        GameObject nearest = null;

        foreach (var inf in infectados)
        {
            float dist = Vector3.Distance(transform.position, inf.transform.position);

            if (dist < minDist)
            {
                minDist = dist;
                nearest = inf;
            }
        }

        currentTarget = nearest;
    }
}
