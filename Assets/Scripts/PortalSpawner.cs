using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.InputSystem;

public class PortalSpawner : MonoBehaviour
{
    [SerializeField] GameObject portalPrefab;

    List<ARRaycastHit> hits = new List<ARRaycastHit>();
    ARRaycastManager rM;

    int activePortals = 0;
    public int maxPortals = 3;

    private void Start()
    {
        rM = GetComponent<ARRaycastManager>();
    }

    public void SpawnPortal(InputAction.CallbackContext context)
    {
        var touchPosition = context.ReadValue<Vector2>();
        if (rM.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon) && activePortals < maxPortals)
        {
            var hitPose = hits[0].pose;

            Instantiate(portalPrefab, hitPose.position, hitPose.rotation, transform);
            activePortals++;
        }
    }

}
