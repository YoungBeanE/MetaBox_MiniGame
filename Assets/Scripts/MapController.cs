using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapController : MonoBehaviour
{
    [Header("Setting Map")]
    [Tooltip("This is the original prefab that creates the block.")]
    [SerializeField] Block blockPref = null;

    [Tooltip("GUI Button for map settings.")]
    [SerializeField] Button createNewPath = null;

    [Tooltip("When activated by pressing this button, you can create blocks all over the screen and create a new path.")]
    [SerializeField] bool newPath = true;

    [Tooltip("If you want to save a new path, enter a new map name. Otherwise, if you want to load an already saved map, enter the map name.")]
    [SerializeField] string mapName = null;

    [Tooltip("Variables for setting map size.")]
    [SerializeField] int map_width = 9;
    [SerializeField] int map_height = 5;


    GameObject map = null;
    Map newMap = null;

    void Awake()
    {
        if (newPath)
        {
            if (blockPref == null) blockPref = Resources.Load<Block>(nameof(Block));
            if (createNewPath == null) createNewPath = GameObject.Find("CreateNewPath").GetComponent<Button>();
        }
        else
        {
            map = (GameObject)Resources.Load(mapName);
            Instantiate(map);
        }
    }

    void Start()
    {
        if (newPath)
        {
            createNewPath.gameObject.SetActive(true);
            createNewPath.onClick.AddListener(delegate { OnClick_CreateNewPath(); });
            Generate();
        }
        else createNewPath.gameObject.SetActive(false);
    }

    /// <summary>
    /// Blocks are created on the entire screen to set a new path.
    /// </summary>
    void Generate()
    {
        map = new GameObject(mapName, typeof(Map));
        newMap = map.GetComponent<Map>();

        for (int y = -map_height; y <= map_height; y++)
        {
            for (int x = -map_width; x <= map_width; x++)
            {
                Instantiate<Block>(blockPref, new Vector3(x, y, 0f), Quaternion.identity, map.transform);
            }
        }
    }

    /// <summary>
    /// After pressing the "CreateNewPath" button, you can start creating a new Path.
    /// </summary>
    void OnClick_CreateNewPath()
    {
        StartCoroutine(nameof(NewPath));
    }

    IEnumerator NewPath()
    {
        newMap.myPath = new List<Vector2>();
        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(mouse, transform.forward, 15f);
                if (hit)
                {
                    newMap.myPath.Add(hit.transform.position);
                    hit.transform.GetComponent<Block>().Select();
                }
            }
            yield return null;
        }
    }


}

    

