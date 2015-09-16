using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite; 
using System.Data; 
using System;

public class DBmanager  {


	private static DBmanager gInstance;
	public static DBmanager GetInstance
	{
		get
		{
			if(gInstance == null)
				gInstance = new DBmanager();
			return gInstance;
		}
	}

	IDbConnection dbconn;
	string conn;
	IDbCommand dbcmd;

	string sqlQuery;

	IDataReader reader;

	private DBmanager()
	{


		conn = "URI=file:" + Application.dataPath + "/DataBase/SkillDB.db";

		dbconn = (IDbConnection) new SqliteConnection(conn);
		dbconn.Open();

		dbcmd = dbconn.CreateCommand();		
	}

	~DBmanager()
	{


		dbcmd.Dispose();
		dbcmd = null;
		dbconn.Close();
		dbconn = null;
	}
		
		
	public void read()
	{
		while (reader.Read()) {
			//int value = reader.GetInt32(0);
		//	string name = reader.GetString (0);
			//int rand = reader.GetInt32(2);
			
			Debug.Log (reader);
		}

	}

	public SkillInfo readSkillToCode(int code)
	{

		sqlQuery = "select * from BasicSkillTable Where SkillCode = " + code.ToString();	

		dbcmd.CommandText = sqlQuery;
		reader = dbcmd.ExecuteReader();

		reader.Read ();
	
		SkillInfo info = new SkillInfo ();

		info.skillCode 	= reader.GetInt32 (0);
		info.name 		= reader.GetString (1);
		info.prefabName	= reader.GetString (2);
		info.attribute	= reader.GetInt32 (3);
		info.demage 	= reader.GetInt32 (4);
		info.numberOfObject	= reader.GetInt32 (5);
		info.coolTime	= reader.GetFloat (6);
		info.useLimit	= reader.GetInt32 (7);	
		info.etc1		= reader.GetInt32(8);
		info.etc2		= reader.GetInt32(9);
		info.etc3		= reader.GetInt32(10);
		info.ICon		= reader.GetString(11);

		reader.Close();
		reader = null;
	
		return info;
	}

	public List<SkillInfo> ReadUserSkillTable()
	{
		List<SkillInfo> userSkillList = new List<SkillInfo>();

		sqlQuery = "select * from UserSkillTable";
		
		dbcmd.CommandText = sqlQuery;
		reader = dbcmd.ExecuteReader();
		

		while (reader.Read())
		{
			SkillInfo info = new SkillInfo ();
			
			info.skillCode 	= reader.GetInt32 (0);
			info.name 		= reader.GetString (1);
			info.prefabName	= reader.GetString (2);
			info.attribute	= reader.GetInt32 (3);
			info.demage 	= reader.GetInt32 (4);
			info.numberOfObject	= reader.GetInt32 (5);
			info.coolTime	= reader.GetFloat (6);
			info.useLimit	= reader.GetInt32 (7);	
			info.etc1		= reader.GetInt32(8);
			info.etc2		= reader.GetInt32(9);
			info.etc3		= reader.GetInt32(10);
			info.ICon		= reader.GetString(11);

			userSkillList.Add(info);
		}
	

		reader.Close();
		reader = null;
		
		return userSkillList;

	}
}
