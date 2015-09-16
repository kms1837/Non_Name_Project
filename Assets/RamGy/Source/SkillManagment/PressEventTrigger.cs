using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections;

 
public class PressEventTrigger : UIBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler {
    [ Tooltip( "How long must pointer be down on this object to trigger a long press" ) ]
    public float durationThreshold = 1.0f;
 
    public UnityEvent onLongPress = new UnityEvent( );
 
    private bool isPointerDown = false;
    private bool longPressTriggered = false;
    private float timePressStarted;
 
 
    private void Update( ) {
        if ( isPointerDown && !longPressTriggered ) {

            if ( Time.time - timePressStarted > durationThreshold ) {
                longPressTriggered = true;
				Debug.Log("LongClicked");
				transform.GetComponent<SkillInfoSetting>().onLongClick();
            }
        }
    }
 
    public void OnPointerDown( PointerEventData eventData ) {
        timePressStarted = Time.time;
        isPointerDown = true;
        longPressTriggered = false;
    }
 
    public void OnPointerUp( PointerEventData eventData ) {
		if (isPointerDown && longPressTriggered == false) {
			Debug.Log("NormalClicked");
			transform.GetComponent<SkillInfoSetting>().onClick();
		}
		isPointerDown = false;
    }
 
 
    public void OnPointerExit( PointerEventData eventData ) {

	     isPointerDown = false;
    }
}
