using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class test : XRBaseInteractor
{
    private XRBaseInteractable currentInteractable = null;

    private void onTriggerEnter (Collider other)
    {
        Debug.Log("onTriggerExit");
        SetInteractable(other);
    }
    private void SetInteractable (Collider other)
    {
        if (TryGetInteractable(other, out XRBaseInteractable interactable)) {
            if (currentInteractable == null)
                currentInteractable = interactable;
        }
    }
    private void onTriggerExit (Collider other)
    {
        Debug.Log("onTriggerExit");
        ClearInteractable(other);
    }
    private void ClearInteractable (Collider other)
    {
        if (TryGetInteractable(other, out XRBaseInteractable interactable)) {
            if (currentInteractable == interactable)
                currentInteractable = null;
        }
    }
    private bool TryGetInteractable (Collider collider, out XRBaseInteractable interactable)
    {
        interactable = interactionManager.GetInteractableForCollider(collider);
        return interactable != null;
    }
    public override void GetValidTargets (List<XRBaseInteractable> validTargets)
    {
        validTargets.Clear();
        validTargets.Add(currentInteractable);
    }

    public override bool CanHover (XRBaseInteractable interactable)
    {
        return base.CanHover(interactable) && currentInteractable == interactable;
    }

    public override bool CanSelect(XRBaseInteractable interactable)
    {
        return false;
    }

}
