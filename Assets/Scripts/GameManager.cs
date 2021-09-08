using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject[] blocks;
    [SerializeField] float blockpointer;
    [SerializeField] float safearea;

    public static GameManager Instance;

    private void Awake()
    {
        GameObject GO = Instantiate(blocks[0], transform.position, Quaternion.identity);
        GO.transform.SetParent(transform);

        GO.transform.position = Vector3.zero;

        if (Instance != null)
            DestroyImmediate(gameObject);
        else
            Instance = this;
    }

    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        if (player == null)
            return;

        while (blockpointer < player.transform.position.y+ safearea)
        {
            int index = Random.Range(0, blocks.Length);
            GameObject GO = Instantiate(blocks[index], transform.position, Quaternion.identity);
            GO.transform.SetParent(transform);

            PlatformController platfrom = GO.GetComponent<PlatformController>();

            GO.transform.position = new Vector3(0f, blockpointer + platfrom.size, 0f);

            blockpointer += platfrom.size;
        }
       

    }
}
