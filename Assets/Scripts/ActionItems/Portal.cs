using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : ActionItem
{
    public Vector3 TeleportLocation { get; set; }
    [SerializeField] private Portal[] linkedPortals;
    private PortalController portalController { get; set; }
    private void Start()
    {
        portalController = FindObjectOfType<PortalController>();
        TeleportLocation = transform.position + Vector3.right * 2f;
    }

    public override void Interact()
    {
        portalController.ActivatePortal(linkedPortals);
        playerAgent.ResetPath();
    }
}
