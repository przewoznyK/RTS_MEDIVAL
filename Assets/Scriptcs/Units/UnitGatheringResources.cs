using System.Collections;
using UnityEngine;

public class UnitGatheringResources : MonoBehaviour
{
    [SerializeField] private UnitStatisitcsSO unitStatisitcs;
    [SerializeField] private Animator animator;
    
    private void OnEnable()
    {

        animator.SetBool("IsMining", true);

        if (unitStatisitcs.GetCurrentGatheringeResource() == ResourceTypesEnum.wood)
            StartCoroutine(GatheringWoodCycle());
        else if (unitStatisitcs.GetCurrentGatheringeResource() == ResourceTypesEnum.stone)
            StartCoroutine(GatheringStoneCycle());

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


}
