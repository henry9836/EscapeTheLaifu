using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UV : MonoBehaviour
{
    
    class LightBeam
    {
        public void refresh(Vector3 forwardLightDir, Vector3 lightPosition)
        {


            float angleOfBeam = light.spotAngle * 0.5f;
            float distanceOfBeam = light.range;


            //Get Torch Beam Directions From Angle

            /*
            var q = Quaternion.AngleAxis(angle, Vector3.forward);
            newPosition = currentPosition + q * Vector3.right * distance;
            
            ⟨→BA⟩=(2,3)−(−3,2)=⟨5,1⟩
            */


            //Debug.Log($"Angle [{Mathf.Deg2Rad * Vector3.Angle((uvObjects[0].transform.position - lightPosition), forwardLightDir)}/{Mathf.Deg2Rad * angleOfBeam}]");
            //Debug.DrawLine(lightPosition, uvObjects[0].transform.position, Color.red);
            tLDir = Quaternion.AngleAxis(angleOfBeam, Vector3.forward) * forwardLightDir;
            tRDir = Quaternion.AngleAxis(-angleOfBeam, Vector3.forward) * forwardLightDir;
            //Vector3 tRDir1 = Quaternion.AngleAxis(angleOfBeam, Vector3.forward) * forwardLightDir;
            //Vector3 tRDir2 = Quaternion.AngleAxis(angleOfBeam, Vector3.up) * forwardLightDir;
            //tRDir = tRDir1 + tRDir2;

            //Vector3 bLDir1 = Quaternion.AngleAxis(-angleOfBeam, Vector3.forward) * forwardLightDir;
            //Vector3 bLDir2 = Quaternion.AngleAxis(-angleOfBeam, Vector3.up) * forwardLightDir;
            //bLDir = bLDir1 + bLDir2;

            ////tLDir = tRDir1 + bLDir2;
            //bRDir = bLDir1 + tRDir2;

            tRPos = lightPosition + (tRDir * distanceOfBeam);
            tLPos = lightPosition + (tLDir * distanceOfBeam);
            //bLPos = lightPosition + (bLDir * distanceOfBeam);
            //bRPos = lightPosition + (bRDir * distanceOfBeam);
            //Get Torch Positions



            Vector3 coneBasePos = lightPosition + (forwardLightDir * distanceOfBeam);

            float radius = Vector3.Distance(coneBasePos, tRPos);

            coneNormals.x = (coneBasePos.x - lightPosition.x) / distanceOfBeam;
            coneNormals.y = (coneBasePos.y - lightPosition.y) / distanceOfBeam;
            coneNormals.z = (coneBasePos.z - lightPosition.z) / distanceOfBeam;

            float C = radius * radius / distanceOfBeam;

            float Y0 = coneNormals.x * lightPosition.x + coneNormals.y * lightPosition.y + coneNormals.z * lightPosition.z;

            Vector3 target = uvObjects[0].transform.position;

            float coneY = target.x * coneNormals.x + target.y * coneNormals.y + target.z * coneNormals.z - Y0;
            if (coneY < 0)
            {
                Debug.Log("Outside");
            }
            else if (coneY > distanceOfBeam)
            {
                Debug.Log("Outside");
            }

            float tempX = target.x - lightPosition.x - coneY * coneNormals.x;
            float tempY = target.y - lightPosition.y - coneY * coneNormals.y;
            float tempZ = target.z - lightPosition.z - coneY * coneNormals.z;

            float coneR2 = tempX * tempX + tempY * tempY + tempZ * tempZ;

            if (coneR2 > C * coneR2)
            {
                Debug.Log("Outside");
            }
            else
            {
                Debug.Log("Inside");
            }

        }

        public Vector3 tLPos = Vector3.zero;
        public Vector3 tRPos = Vector3.zero;
        public Vector3 bLPos = Vector3.zero;
        public Vector3 bRPos = Vector3.zero;

        public Vector3 tLDir = Vector3.zero;
        public Vector3 tRDir = Vector3.zero;
        public Vector3 bLDir = Vector3.zero;
        public Vector3 bRDir = Vector3.zero;

        public Vector3 coneNormals = Vector3.zero;

    };

    static Light light;
    LightBeam lightBeam = new LightBeam();
    static List<GameObject> uvObjects = new List<GameObject>();

    /*

        For each plane of the tetrahedron, check if the point is on the same side as the remaining vertex:

        bool SameSide(v1, v2, v3, v4, p)
        {
            normal := cross(v2 - v1, v3 - v1)
            dotV4 := dot(normal, v4 - v1)
            dotP := dot(normal, p - v1)
            return Math.Sign(dotV4) == Math.Sign(dotP);
        }

        And you need to check this for each plane:

        bool PointInTetrahedron(v1, v2, v3, v4, p)
        {
            return SameSide(v1, v2, v3, v4, p) &&
                   SameSide(v2, v3, v4, v1, p) &&
                   SameSide(v3, v4, v1, v2, p) &&
                   SameSide(v4, v1, v2, v3, p);               
        }

     */

            bool CheckIfInside(Vector3 v1, Vector3 v2, Vector3 v3, Vector3 v4, Vector3 point)
    {
        Vector3 normal = Vector3.Cross(v2 - v1, v3 - v1);
        float dotV4 = Vector3.Dot(normal, v4 - v1);
        float dotP = Vector3.Dot(normal, point - v1);
        return Mathf.Sign(dotV4) == Mathf.Sign(dotP);
    }

    bool CheckIfInsideLight()
    {
        return false;
    }

    private void Start()
    {
        light = GetComponent<Light>();

        UVObject[] tmpObjs = FindObjectsOfType<UVObject>();

        for (int i = 0; i < tmpObjs.Length; i++)
        {
            uvObjects.Add(tmpObjs[i].gameObject);
        }

    }

    private void Update()
    {

        lightBeam.refresh(transform.forward, transform.position);
        Debug.DrawLine(transform.position, lightBeam.tLPos, Color.red);
        Debug.DrawLine(transform.position, lightBeam.tRPos, Color.yellow);
        Debug.DrawLine(transform.position, lightBeam.bLPos, Color.yellow);
        Debug.DrawLine(transform.position, lightBeam.bRPos, Color.yellow);
    }
}
