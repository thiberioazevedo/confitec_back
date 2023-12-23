using DDD.Domain.Core.Events;

namespace DDD.Domain.Events
{
    public class AddUsuarioHistoricoEscolarEvent : Event
    {
        public AddUsuarioHistoricoEscolarEvent(int id, int usuarioId, int anexoId, string nome)
        {
            Id = id;
            UsuarioId = usuarioId;
            AnexoId = anexoId;
            Nome = nome;
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public int UsuarioId { get; set; }
        public int AnexoId { get; set; }
    }
}
