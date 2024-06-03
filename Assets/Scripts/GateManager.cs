using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GateManager : MonoBehaviour
{
    public List<Gate> GatesList;
    private Gate[] _gates;

    private void Start()
    {
        _gates = GameObject.FindObjectsOfType<Gate>();
        GatesList = _gates.ToList();
    }

    public void UpdateAllGates()
    {
        for (int i = 0; i < GatesList.Count; i++)
        {
            GatesList[i].MakeExpression();
        }
    }

    public void FindNearestGate()
    {
        float minDistance = float.PositiveInfinity;
        bool isRightGate = false;
        Gate nearest = null;

        Vector3 playerPosition = GameObject.Find("Player").transform.position;

        for (int i = 0; i < GatesList.Count; i++)
        {
            isRightGate = GatesList[i].GetComponent<Gate>().IsRightGate;
            Vector3 gatePosition = GatesList[i].transform.position;
            float gateDistance = Vector3.Distance(playerPosition, gatePosition);
            if (isRightGate && gateDistance < minDistance && gatePosition.z > playerPosition.z)
            {
                minDistance = gateDistance;
                nearest = GatesList[i];
            }
        }

        if (nearest)
        {
            if (isRightGate == true)
                nearest.GetComponent<GateAppearance>().UpdateVisual();
            GatesList.Remove(nearest);
        }
    }
}
