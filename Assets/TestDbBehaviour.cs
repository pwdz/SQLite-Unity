using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataBank;
public class TestDbBehaviour : MonoBehaviour
{
    void Start() {
        AwardsDb myAwardDb = new AwardsDb(); 
        //Add Data
		myAwardDb.AddData(new AwardsEntity("0", "AR", "images/a0.png","10", "100","1"));
		myAwardDb.AddData(new AwardsEntity("1", "AR", "images/a1.png","11", "101","0"));
		myAwardDb.AddData(new AwardsEntity("2", "AR", "images/a2.png","12", "102","1"));
		myAwardDb.AddData(new AwardsEntity("3", "AR", "images/a3.png","13", "103","0"));
		myAwardDb.AddData(new AwardsEntity("4", "AR", "images/a4.png","14", "104","1"));
		myAwardDb.AddData(new AwardsEntity("5", "AR", "images/a5.png","15", "105","0"));
		myAwardDb.AddData(new AwardsEntity("6", "AR", "images/a6.png","16", "106","1"));
		myAwardDb.CloseDb();


		//Fetch All Data
		AwardsDb myAwardDb2 = new AwardsDb();
		System.Data.IDataReader reader = myAwardDb2.GetAllData();

		int fieldCount = reader.FieldCount;
		List<AwardsEntity> myList = new List<AwardsEntity>();
		while (reader.Read())
		{
			AwardsEntity entity = new AwardsEntity(	reader[0].ToString(), 
                reader[1].ToString(), 
                reader[2].ToString(),
                reader[3].ToString(), 
                reader[4].ToString(),
                reader[5].ToString());

			Debug.Log("id: " + entity._id);
			myList.Add(entity);
		}

    }
}
