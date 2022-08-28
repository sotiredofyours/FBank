﻿using System.ComponentModel.DataAnnotations;

namespace FunctionalBank.WebApi.Features.User.DataTransferObjects;

public class AuthenticateUserDto
{
    /// <summary>Username for authentication.</summary>
    /// <example>tony_lore</example>
    [Required]
    public string Username { get; set; } = string.Empty;

    /// <summary>Password for authentication.</summary>
    /// <example>password123</example>
    [Required]
    public string Password { get; set; } = string.Empty;
}