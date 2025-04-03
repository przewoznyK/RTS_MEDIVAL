using System;
using System.Collections;
using System.Globalization;
using UnityEngine;

public enum GatheringResourceTypeEnum
{
    wood,
    stone
}
public class UnitGatheringResources : MonoBehaviour
{
    [SerializeField] private UnitStats unitStats;
    [SerializeField] private Animator animator;
    [SerializeField] private GatheringResourceTypeEnum currentGatherignResourceEnum;

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
        Debug.Log("START GATHERING");
        switch (currentGatherignResourceEnum)
        {
            case GatheringResourceTypeEnum.wood:
               StartCoroutine(GatheringWoodCycle());
                Debug.Log("START 1");
                break;
            case GatheringResourceTypeEnum.stone:
                StartCoroutine(GatheringStoneCycle());
                Debug.Log("START 2");
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

    public void SetCurrentGatheringTypeEnum(GatheringResourceTypeEnum gatheringResourceTypeEnum)
    {
        currentGatherignResourceEnum = gatheringResourceTypeEnum;
    }
}
