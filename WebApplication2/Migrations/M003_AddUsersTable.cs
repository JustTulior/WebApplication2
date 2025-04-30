using FluentMigrator;

namespace WebApplication2.Migrations
{
    [Migration(3, "Добавление таблицы Users")]
    public class M003_AddUsersTable : Migration
    {
        public override void Down()
        {
            Delete.Table("Users");
        }
        public override void Up()
        {
            Create.Table("Users")
                .WithColumn("id").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("login").AsString().NotNullable()
                .WithColumn("password").AsString().NotNullable();
        }
    }
}
