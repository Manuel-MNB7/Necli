public class Transacion
{
    public int Numero { get; private set; } = GenerarNumeroTransaccion();
    public DateTime Fecha { get; private set; } = DateTime.Now;
    public string NumeroCuentaOrigen { get; set; }
    public string NumeroCuentaDestinario { get; set; }
    public decimal Monto { get; set; }
    public string Tipo { get; set; }

    private static Random random = new Random();


    public static int GenerarNumeroTransaccion()
    {
        return random.Next(12121, 99999); 
    }
}
