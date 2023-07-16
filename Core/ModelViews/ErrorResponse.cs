namespace Core.ModelViews;

public class ErrorResponse
{
    public string Id { get; set; }

    public DateTime Data { get; set; }
    public string Message { get; set; }

    public ErrorResponse(string id)
    {
        Id = id;
        Data = DateTime.Now;
        Message = "Erro inesperado.";
    }
}
