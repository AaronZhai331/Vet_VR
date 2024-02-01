using System.Collections.Generic;
using UnityEngine;

public class PositionHeightAdjust : MonoBehaviour
{    
    public bool LookToNext = true;
    public Transform LastTilesFinalCameraSpot;

    public float HeightInMeters = 1.6f;
    public List<Transform> CameraTargets = new List<Transform>();
    public Vector3 Direction = new Vector3(0f, 0f, -1f);
    public float Distance = 50f;

    private void Start()
    {
        for (int i = 0; i < CameraTargets.Count; i++)
        {
            Transform targ = CameraTargets[i];
            RaycastHit hit;                       
            if (Physics.Raycast(targ.position, Direction, out hit, Distance))
            {                
                targ.position = hit.point + ((Direction * -1f) * HeightInMeters);
                if (LookToNext)
                {
                    if (i > 0)
                    {
                        CameraTargets[i - 1].LookAt(CameraTargets[i].position);
                    }
                }
                // make the last point look at this one

                Debug.DrawRay(targ.position, Direction * hit.distance, Color.green, 5f);                
            }
            else
            {
                Debug.DrawRay(targ.position, targ.position + (Direction * Distance), Color.red, 5f);
            }
        }
    }
}
