using DDD.Domain.Core.Commands;

namespace DDD.Domain.Commands
{
    public abstract class AnexoCommand : Command
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public string Formato { get; set; }
        public byte[] Arquivo { get; set; }
    }
}
