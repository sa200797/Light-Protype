using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteStarfield : MonoBehaviour 
{
    private Transform tx;
    private ParticleSystem.Particle[] points; 

    public int starsMax = 100;
    public float starSize = 1;
    public float starDistance = 10;
    public float starClipDistance = 1;
    private float starDistanceSqr;
    private float starClipDistanceSqr;




    // Start is called before the first frame update
    void Start()
    {
        tx = transform;
        starDistanceSqr = starDistance * starDistance;
        starClipDistanceSqr = starClipDistance * starClipDistance;
        
    }

    private void CreateStars () {
        points = new ParticleSystem.Particle[starsMax];

        for (int i = 0; i < starsMax; i++ ) {
           points[i].position = Random.insideUnitSphere * starDistance + tx.position;
           points[i].color = new Color(1,1,1, 1);
           points[i].size = starSize; 
        }

    }

    // Update is called once per frame
    void Update() {
        if ( points == null ) CreateStars();

        for (int i = 0; i < starsMax; i++) {

            if ((points[i].position - tx.position) .sqrMagnitude > starDistance) {
                points[i].position = Random.insideUnitSphere * starDistance + tx.position;
            }

            if ((points[i].position - tx.position) .sqrMagnitude <= starClipDistanceSqr) {
                float percent = (points[i].position - tx.position) .sqrMagnitude / starClipDistanceSqr;
                points[i].color = new Color(1,1,1, percent);
                points[i].size = percent * starSize;
            }





        }






        
        GetComponent<ParticleSystem>().SetParticles ( points, points.Length );

        
    }
}
