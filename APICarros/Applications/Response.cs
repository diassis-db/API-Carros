namespace APICarros.Applications
{
    public class Response<Resposta>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public Resposta Dados { get; set; } = default!;
    }
}
