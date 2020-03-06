namespace Application.Base.Boundaries
{
    using System.Threading.Tasks;

    /// <summary>
    /// Use Case.
    /// </summary>
    /// <typeparam name="TUseCaseInput">Any Input Message.</typeparam>
    public interface IUseCase<TUseCaseInput>
        where TUseCaseInput : IUseCaseInput
    {
        /// <summary>
        /// Executes the Use Case.
        /// </summary>
        /// <param name="input">Input Message.</param>
        /// <returns>Task.</returns>
        Task ExecuteAsync(TUseCaseInput input);
    }
}
