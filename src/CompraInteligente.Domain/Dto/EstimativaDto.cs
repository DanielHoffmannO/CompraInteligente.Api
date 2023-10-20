namespace CompraInteligente.Domain.Dto;

public class EstimativaDto
{
    public EstimativaDto(string produto, short quantidade) 
    {
        Produto = produto; 
        Quantidade = quantidade; 
    }

    public string Produto{ get; private set; }
    public short Quantidade { get; private set; }
}
