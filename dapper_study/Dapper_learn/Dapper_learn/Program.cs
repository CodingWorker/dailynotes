using System;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using MySql;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Dapper_learn
{
    class Program
    {
        static void Main(string[] args)
        {
            OperateData();
        }

        private static void OperateData()
        {
            #region ms sql dll
            /*
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];  //set the connection string
            conn.Open();  //打开到ConnectionString指定的数据库的连接
            SqlCommand cmd = conn.CreateCommand();    //创建一个要执行的命令
            cmd.CommandType = CommandType.Text;      //指定执行的命令类型为文本
            cmd.CommandText = "SELECT Top 10 * FROM VideoType";    //对数据库操作的sql语句
            SqlDataReader reader= cmd.ExecuteReader();
            
            while (reader.Read())
            {
                reader.GetInt32(0);      //获取第一列值，值类型应该与int32兼容
                reader.GetInt32(1);      //获取第二列值
                reader.GetString(2);     //获取第三列值，列类型为char
                Console.ReadKey();
            }
           
            reader.Close();   //关闭执行
            conn.Close();     //关闭连接
             */
            #endregion
            #region  use Dapper
            IDbConnection conn = new SqlConnection();
            conn.ConnectionString = System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];
     
            #region  查询
            //int cmdRet=conn.Execute("SELECT * FROM VideoType",null/*参数*/,null/*事务*/,null/*command TimeOut*/,CommandType.Text);    //执行一个只有简单返回值的命令，返回值表明命令执行是否成功,一般用在创建、删除和更新上。
            //Console.WriteLine(cmdRet);

            /*
            IEnumerable<dynamic> ret=conn.Query("SELECT Top 10 * From VideoType",null,null,false,null,CommandType.Text);    //dynamic表示在运行时决定对象类型
            foreach (var item in ret)    //直接将数据库字段映射为查询结果
            {
                int videoTypeId = item.VideoTypeId;
                int videoId = item.VideoId;
                string type = item.Type;
                //int type2 = item.Type;   //item会自动拿到数据的类型，并做转换，如果类型不兼容会抛出异常

                Console.ReadKey();
            }
            */
            /*
            List<VideoType> vts = conn.Query<VideoType>("SELECT Top 10 * FROM VideoType").ToList(); //IEnumerable可以算是一个包装接口
            foreach (var vt in vts)
            {
                Console.ReadKey();
            }
    */
            #endregion

            #region create
            /*
            VideoType vt = new VideoType {
                VideoId=1,
                Type="测试"
            };
            int ret=conn.Execute("INSERT INTO VideoType (VideoId,Type) VALUES (@VideoId ,@Type)", vt);    //返回1表明执行成功，0表示失败
            Console.ReadKey();
            */
            #endregion

            #region  update
            /*
            VideoType vt = new VideoType()
            {
                VideoTypeId= 1071635,
                VideoId = 1,
                Type = "测试2"
            };
            int ret=conn.Execute("UPDATE VideoType SET Type=@Type WHERE VideoTypeId=@VideoTypeId", vt);    //执行成功返回结果1，返回0表明执行失败
            Console.ReadKey();
            */
            #endregion

            /*
            #region  delete
            VideoType vt = new VideoType()
            {
                VideoTypeId = 1071635
            };
            int ret = conn.Execute("DELETE FROM VideoType WHERE VideoTypeId=@VideoTypeId", vt);    //0表示失败，1表明执行成功
            Console.ReadKey();

            #endregion

      */
            conn.Close();
            #endregion
 
            string mysqlConnString = System.Configuration.ConfigurationSettings.AppSettings["MySQL_ConnectionString"];
            using (IDbConnection mysqlConn = new MySqlConnection(mysqlConnString))
            {
                string sql = "SELECT * FROM meta_data;";
                List<MetaData> metadatas = mysqlConn.Query<MetaData>(sql).ToList();
            }


        }

        private sealed class VideoType    //此实体必须与数据库的表字段一致
        {
            public int? VideoTypeId { get; set; }
            public int? VideoId { get; set; }
            public string Type { get; set; }
        }

        private sealed class MetaData
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Url { get; set; }
            public DateTime TimeCreated { get; set; }
            public DateTime TimeModified { get; set; }
            public string Desc { get; set; }
            public string Author { get; set; }
            public int TypeId { get; set; }

        }
    }
}
