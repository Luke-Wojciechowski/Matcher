using System;
using Source.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManager : MonoSingleton<InputManager>
{
    public event Action  OnTap;
    public static event Action  OnSlideLeft;
    public static event Action  OnSlideRight;
    private Vector2 _start;
    private const float SWIPE_LIMIT = 120;

    private void Update()
    {  
        //keyboard
        if (Input.GetKeyDown(KeyCode.Z))
        {
            
            OnSlideLeft?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            OnSlideRight?.Invoke();
        }
        
        //mobile
        if (!IsInitConditionFulfilled())
        {
            return;
        }
        if (Input.touches[0].phase == TouchPhase.Began)
        {
            _start = Input.touches[0].position;
        }
        else if (Input.touches[0].phase == TouchPhase.Canceled || Input.touches[0].phase == TouchPhase.Ended)
        {
            SegregateEvents();
            _start = Vector2.zero;
        }
      
    }
    private bool IsInitConditionFulfilled()
    {
        return Input.touches.Length > 0;
    }

    private void SegregateEvents()
    { 
        
        if (Input.touches[0].position.x-_start.x>SWIPE_LIMIT)
        {
            OnSlideRight?.Invoke();
            
        }else if (Input.touches[0].position.x-_start.x<-SWIPE_LIMIT)
        {
            OnSlideLeft?.Invoke();
        }
        else
        {
            OnTap?.Invoke();
        }
    }
}
