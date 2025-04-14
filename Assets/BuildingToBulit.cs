using System;
using UnityEngine;

public class BuildingToBulit : MonoBehaviour
{
    [SerializeField] private GameObject finishBuilding;
    [SerializeField] private int timeToBuilt;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetFinishBuilding(GameObject builtToCreate)
    {
        finishBuilding = builtToCreate;
    }

    internal void EndProcess()
    {
        Instantiate(finishBuilding, transform.position, Quaternion.identity);
    }

    public void WorkOnBuilding(int value)
    {
        if(timeToBuilt > 0)
        {
            timeToBuilt -= value;
        }
        else
        {
            EndProcess();
        }
    }
}
