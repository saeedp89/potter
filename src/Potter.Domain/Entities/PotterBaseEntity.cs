﻿namespace Potter.Domain.Entities;

public abstract class PotterBaseEntity
{
    public Guid Id { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
    public DateTimeOffset DeletedAt { get; set; }
    public bool? IsDeleted { get; set; }
}