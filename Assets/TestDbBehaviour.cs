using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataBank;
using System;
public class TestDbBehaviour : MonoBehaviour
{
    void Start() {
        // LastTable LastTable.GetInstance11 = new LastTable("messages"); 
		// LastTable.GetInstance()
		LastTable.GetInstace.DeleteTable("last");
		LastTable.FUCl();

        // LastTable LastTable.GetInstance = new LastTable("messages"); 
        //Add Data
		LastTable.GetInstance().GetDataById(1);
		LastTable.GetInstance().AddData(1, "AR1", "123");
		LastTable.GetInstance.AddData(2, "AR2", "456");
		LastTable.GetInstance.AddData(3, "AR3", "789");
		LastTable.GetInstance.UpdateRow(3,3,"changed1","***");
		LastTable.GetInstance.CloseDb();


		//Fetch All Data
		LastTable LastTable.GetInstance2 = new LastTable("messages");
		System.Data.IDataReader reader = LastTable.GetInstance2.GetAllData();

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
}
