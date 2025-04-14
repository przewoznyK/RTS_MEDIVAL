using System.Collections;
using UnityEngine;

public class UnitGatheringResources : MonoBehaviour
{
 //   [SerializeField] private UnitStats unitStats;
    [SerializeField] private Animator animator;
    [SerializeField] private ResourceTypesEnum currentGatherignResourceEnum;
    [SerializeField] private BuildingToBulit buildingToBulit;
    private void OnEnable()
    {

        animator.SetBool("IsMining", true);
        //if (unitStats.GetCurrentGatheringeResource() == ResourceTypesEnum.wood)
        //    StartCoroutine(GatheringWoodCycle());
        //else if (unitStats.GetCurrentGatheringeResource() == ResourceTypesEnum.stone)
        //    StartCoroutine(GatheringStoneCycle());

    }

    public void StartGathering()
    {
        switch (currentGatherignResourceEnum)
        {
            case ResourceTypesEnum.wood:
               StartCoroutine(GatheringWoodCycle());
                break;
            case ResourceTypesEnum.stone:
                StartCoroutine(GatheringStoneCycle());
                break;
            case ResourceTypesEnum.building:
                Debug.Log(2);
                StartCoroutine(BuildingCycle());
                break;

        }
    }

    private void OnDisable()
    {
        animator.SetBool("IsMining", false);
        StopAllCoroutines();
    }
    void Update()
    {

    }
    IEnumerator GatheringWoodCycle()
    {

        yield return new WaitForSeconds(3f);
        PlayerResourceManager.instance.AddResource(ResourceTypesEnum.wood, 3);
        StartCoroutine(GatheringWoodCycle());
    }
    IEnumerator GatheringStoneCycle()
    {
        yield return new WaitForSeconds(3f);
        PlayerResourceManager.instance.AddResource(ResourceTypesEnum.stone, 3);
        StartCoroutine(GatheringStoneCycle());
    }

    IEnumerator BuildingCycle()
    {
        yield return new WaitForSeconds(3f);
        Debug.Log(3);
        buildingToBulit.WorkOnBuilding(3);
        StartCoroutine(BuildingCycle());
    }


    public void SetCurrentGatheringTypeEnum(ResourceTypesEnum gatheringResourceTypeEnum)
    {
        currentGatherignResourceEnum = gatheringResourceTypeEnum;
    }

    public void SetBuildingToBuild(BuildingToBulit newBuildingToBulit)
    {
        buildingToBulit = newBuildingToBulit;
    }
}
