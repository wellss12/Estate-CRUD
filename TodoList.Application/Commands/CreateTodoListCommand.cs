﻿using MediatR;
using TodoList.Domain;

namespace TodoList.Application.Commands;

public record CreateTodoListCommand(string Title) : IRequest<Guid>;

public class CreateTodoListCommandHandler : IRequestHandler<CreateTodoListCommand, Guid>
{
    private readonly ITodoListRepository _repository;

    public CreateTodoListCommandHandler(ITodoListRepository repository)
    {
        _repository = repository;
    }

    public Task<Guid> Handle(CreateTodoListCommand command, CancellationToken cancellationToken)
    {
        var todoList = new Domain.TodoList(command.Title);
        _repository.Create(todoList);
        return Task.FromResult(todoList.Id);
    }
}