﻿namespace Meetups.Application.DTOs
{
    public class OutputAccountDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}