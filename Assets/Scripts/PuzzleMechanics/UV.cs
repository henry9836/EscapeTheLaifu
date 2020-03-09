using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class UV : MonoBehaviour
{
    
    class LightBeam
    {
        public void refresh(Vector3 forwardLightDir, Vector3 lightPosition, LayerMask uvLayer)
        {
            //Get Beam Info

            float angleOfBeam = light.spotAngle * 0.5f;
            float distanceOfBeam = light.range;

            beamDir = Quaternion.AngleAxis(angleOfBeam, Vector3.forward) * forwardLightDir;
            beamPos = lightPosition + (beamDir * distanceOfBeam);

            centerBeamPos = lightPosition + (forwardLightDir * distanceOfBeam);

            //Build Lists

            float amountofSphereChecks = distanceOfBeam / stepDistance;

            float distanceFromOrigin = 0.0f;
            float radius = 0.0f;
            Vector3 radiusPos = Vector3.zero;
            Vector3 lightBeamPos = Vector3.zero;
            

            //For each stepcheck
            for (int i = 0; i < amountofSphereChecks; i++)
            {
                //i * stepdistance = distance of check
                //Vector3.Distance(lightBeam.beamPos, lightBeam.centerBeamPos) at point is equal to radius

                //Physics Check
                distanceFromOrigin = i * stepDistance;

                //Get positions
                lightBeamPos = lightPosition + (forwardLightDir * distanceFromOrigin);
                radiusPos = lightPosition + (beamDir * distanceFromOrigin);
                radius = Vector3.Distance(lightBeamPos, radiusPos);

                //Perform a sphere cast
                Collider[] cols = Physics.OverlapSphere(lightBeamPos, radius, uvLayer);

                //If we hit objects
                for (int j = 0; j < cols.Length; j++)
                {
                    Debug.DrawLine(lightPosition, lightBeamPos, Color.yellow);
                    Debug.DrawLine(lightBeamPos, cols[j].gameObject.transform.position, Color.red);
                    //If the object has a uv object component
                    if (cols[j].gameObject.GetComponent<UVObject>())
                    {
                        //Invoke Glow
                        cols[j].gameObject.GetComponent<UVObject>().invokeLight();
                    }
                }
            }

        }

        public Vector3 beamPos = Vector3.zero;
        public Vector3 beamDir = Vector3.zero;
        public Vector3 centerBeamPos = Vector3.zero;

    };

    public static float stepDistance = 0.1f;

    private new static Light light = null;
    private LightBeam lightBeam = new LightBeam();
    public LayerMask uvLayer;

    private void Start()
    {
        light = GetComponent<Light>();
    }

    private void FixedUpdate()
    {
        lightBeam.refresh(transform.forward, transform.position, uvLayer);
        //Debug.DrawLine(transform.position, lightBeam.beamPos, new Color(0.40f, 0.20f, 0.92f));
        //Debug.DrawLine(transform.position, lightBeam.centerBeamPos, Color.red);
    }
}
