using SQLite;

namespace MeusLivros.MVVM.Models;

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
