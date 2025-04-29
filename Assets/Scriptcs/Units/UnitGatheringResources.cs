using System.Collections;
using UnityEngine;

public class UnitGatheringResources : MonoBehaviour
{
    [SerializeField] private UnitGatherer unitGatherer;
    [SerializeField] private Animator animator;
    private ResourceTypesEnum currentGatherignResourceEnum;
    

    private void OnEnable()
    {
        animator.SetBool("IsMining", true);
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

        }
    }

    private void OnDisable()
    {
        animator.SetBool("IsMining", false);
        StopAllCoroutines();
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
        unitGatherer.AddResourceToDictionary(ResourceTypesEnum.stone, 3);

        StartCoroutine(GatheringStoneCycle());
    }


    public void SetCurrentGatheringTypeEnum(ResourceTypesEnum gatheringResourceTypeEnum)
    {
        currentGatherignResourceEnum = gatheringResourceTypeEnum;
    }


}
