﻿/*
 * Date: 2023-02-23
 * Author: A.A.Konkin
*/

using MediatR;
using Shared.Migrations;
using Users.Domain.Dto;
using Users.Domain.Entities;

namespace Products.Application.Commands;

/// <summary>
/// Command
/// </summary>
public class CreateProductCommand : IRequest<UserEntity>
{
    private SignUpDto Dto { get; }
        
    public CreateProductCommand(SignUpDto dto)
    {
        Dto = dto;
    }
    
    /// <summary>
    /// Handler
    /// </summary>
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, UserEntity>
    {
        private readonly IApplicationDbContext _context;
        
        public CreateProductCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<UserEntity> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            if (command.Dto is null)
                throw new Exception();
                
            var entity = new UserEntity
            {
                Id = default,
                    
                FullUserName = command.Dto.FullUserName,
                Password = command.Dto.Password,
                DateOfBirth = command.Dto.DateOfBirth,
                Email = command.Dto.Email,
                PhoneNumber = command.Dto.PhoneNumber,

                CreatedById = default,
                CreateDate = DateTime.Now,
                UpdateById = default,
                UpdateDate = DateTime.Now,
                IsDeleted = false
            };
            
            var result = await _context.Users.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync();
                
            return result.Entity;
        }
    }
}