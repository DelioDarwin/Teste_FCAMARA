namespace API_SistemaInterno.RabitMQ
{
    public interface IRabitMQUsuario
    {
        public void SendSistemaExterno1_Incluir<T>(T message);
        public void SendSistemaExterno2_Incluir<T>(T message);
    }
}
