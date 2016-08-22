using UnityEngine;
using System.Collections;

/// <summary>
/// Class for managing playersavings like options, level, etc.
/// </summary>
public class PlayerPrefsManager : MonoBehaviour {
   


	const string MASTER_VOLUME_KEY = "master_volume";
	const string DIFFICULTY_KEY = "difficulty";
	const string LEVEL_KEY = "level_unlocked_";
    const string EXP_KEY = "experience";


    /* ~~~~~~~~~~~~~~~~~
     * ~~~~~SETTER~~~~~~
     * ~~~~~~~~~~~~~~~~~*/
	public static void SetMasterVolume (float volume)
    {
		if (volume >= 0f && volume <= 1f)
        {
			PlayerPrefs.SetFloat (MASTER_VOLUME_KEY, volume);
		}
        else
        {
			Debug.LogError ("Master volume out of range");
		}
	}

    public static void AddExperience(float experience)
    {
        if (experience >= 0f)
        {
            float temp = GetExperience();
            temp += experience;
            PlayerPrefs.SetFloat(EXP_KEY, temp);
        }
        else
        {
            Debug.LogError("Cannot Add a negative experience");
        }
    }

    public static void UnlockLevel (int level)
    {
		if (level <= Application.levelCount - 1)
        {
			PlayerPrefs.SetInt (LEVEL_KEY + level.ToString(), 1); // Use 1 for true
		}
        else
        {
			Debug.LogError ("Trying to unlock level not in build order");
		}
	}
	
	public static void SetDifficulty (float difficulty)
    {
		if (difficulty >= 1f && difficulty <= 3f)
        {
			PlayerPrefs.SetFloat (DIFFICULTY_KEY, difficulty);
		}
        else
        {
			Debug.LogError ("Difficulty out of range");
		}
	}

   /* ~~~~~~~~~~~~~~~~~
   * ~~~~~GETTER~~~~~~
   * ~~~~~~~~~~~~~~~~~*/
    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static bool IsLevelUnlocked(int level)
    {
        int levelValue = PlayerPrefs.GetInt(LEVEL_KEY + level.ToString());
        bool isLevelUnlocked = (levelValue == 1);

        if (level <= Application.levelCount - 1)
        {
            return isLevelUnlocked;
        }
        else
        {
            Debug.LogError("Trying to query level not in build order");
            return false;
        }
    }

    public static float GetExperience()
    {
        return PlayerPrefs.GetFloat(EXP_KEY);
    }

    public static float GetDifficulty ()
    {
		return PlayerPrefs.GetFloat (DIFFICULTY_KEY);
	}
}