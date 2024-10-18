using UnityEngine;
using UnityEngine.AI;

public static class CalculatePath 
{
    public static bool GetPath(NavMeshAgent agent, Vector3 point, NavMeshPath pathToTarget)
    {
        pathToTarget.ClearCorners();

        if (agent.CalculatePath(point, pathToTarget) && pathToTarget.status != NavMeshPathStatus.PathInvalid)
            return true;

        Debug.Log("I can't get in there.");
        return false;
    }
}