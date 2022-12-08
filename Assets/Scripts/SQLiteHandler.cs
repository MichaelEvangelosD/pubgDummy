using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SQLiteHandler : MonoBehaviour
{
    private string dbPath = "";

    private void Awake()
    {
        if (dbPath == "")
        {
            dbPath = "URI=file:" + Application.dataPath + "/Resources/pubgDb.db";

#if UNITY_STANDALONE && !UNITY_EDITOR
            dbPath = "URI=file:" + Application.dataPath + "/pubgDb.db";
#endif

            CreateDBSchema();
        }

        void CreateDBSchema()
        {

        }
    }
}
