using System.Diagnostics.CodeAnalysis;
using MediatR;

namespace SFM.Automation.QuickbooksImport.Application.Commands
{
    /// <summary>
    ///   An abstract base command class that provides implementations of various required interfaces.
    /// </summary>
    /// <remarks>Inherit from this base class when the command does NOT return a response.</remarks>
    public abstract class Command : Command<Unit>, IRequest
    {
    }

    /// <summary>
    ///   An abstract base command class that provides implementations of various required interfaces.
    /// </summary>
    /// <typeparam name="TResponse">The response type returned by the command.</typeparam>
    /// <remarks>Inherit from this base class when the command returns a response.</remarks>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleType", Justification = "The two classes are related and small.")]
    public abstract class Command<TResponse>
        : IRequest<TResponse>
    {
    }
}