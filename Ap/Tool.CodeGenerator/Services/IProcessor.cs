using System.Threading.Tasks;
using Tool.CodeGenerator.Data.Dtos;

namespace Tool.CodeGenerator.Services
{
    /// <summary>
    /// </summary>
    public interface IProcessor
    {
        Task Execute(ArgOptions option);
    }
}
