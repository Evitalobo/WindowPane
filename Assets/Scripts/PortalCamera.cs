using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{

    public Transform playerCamera;
    public Transform portal;
    public Transform otherPortal;

    void Update()
    {
        Vector3 playerOffsetFromPortal = playerCamera.position - otherPortal.position;
        transform.position = portal.position - playerOffsetFromPortal;

        float angularDiff = Quaternion.Angle(portal.rotation, otherPortal.rotation);
        Quaternion offset = Quaternion.Euler(0, 90, 0);

        Quaternion portalRotDiff = Quaternion.AngleAxis(angularDiff, Vector3.up) * offset;
        Vector3 newCameraDirection = portalRotDiff * playerCamera.forward;
        
        transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
    }
}
