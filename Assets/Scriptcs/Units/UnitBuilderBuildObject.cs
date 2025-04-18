using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class UnitBuilderBuildObject : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Animator animator;
    [SerializeField] private BuildingToBulit buildingToBulit;

    public void StartBuild()
    {
        animator.SetBool("IsMining", true);
        buildingToBulit.AddToActiveBuildersList(this);
        StartCoroutine(BuildingCycle());
    }

    private void OnDisable()
    {
        animator.SetBool("IsMining", false);
        StopAllCoroutines();
    }

    IEnumerator BuildingCycle()
    {
        yield return new WaitForSeconds(3f);
        if (!buildingToBulit)
            yield break;
        buildingToBulit.WorkOnBuilding(3);
        StartCoroutine(BuildingCycle());
    }

    public void SetBuildingToBuild(BuildingToBulit newBuildingToBulit)
    {
        buildingToBulit = newBuildingToBulit;
    }
}
