using SqlSugar;


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

namespace DB
{
    public class Class1
    {


        SqlSugarClient Db = new SqlSugarClient(new ConnectionConfig()
        {
            ConnectionString = "server=127.0.0.1;Port=13306;Pooling=True;Max Pool Size = 1024;Initial Catalog=rtdp_local;Persist Security Info=True;Connection Timeout=60;User ID=root;Password=e11UpzndoC56hUHg;Charset=utf8mb4;TreatTinyAsBoolean=false;Allow User Variables=True;allowPublickeyRetrieval=true;SslMode=None",
            DbType = DbType.Sqlite,
            IsAutoCloseConnection = true
        }, db =>
        {

            db.Aop.OnLogExecuting = (sql, pars) =>
            {

                //获取原生SQL推荐 5.1.4.63  性能OK
                Console.WriteLine(UtilMethods.GetNativeSql(sql, pars));

                //获取无参数化SQL 对性能有影响，特别大的SQL参数多的，调试使用
                //Console.WriteLine(UtilMethods.GetSqlString(DbType.SqlServer,sql,pars))


            };

            //注意多租户 有几个设置几个
            //db.GetConnection(i).Aop

        });


        public void GetList()
        {
            //查询表的所有
            var list = Db.Queryable<rtdp_system_files_chunk_trans>().ToList();
        }


    }
}
