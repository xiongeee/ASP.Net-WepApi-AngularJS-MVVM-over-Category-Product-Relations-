namespace WebApiEntering.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a1 : DbMigration
    {
        //bu migration ' � a1 -ignorechanges �eklinde yapt�k. Bu database i olu�turur ama ilk reverse engineering yapt���m�zda i�indeki verileri silmez. Daha �nce Hastaneotomasyon sisteminde yapt���m�z gibi her seferinde database de�i�ikli�i yapt���m�zda database i ba�tan olu�turup elle veri girmemize gerek b�rakmaz. 
        public override void Up()
        {
        }
        
        public override void Down()
        {
        }
    }
}
