using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class GameConfig
{
	public DataGameConfig Config;

	public string GameVersion;

	public List<DataPage> Pages;

	private static GameConfig m_Instance;

	public static GameConfig Instance
	{
		get
		{
			if (m_Instance == null) 
			{
				m_Instance = new GameConfig ();
			}
			return m_Instance;
		}
	}

	public GameConfig()
    {

    }

	public void ParseConfig()
	{
		TextAsset json = Resources.Load("config") as TextAsset;
		string jsonText = json.text;
		Config = JsonUtility.FromJson<DataGameConfig> (jsonText);
		GameVersion = Config.GameVersion;
		ParsePages (Config);
	}

	public void ParsePages(DataGameConfig config)
	{
        Pages = config.Pages;
	}
    
}