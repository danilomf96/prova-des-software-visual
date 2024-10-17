using Danilo.Models;

public class Folha
{
    public int Id { get; set; }
    public double Valor { get; set; }
    public double Quantidade { get; set; }
    public int Mes { get; set; }
    public int Ano { get; set; }
    public double Liquido { get; set; }
    public double Bruto { get; set; }
    public double Ir { get; set; }
    public double Fgts { get; set; }
    public double Inss { get; set; }

    public int FuncionarioId { get; set; }
    public Funcionario? Funcionario { get; set; }


}