using System;

namespace OnlineScheduling.Domain.Exceptions;

public class InfraException(string message) : Exception(message);