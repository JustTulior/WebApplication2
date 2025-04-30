using FluentMigrator;

namespace WebApplication2.Migrations
{
    [Migration(4, "Добавление данных в таблице Users")]
    public class M004_InsertDataUsers : Migration
    {
        public override void Down()
        {
            throw new NotImplementedException();
        }
        public override void Up()
        {
            Insert.IntoTable("Users")
                .Row(new { id = Guid.NewGuid(), login = "bobr", password = "1234" })
                .Row(new { id = Guid.NewGuid(), login = "Stan", password = "youwhejr" });
        }
    }
}
