using UnityEngine;
using System.Collections;

public class AddImage : MonoBehaviour
{
    private string url = "https://pbs.twimg.com/profile_images/557282175452581888/a9ik7C4m.png";
    private Texture2D img;
    private Renderer _renderer;
	// Use this for initialization
	void Start ()
	{
        _renderer = GetComponent<Renderer>();
	    StartCoroutine(LoadImage());
	}

    IEnumerator LoadImage()
    {
        yield return 0;
        var imgLink = new WWW(url);
        yield return imgLink;
        img = imgLink.texture;
        _renderer.material.mainTexture = img;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
