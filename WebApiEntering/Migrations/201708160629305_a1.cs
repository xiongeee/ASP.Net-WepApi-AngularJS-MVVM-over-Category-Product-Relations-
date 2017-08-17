namespace WebApiEntering.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a1 : DbMigration
    {
        //bu migration ' ý a1 -ignorechanges þeklinde yaptýk. Bu database i oluþturur ama ilk reverse engineering yaptýðýmýzda içindeki verileri silmez. Daha önce Hastaneotomasyon sisteminde yaptýðýmýz gibi her seferinde database deðiþikliði yaptýðýmýzda database i baþtan oluþturup elle veri girmemize gerek býrakmaz. 
        public override void Up()
        {
        }
        
        public override void Down()
        {
        }
    }
}
