# MeusLivrosApp

Aplicação .NET MAUI para gerenciar informações de uma pequena biblioteca pessoal e realizar o CRUD básico em informações sobre livros representando pela entidade Livro onde vamos usar o banco de dados SQLite.

pacotes nuget usados:
1- sqlite-net-pcl  versão 1.8.116
2- SQLitePCLRaw.bundle_green versão 2.1.5
3- SQLitePCL.Raw.core  versão 2.1.5
4- SQLitePCLRaw.provider.dynamic_cdecl versão 2.1.5
5- SQLitePCLRaw.provider.sqlite3 versão 2.1.5
6- CommunityToolkit.Mvvm versão 8.2.1
7- CommunityToolkit.Maui versão 5.3.0

Entidade Livro:
[Table("Livros")]
public class Livro
{
   [PrimaryKey, AutoIncrement]
   public int Id { get; set; }
   [MaxLength(200)]
   public string Titulo { get; set; }
   [MaxLength(250)]
   public string Autor { get; set; }
   [MaxLength(200)]
   public string ImagemUrl { get; set; }
   [MaxLength(200)]
   public string EmprestadoPara { get; set; }
   public int Paginas { get; set; }
   public DateTime DataLancamento { get; set; }
   public bool LeituraConcluida { get; set; }
}