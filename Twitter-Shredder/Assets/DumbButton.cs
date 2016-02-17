using UnityEngine;
using System.Collections;

public class DumbButton : MonoBehaviour
{
    public int minRange = 1;
    private GameObject _player;
    private bool _isAnimationPlaying;
    // Use this for initialization
    void Start ()
	{
	    _player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
	    if (_isAnimationPlaying)
	    {
	        return;
	    }

        float distance = Vector3.Distance(transform.position, _player.transform.position);
        bool closeEnough = distance < minRange;
	    if (closeEnough)
	    {
	        if (Input.GetKeyDown(KeyCode.E) && !_isAnimationPlaying)
	        {
	            _isAnimationPlaying = true;
            }
	    }
    }
}
