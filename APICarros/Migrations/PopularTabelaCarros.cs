using Microsoft.EntityFrameworkCore.Migrations;

namespace APICarros.Migrations
{
    public class PopularTabelaCarros : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Carros (Modelo, Ano, Cor) VALUES ('Ford Mustang', 2020, 'Vermelho')");
            migrationBuilder.Sql("INSERT INTO Carros (Modelo, Ano, Cor) VALUES ('Chevrolet Camaro', 2019, 'Preto')");
            migrationBuilder.Sql("INSERT INTO Carros (Modelo, Ano, Cor) VALUES ('Dodge Charger', 2021, 'Branco')");
            migrationBuilder.Sql("INSERT INTO Carros (Modelo, Ano, Cor) VALUES ('BMW M3', 2018, 'Azul')");
            migrationBuilder.Sql("INSERT INTO Carros (Modelo, Ano, Cor) VALUES ('Audi RS5', 2022, 'Cinza')");
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Carros WHERE Modelo IN ('Ford Mustang', 'Chevrolet Camaro', 'Dodge Charger', 'BMW M3', 'Audi RS5')");
        }

        /*
         * Esta classe foi criada para popular a tabela Carros com dados iniciais
         *  via Migration. Assim, ao rodar as migrations, a tabela será criada e populada automaticamente.
         */
    }
}
