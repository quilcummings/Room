using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Focus : MonoBehaviour
{
    public PostProcessVolume post;
    private DepthOfField dof;
    private float ler;

    private float timeElapsed = 0f;
    [SerializeField] private float focusSpeed = 100f;

    private void Start()
    {
        post.profile.TryGetSettings(out dof);
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.T))
        {
            lerpCam();
        }
      
    }

    private void lerpCam()
    {
        //dof.focusDistance.value
        while (timeElapsed < focusSpeed)
        {
            ler = Mathf.Lerp(1, 5, timeElapsed / focusSpeed);
            timeElapsed += Time.deltaTime;
            dof.focusDistance.Override(ler);
        }
    }
}
