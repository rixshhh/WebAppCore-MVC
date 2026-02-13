namespace WebApplication2.Services;

public sealed class ConflictException(string message) : Exception(message);