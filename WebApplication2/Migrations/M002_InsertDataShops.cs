using FluentMigrator;

namespace WebApplication2.Migrations
{
    [Migration(2, "Добавление данных в таблицу Shops")]
    public class M002_InsertDataShops : Migration
    {
        public override void Down()
        {
            throw new NotImplementedException();
        }

        public override void Up()
        {
            Insert.IntoTable("Shops")
                 .Row(new { name = "Пятерочка", address = "уцаг0шопркшу" })
                 .Row(new { name = "Магнит", address = "jsgijguijg00kgujg" });
        }
    }
}
