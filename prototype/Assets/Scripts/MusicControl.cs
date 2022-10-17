using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl : MonoBehaviour
{
    // Start is called before the first frame update
    public static MusicControl instance; // Creates a static varible for a MusicControlScript instance

    public void HandleCall(MusicControl obj){
        if (instance == null) // If the MusicControlScript instance variable is null
        {
            instance = this; // Set this object as the instance
        }
    }
    private void Awake() // Runs before void Start()
    {
         // Don't destroy this gameObject when loading different scenes

        if (instance == null) // If the MusicControlScript instance variable is null
        {

            instance = this; // Set this object as the instance
            DontDestroyOnLoad(this.gameObject);
        }
        else // If there is already a MusicControlScript instance active
        {
            Destroy(gameObject); // Destroy this gameObject
        }
    }
}
