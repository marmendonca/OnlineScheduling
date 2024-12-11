using System;

namespace OnlineScheduling.Domain.Exceptions;

public class DomainException(string message) : Exception(message);