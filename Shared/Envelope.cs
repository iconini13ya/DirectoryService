using System;
using System.Collections.Generic;
using System.Text;

namespace Shared;

public record Envelope
{
    public object? Result { get; }

    public IEnumerable<Error>? Errors { get; }

    public bool IsError => Errors != null || (Errors != null && Errors.Any()); 

    public DateTime Timegenerated { get; }

    public Envelope(object? result, IEnumerable<Error>? errors)
    {
        Result = result; 
        Errors = errors;
        Timegenerated = DateTime.Now;
    }

    public static Envelope Ok(object? result = null) => new Envelope(result, null);

    public static Envelope Error(IEnumerable<Error> errors) => new Envelope(null, errors);
}

public record Envelope<T>
{
    public T? Result { get; }

    public IEnumerable<Error>? Errors { get; }

    public bool IsError => Errors != null || (Errors != null && Errors.Any());

    public DateTime Timegenerated { get; }

    public Envelope(T? result, IEnumerable<Error>? errors)
    {
        Result = result;
        Errors = errors;
        Timegenerated = DateTime.Now;
    }

    public static Envelope Ok(T? result ) => new Envelope(result, null);

    public static Envelope Error(IEnumerable<Error> errors) => new Envelope(null, errors);
}