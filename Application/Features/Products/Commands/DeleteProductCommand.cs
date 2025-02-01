﻿using MediatR;

namespace Application.Features.Products.Commands;

public record DeleteProductCommand(Guid Id) : IRequest<bool>;