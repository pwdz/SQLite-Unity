using System;
// using System.Collections.Generic;
using System.Data;
// using System.Linq;
// using System.Text;
using UnityEngine;

namespace DataBank
{
    public class LastTable : SQLiteHelper
    {
        private static readonly object padLock = new object(); 
        private static LastTable instance;
        private static string DbDefaultName="expiredGames"; 
        //in case that the dbName in GetInstance method be null
        private const String Tag = "Ebi: LastTable:\t";
        
        private String tableName = "last";
        private const String KeyId = "id";
        private const String KeyType = "type";
        // private const String KEY_IMGURL = "imageUrl";
        // private const String KEY_NUM = "number";
        // private const String KEY_PRIORITY = "priority";
        private const String KeyLastGames = "expire";
        private String[] COLUMNS = new String[] {KeyId, KeyType, KeyLastGames};
        public static void FUCL()
        {

        } 
        public static LastTable GetInstance
        {
            get
            {
            if (instance.Equals(null))
            {
                Debug.Log("BITCHCHCHCHCHCHCHCHCHCHCHCHCH123123321321");
                lock (padLock)
                {
                    // if(dbName.Equals(null))
                        // instance = new LastTable(DbDefaultName);
                    // else
                        // instance = new LastTable();    
                    instance = FindObjectOfType<LastTable>();   
                    if (instance.Equals(null))
                    {
                        GameObject gameObject = new GameObject();
                        instance = gameObject.AddComponent<LastTable>();
                        // if(dbName.Equals(null))
                            // instance.CreateTable(DbDefaultName);
                        // else
                            // instance.CreateTable(dbName);    
                        DontDestroyOnLoad(gameObject);
                    }
                }
            }
            return instance;
            }
        }
        public LastTable(string dbName) : base(dbName) 
        {
            IDbCommand dbCommand = GetDbCommand();
            dbCommand.CommandText = "CREATE TABLE IF NOT EXISTS " + tableName + " ( " +
                		KeyId + " INTEGER PRIMARY KEY, " +
                		KeyType + " VARCHAR(20), " +
                		KeyLastGames + " TEXT )";
            dbCommand.ExecuteNonQuery();
        }
        public void AddData(int id, string type,string lastGame)
        {
            IDbCommand dbCommand = GetDbCommand();
            Debug.Log("lastGame(jwt):"+lastGame);
            dbCommand.CommandText =
                "INSERT INTO " + tableName
                + " ("
                + KeyId + ", "
                + KeyType + ", "
                + KeyLastGames + ") "

                + "VALUES ( "
                + id + ",'"
                + type + "','"
                + lastGame + "')";
            Debug.Log("dbCommandBITCH:"+dbCommand.CommandText);    
            dbCommand.ExecuteNonQuery();
       	}
        public void AddData()//polymorphism
        {

        }

        public void UpdateRow(int currentId , int newId, string newType, string newLastGame)
        {
            IDbCommand dbCommand = GetDbCommand();
            dbCommand.CommandText = "UPDATE " + tableName + " SET " + 
            KeyId + " = " + newId + ", " + KeyType + " = '" + newType + "', " + KeyLastGames + " = '" + newLastGame + "' WHERE " + KeyId + " = " + currentId ;
            dbCommand.ExecuteNonQuery(); 
        }
        public override IDataReader GetDataById(int id)
        {
            Debug.Log(Tag + "Getting list by id: " + id);
            IDbCommand dbCommand = GetDbCommand();
            dbCommand.CommandText = "SELECT * FROM "+ tableName + " WHERE " + KeyId + " = " + id ;
            return dbCommand.ExecuteReader();
        }   
        public override IDataReader GetDataByString(string LastGamesStr)
        {
            Debug.Log(Tag + "Getting list: " + LastGamesStr);

            IDbCommand dbCommand = GetDbCommand();
            dbCommand.CommandText =
                "SELECT * FROM " + tableName + " WHERE " + KeyLastGames + " = '" + LastGamesStr + "'";
            return dbCommand.ExecuteReader();
        }
        public override void DeleteDataByString(string str) //lazem mishe aya?
        {
            Debug.Log(Tag + "Deleting by string: " + str);

            IDbCommand dbCommand = GetDbCommand();
            dbCommand.CommandText =
                "DELETE FROM " + tableName + " WHERE " + KeyLastGames + " = '" + str + "'";
            dbCommand.ExecuteNonQuery();
        }
        public override void DeleteDataById(int id)
        {
            Debug.Log(Tag + "Deleting by id: "+ id);
            IDbCommand dbCommand = GetDbCommand();
            dbCommand.CommandText = "DELETE FROM " + tableName + " WHERE " + KeyId + " = " + id ;
        }

        // public override void DeleteTable()
        // {
            // Debug.Log(Tag + "Deleting Table");
            // base.DeleteAllData();
        // }

        public override IDataReader GetAllData()
        {
            IDbCommand dbCommand = GetDbCommand();
            dbCommand.CommandText = "SELECT *  FROM "+ tableName; 
            return dbCommand.ExecuteReader();
        }
        public override void RenameTable(string tableName)
        {
            Debug.Log(Tag + "Renaming table "+ this.tableName + " to "+ tableName);
            IDbCommand dbCommand = GetDbCommand();
            dbCommand.CommandText = "ALTER TABLE " + this.tableName +
            "RENAME TO " + tableName;
            this.tableName = tableName;
            dbCommand.ExecuteNonQuery();
        }
        public void AddColumn(string newColumnName,string columnType)//must be implemented!
        {
            IDbCommand dbCommand = GetDbCommand();
            dbCommand.CommandText = "ALTER TABLE " + tableName + " ADD " + newColumnName + " " + columnType;
            dbCommand.ExecuteNonQuery();
        }
    }
}