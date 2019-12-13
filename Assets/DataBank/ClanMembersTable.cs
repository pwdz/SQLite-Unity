using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using UnityEngine;

namespace DataBank
{
    public class ClanMembersTable : SQLiteHelper
    {
        private static readonly object padLock = new object();
        private static ClanMembersTable instance;
        private static string DbDefaultName="messages"; 
        //in case that the dbName in GetInstance method be null
        private const String Tag = "Ebi: ClanMembersTable:\t";
        
        private String tableName = "clanMembers";
        private const String KeyId = "id";
        private const String KeyCoin = "coin";
        private const String  KeyMemberPass = "";
        private String[] COLUMNS = new String[] {KeyId, KeyCoin, KeyMemberPass};

        public static ClanMembersTable GetInstace(string dbName)
        {
            // get
            // {
            if (instance.Equals(null))
            {
                lock (padLock)
                {
                    if(dbName.Equals(null)) 
                        instance = new ClanMembersTable(DbDefaultName);
                    else
                        instance = new ClanMembersTable(dbName);
                    instance = FindObjectOfType<ClanMembersTable>();   
                    if (instance.Equals(null))
                    {
                        GameObject gameObject = new GameObject();
                        instance = gameObject.AddComponent<ClanMembersTable>();
                        // if(dbName.Equals(null))
                            // instance.CreateTable(DbDefaultName);
                        // else
                            // instance.CreateTable(dbName);    
                        DontDestroyOnLoad(gameObject);
                    }
                }
            }
            return instance;
            // }
        }
        public ClanMembersTable(string dbName) : base(dbName)
        {
            // base(dbName);
            IDbCommand dbCommand = GetDbCommand();

            dbCommand.CommandText = "CREATE TABLE IF NOT EXISTS " + tableName + " ( " +
            KeyId + " INTEGER PRIMARY KEY, " +
            KeyCoin + " INTEGER, " +//ask the size of VARCHAR OR TEXT instead
            KeyMemberPass + " TEXT )";

            dbCommand.ExecuteNonQuery();
        }
        public void AddData(int id, int coinAmount,string memberPass)
        {
            IDbCommand dbCommand = GetDbCommand();
            dbCommand.CommandText =
                "INSERT INTO " + tableName
                + " ( "
                + KeyId + ", "
                + KeyCoin + ", "
                + KeyMemberPass + " ) "

                + "VALUES ( "
                + id + ", '"
                + coinAmount + "', '"
                + memberPass + "' )";
            dbCommand.ExecuteNonQuery();
       	}
        public void AddData()//polymorphism
        {
            
        }
        public void UpdateRow(int currentId , int newId,int newCoinAmount , string newMemberPass)
        {
            IDbCommand dbCommand = GetDbCommand();
            dbCommand.CommandText = "UPDATE " + tableName + " SET " + 
            KeyId + " = " + newId + ", " + KeyCoin + " = '" + newCoinAmount + "', " + KeyMemberPass + " = '" + newMemberPass + "' WHERE " + KeyId + " = " + currentId ;
            dbCommand.ExecuteNonQuery(); 
        }

        public override IDataReader GetDataById(int id)
        {
            Debug.Log(Tag + "Getting list by id: " + id);
            IDbCommand dbCommand = GetDbCommand();
            dbCommand.CommandText = "SELECT * FROM "+ tableName + " WHERE " + KeyId + " = " + id ;
            return dbCommand.ExecuteReader();
        }   
        public override IDataReader GetDataByString(string MemberPassStr)
        {
            Debug.Log(Tag + "Getting list: " + MemberPassStr);

            IDbCommand dbCommand = GetDbCommand();
            dbCommand.CommandText =
                "SELECT * FROM " + tableName + " WHERE " + KeyMemberPass + " = '" + MemberPassStr + "'";
            return dbCommand.ExecuteReader();
        }
        public override void DeleteDataByString(string str) //lazem mishe aya?
        {
            Debug.Log(Tag + "Deleting by string: " + str);

            IDbCommand dbCommand = GetDbCommand();
            dbCommand.CommandText =
                "DELETE FROM " + tableName + " WHERE " + KeyMemberPass + " = '" + str + "'";
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