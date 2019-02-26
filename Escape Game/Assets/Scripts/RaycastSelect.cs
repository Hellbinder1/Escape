using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastSelect : MonoBehaviour
{

    public float selectionDistance = 1f;
    public LayerMask layermask;

    private GameObject currentTarget;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, selectionDistance, layermask))
        {
            if (currentTarget == null)
            {
                currentTarget = hit.transform.gameObject;
                OnRaycastEnter(currentTarget);
            }

            else if (currentTarget != hit.transform.gameObject)
            {
                OnRaycastLeave(currentTarget);
                currentTarget = hit.transform.gameObject;
                OnRaycastEnter(currentTarget);
            }
        }

        else if (currentTarget != null)
        {
            OnRaycastLeave(currentTarget);
            currentTarget = null;
        }

    }

    protected virtual void OnRaycastEnter(GameObject target)
    {
    }

    protected virtual void OnRaycastLeave(GameObject target)
    {
    }

    protected virtual void OnRaycast(GameObject target)
    {
    }
}