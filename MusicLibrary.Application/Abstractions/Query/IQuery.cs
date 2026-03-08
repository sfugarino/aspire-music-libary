using MediatR;

namespace MusicLibrary.Application.Query;

public interface IQuery<TResult> : IRequest<TResult>
{
}