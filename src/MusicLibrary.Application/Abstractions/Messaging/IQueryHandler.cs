
using MusicLibrary.Application.Query;

namespace MusicLibrary.Application.Abstractions.Messaging
{
    /// <summary>
    /// Defines a handler for processing queries of type TQuery and returning results of type TResult.
    /// </summary>
    /// <typeparam name="TQuery">The type of the query.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IQueryHandler<in TQuery, TResult> where TQuery : IQuery<TResult> 
    {
        /// <summary>
        /// Handles the specified query and returns the result.
        /// </summary>
        /// <param name="query">The query to handle.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>The result of the query.</returns>
        Task<TResult> Handle(TQuery query, CancellationToken cancellationToken);
    }
}