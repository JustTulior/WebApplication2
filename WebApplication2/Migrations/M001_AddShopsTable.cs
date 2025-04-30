using FluentMigrator;

namespace WebApplication2.Migrations
{
    [Migration(1, "Добавление таблицы Shops")]
    public class M001_AddShopsTable : Migration
    {
        public override void Down()
        {
            Delete.Table("College");
        }

        public override void Up()
        {
            Create.Table("Shops")
                .WithColumn("id").AsInt32().PrimaryKey().NotNullable().Identity()
                .WithColumn("name").AsString().NotNullable()
                .WithColumn("address").AsString().NotNullable();
        }
    }
}
