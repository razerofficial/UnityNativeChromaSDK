// Ref: https://gist.github.com/Naphier/46e066746ee9eeb70ebfd5062dc426bf

using UnityEngine;

namespace NG
{
    public static class Vector3Ext
    {
        #region Multilerp
        // This is not very optimized. There are at least n + 1 and at most 2n Vector3.Distance
        // calls (where n is the number of waypoints). 
        public static Vector3 MultiLerp(Vector3[] waypoints, float ratio)
        {
            Vector3 position = Vector3.zero;
            float totalDistance = waypoints.MultiDistance();
            float distanceTravelled = totalDistance * ratio;

            int indexLow = GetVectorIndexFromDistanceTravelled(waypoints, distanceTravelled);
            int indexHigh = indexLow + 1;

            // we're done
            if (indexHigh > waypoints.Length - 1)
                return waypoints[waypoints.Length - 1];


            // calculate the distance along this waypoint to the next
            Vector3[] completedWaypoints = new Vector3[indexLow + 1];

            for (int i = 0; i < indexLow + 1; i++)
            {
                completedWaypoints[i] = waypoints[i];
            }

            float distanceCoveredByPreviousWaypoints = completedWaypoints.MultiDistance();
            float distanceTravelledThisSegment = distanceTravelled - distanceCoveredByPreviousWaypoints;
            float distanceThisSegment = Vector3.Distance(waypoints[indexLow], waypoints[indexHigh]);

            float currentRatio = distanceTravelledThisSegment / distanceThisSegment;
            position = Vector3.Lerp(waypoints[indexLow], waypoints[indexHigh], currentRatio);

            return position;
        }

        public static float MultiDistance(this Vector3[] waypoints)
        {
            float distance = 0f;

            for (int i = 0; i < waypoints.Length; i++)
            {
                if (i + 1 > waypoints.Length - 1)
                    break;

                distance += Vector3.Distance(waypoints[i], waypoints[i + 1]);
            }

            return distance;
        }

        public static int GetVectorIndexFromDistanceTravelled(Vector3[] waypoints, float distanceTravelled)
        {
            float distance = 0f;

            for (int i = 0; i < waypoints.Length; i++)
            {
                if (i + 1 > waypoints.Length - 1)
                    return waypoints.Length - 1;

                float segmentDistance = Vector3.Distance(waypoints[i], waypoints[i + 1]);

                if (segmentDistance + distance > distanceTravelled)
                {
                    return i;
                }

                distance += segmentDistance;
            }

            return waypoints.Length - 1;
        }
        #endregion

    }
}
