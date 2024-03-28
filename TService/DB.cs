using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public partial class rtdp_system_files_chunk_trans
{

    /// <summary>
    /// 编号
    /// </summary>        
    public string id { get; set; }
    /// <summary>
    /// 业务数据编号
    /// </summary>        
    public string relate_id { get; set; }
    /// <summary>
    /// 块
    /// </summary>        
    public long chunk { get; set; }
    /// <summary>
    /// 块开始字节
    /// </summary>        
    public long start_position { get; set; }
    /// <summary>
    /// 块总字节
    /// </summary>        
    public long chunk_size { get; set; }
    /// <summary>
    /// 是否已传输
    /// </summary>        
    public bool isDone { get; set; }
    /// <summary>
    /// create_by
    /// </summary>        
    [SqlSugar.SugarColumn(IsNullable = true)]
    public string create_by { get; set; }
    /// <summary>
    /// create_date
    /// </summary>        
    [SqlSugar.SugarColumn(IsNullable = true)]
    public DateTime create_date { get; set; }

}

//实体与数据库结构一样
public class Teacher
{
    [SugarColumn(IsIdentity = true, IsPrimaryKey = true)]
    public int Id { get; set; }
    public string Name { get; set; }
    //ColumnDataType 一般用于单个库数据库，如果多库不建议用
    [SugarColumn(ColumnDataType = "Nvarchar(255)")]
    public string Text { get; set; }
    [SugarColumn(IsNullable = true)]//可以为NULL
    public DateTime CreateTime { get; set; }
}

namespace TService
{
    public class DB
    {

        public DB()
        {


        }

        public static SqlSugarClient Build()
        {
            SqlSugarClient db;
            db = new SqlSugarClient(new ConnectionConfig()
            {
                ConfigureExternalServices = new ConfigureExternalServices()
                {
                    AppendDataReaderTypeMappings = new List<KeyValuePair<string, CSharpDataType>>() {

                            new KeyValuePair<string, CSharpDataType>("INTEGER",CSharpDataType.@int),
                            new KeyValuePair<string, CSharpDataType>("VARCHAR",CSharpDataType.@string),
                      }

                },

                ConnectionString = "server=127.0.0.1;Port=13306;Pooling=True;Max Pool Size = 1024;Initial Catalog=wpf_app_1;Persist Security Info=True;Connection Timeout=60;User ID=root;Password=e11UpzndoC56hUHg;Charset=utf8mb4;TreatTinyAsBoolean=false;Allow User Variables=True;allowPublickeyRetrieval=true;SslMode=None",
                DbType = DbType.MySql,
                InitKeyType = InitKeyType.Attribute,
                IsAutoCloseConnection = true
            });

            db.Aop.OnError = (exp) =>//执行SQL 错误事件
            {


                Console.WriteLine("错误SQL" + exp.Message);
            };

            if (db.DbMaintenance.IsAnySystemTablePermissions())
            {
                Console.WriteLine("连接成功！");
            }
            else
            {
                Console.WriteLine("连接失败！");
            }

            return db;
        }


        public void CreateTables()
        {
            var db = Build();
            //建表（看文档迁移）
            db.CodeFirst.SetStringDefaultLength(200).InitTables(typeof(Teacher));
        }


        public void Test()
        {
            var db = Build();
            ////查询表的所有
            var list = db.Queryable<Teacher>().ToList();
            Console.WriteLine(list.Count);
        }
    }
}
