using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataBank;
using System;

public class FUCK : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		LastTable myLastTableDb2 = new LastTable("messages");
        System.Data.IDataReader reader = myLastTableDb2.GetAllData();
        Debug.Log("show me my class bitch");
		int fieldCount = reader.FieldCount;
		// List<LastTableEntity> myList = new List<LastTableEntity>();
		while (reader.Read())
		{
			LastTableEntity entity = new LastTableEntity(Convert.ToInt32(reader[0]), 
                reader[1].ToString(), 
                reader[2].ToString());
			Debug.Log("id: " + entity._id+"|jwt: "+entity._jwt);
			// myList.Add(entity);
		}


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
