using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour, IActiveClickable
{
    [SerializeField] private UnitMovement unitMovement;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Animator animator;
    //[SerializeField] private GameObject activator;
    //private bool isActive;
    void Start()
    {
        UnitSelections.Instance.unitList.Add(this.gameObject);
  //      isActive = false;
    }
    public void ActiveObject()
    {
        unitMovement.enabled = true;
    }

    private void OnDestroy()
    {
        UnitSelections.Instance.unitList.Remove(this.gameObject);
    }
    private void Update()
    {
        animator.SetBool("IsWalking", agent.velocity.magnitude > 0.01f);
    }

    //void Update()
    //{


    //    if (Input.GetMouseButtonDown(1) && isActive)
    //    {
    //        RaycastHit hit;

    //        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
    //        {
    //            agent.destination = hit.point;
    //        }
    //    }

    //    animator.SetBool("IsWalking", agent.velocity.magnitude > 0.01f);
    //}

    //public void ActiveUnit()
    //{

    //    activator.SetActive(true);
    //    isActive = true;
    //}
    //public void DeactiveUnit()
    //{
    //    activator.SetActive(false);
    //    isActive = false;
    //}

}
