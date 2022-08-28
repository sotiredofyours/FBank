﻿using FunctionalBank.WebApi.Features.Account.Entities;

namespace FunctionalBank.WebApi.Features.User.Entity;

public class UserEntity
{
    public Guid Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public ICollection<AccountEntity>? UserAccounts { get; set; }
}