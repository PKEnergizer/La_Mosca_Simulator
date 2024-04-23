using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IWaypointProvider
{
    Transform CurrentWaypoint { get; }
    float Speed { get; }
    void SetNextWaypoint();
}